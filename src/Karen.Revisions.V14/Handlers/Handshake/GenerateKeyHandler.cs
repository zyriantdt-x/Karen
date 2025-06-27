using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Revisions.V14.Composers.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class GenerateKeyHandler : IHandler {
    public short Header => 202;

    private readonly IMessageDispatcher dispatcher;

    public GenerateKeyHandler( IMessageDispatcher dispatcher ) {
        this.dispatcher = dispatcher;
    }

    public async Task HandleAsync( IKarenClient client, object body ) {
        await this.dispatcher.SendMessageAsync( client, new AvailableSetsMessage() );

        await client.SendAsync( new SessionParametersComposer() );
        await client.SendAsync( new AvailableSetsComposer() );
    }
}
