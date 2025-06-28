using System.Buffers;

namespace Karen.Server.Tcp;

public class MessageDispatcher : IMessageDispatcher {
    private readonly ILogger<MessageDispatcher> logger;
    private readonly IComposerFactory composers;

    public MessageDispatcher( ILogger<MessageDispatcher> logger, IComposerFactory composers ) {
        this.logger = logger;
        this.composers = composers;
    }

    public async Task SendMessageAsync<T>( IKarenClient client, T message ) {
        PacketWriter writer = new( client.Writer );
        IComposer<T> composer = this.composers.CreateComposer<T>();

        client.Writer.Write( Base64Encoding.Encode( composer.Header, 2 ) );
        composer.Compose( ref writer , message );

        await client.FlushAsync();
    }
}
