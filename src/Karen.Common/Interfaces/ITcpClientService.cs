using Karen.Common.Protocol;
using Microsoft.AspNetCore.Connections;

namespace Karen.Common.Interfaces;
public interface ITcpClientService {
    Task<IKarenClient> CreateClientAsync( ConnectionContext ctx );

    Task DisconnectClientAsync( IKarenClient client );

    IKarenClient? GetClient( Guid uuid );

    Task BroadcastMessageAsync( ComposerBase composer );
}