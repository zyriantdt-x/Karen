using System.Collections.Concurrent;

namespace Karen.Server.Tcp;

public class TcpClientService : ITcpClientService {
    private readonly List<IKarenClient> clients;
    private readonly object lock_obj;

    public TcpClientService() {
        this.clients = [];
        this.lock_obj = new();
    }

    public IKarenClient CreateClient( ConnectionContext ctx ) {
        KarenClient client = new( ctx );

        lock( this.lock_obj ) {
            this.clients.Add( client );
        }

        // send hello

        return client;
    }

    public async Task DisconnectClientAsync(IKarenClient client) {
        await client.KillAsync();

        lock( this.lock_obj ) {
            _ = this.clients.Remove( client );
        }
    }

    public IKarenClient? GetClient( Guid uuid ) {
        return this.clients.FirstOrDefault( c => c.Uuid == uuid );
    }

    public Task BroadcastMessageAsync( ComposerBase composer ) {
        return Parallel.ForEachAsync( this.clients, async ( client, st ) => await client.SendAsync( composer ) );
    }
}
