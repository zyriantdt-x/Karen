using Karen.Common.Interfaces;
using Karen.Revisions.V14.Composers.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class InitCryptoHandler : IHandler {
    public async Task HandleAsync( IKarenClient client, object body ) {
        await client.SendAsync( new CryptoParametersComposer() );
    }
}
