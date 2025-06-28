using Karen.Common.Messages.Outgoing.Handshake;

namespace Karen.Server.Tcp;

public class TcpClientService : ITcpClientService {
    private readonly List<IKarenClient> clients;
    private readonly object lock_obj;
    private readonly IMessageDispatcher message_dispatcher;

    public TcpClientService( IMessageDispatcher message_dispatcher ) {
        this.clients = [];
        this.lock_obj = new();
        this.message_dispatcher = message_dispatcher;
    }

    public async Task<IKarenClient> CreateClientAsync( ConnectionContext ctx ) {
        KarenClient client = new( ctx );

        lock( this.lock_obj ) {
            this.clients.Add( client );
        }

        await this.message_dispatcher.SendMessageAsync( client, new HelloMessage() );

        return client;
    }

    public async Task DisconnectClientAsync( IKarenClient client ) {
        await client.KillAsync();

        lock( this.lock_obj ) {
            _ = this.clients.Remove( client );
        }
    }

    public IKarenClient? GetClient( Guid uuid ) {
        return this.clients.FirstOrDefault( c => c.Uuid == uuid );
    }

    public Task BroadcastMessageAsync( IComposer composer ) {
        throw new NotImplementedException();//return Parallel.ForEachAsync( this.clients, async ( client, st ) => await client.SendAsync( composer ) );
    }
}
