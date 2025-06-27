using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class InitCryptoHandler : IHandler {
    public short Header => 206;

    private readonly IMessageDispatcher dispatcher;

    public InitCryptoHandler( IMessageDispatcher dispatcher ) {
        this.dispatcher = dispatcher;
    }

    public async Task HandleAsync( IKarenClient client, object body ) {
        await this.dispatcher.SendMessageAsync( client, new CryptoParametersMessage() );
    }
}
