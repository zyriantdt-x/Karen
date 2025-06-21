using Karen.Common.Protocol;
using Karen.Server.Messaging;
using System.Buffers;
using System.IO.Pipelines;

namespace Karen.Server.Tcp;

public class TcpService : ConnectionHandler {
    private readonly ILogger<TcpService> logger;

    private readonly ITcpClientService client_service;
    private readonly ParserRepository parsers;
    private readonly HandlerRepository handlers;

    public TcpService( ILogger<TcpService> logger,
                       ITcpClientService client_service,
                       ParserRepository parsers,
                       HandlerRepository handlers ) {
        this.logger = logger;
        this.client_service = client_service;

        this.parsers = parsers;
        this.handlers = handlers;
    }

    public override async Task OnConnectedAsync( ConnectionContext connection ) {
        this.logger.LogInformation( $"New connection from {connection.RemoteEndPoint}" );

        IKarenClient client = await this.client_service.CreateClientAsync( connection );
        PipeReader pipe_reader = connection.Transport.Input;

        while( 1 != 2 ) {
            ReadResult read_result = await pipe_reader.ReadAsync();
            ReadOnlySequence<byte> buffer = read_result.Buffer;

            // for development purposes
            this.logger.LogInformation( $"RCVD: {System.Text.Encoding.Default.GetString( buffer.ToArray() )}" );

            if( read_result.IsCompleted && buffer.IsEmpty )
                break;

            SequenceReader<byte> reader_sequence = new( buffer );

            while( this.TrySplitBuffer( ref reader_sequence, out ReadOnlySequence<byte> message ) ) {
                PacketReader reader = new( message );
                short header = ( short )Base64Encoding.Decode( reader.PeekSpan( 2 ) );

                IParser? parser = this.parsers.GetParser( header );
                if( parser is null ) {
                    this.logger.LogWarning( $"No parser for packet {header}" );
                }

                object parsed_message = parser?.Parse( ref reader ) ?? new();

                IHandler? handler = this.handlers.GetHandler( header );
                if( handler is null ) {
                    this.logger.LogWarning( $"No handler for packet {header}" );
                    continue;
                }

                _ = handler.HandleAsync( client, parsed_message );
            }

            pipe_reader.AdvanceTo( reader_sequence.Position );
        }

        await client.KillAsync();
    }

    private bool TrySplitBuffer( ref SequenceReader<byte> reader, out ReadOnlySequence<byte> message ) {
        message = ReadOnlySequence<byte>.Empty;

        if( reader.Remaining < 5 )
            return false;

        Span<byte> encoded_message_length = stackalloc byte[ 3 ];
        if( !reader.TryCopyTo( encoded_message_length ) )
            return false;

        int message_length = Base64Encoding.Decode( encoded_message_length );
        if( message_length < 2 || reader.Remaining < 3 + message_length )
            return false;

        reader.Advance( 3 );

        message = reader.Sequence.Slice( reader.Position, message_length );

        reader.Advance( message_length );

        return true;
    }
}
