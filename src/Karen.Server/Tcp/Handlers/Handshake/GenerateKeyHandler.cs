using Karen.Common.Messages.Outgoing.Handshake;

namespace Karen.Server.Tcp.Handlers.Handshake;
public class GenerateKeyHandler : IHandler {
    public short Header => 202;

    private readonly IMessageDispatcher dispatcher;

    public GenerateKeyHandler( IMessageDispatcher dispatcher ) {
        this.dispatcher = dispatcher;
    }

    public async Task HandleAsync( IKarenClient client, object body ) {
        await this.dispatcher.SendMessageAsync( client, new SessionParametersMessage() );
        await this.dispatcher.SendMessageAsync( client, new AvailableSetsMessage() );
    }
}
