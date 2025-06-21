using Karen.Common.Interfaces;
using Karen.Revisions.V14.Composers.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class InitCryptoHandler : IHandler {
    public short Header => 206;

    public async Task HandleAsync( IKarenClient client, object body ) {
        await client.SendAsync( new CryptoParametersComposer() );
    }
}
