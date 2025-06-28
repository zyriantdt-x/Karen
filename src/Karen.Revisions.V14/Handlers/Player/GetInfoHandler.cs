using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Revisions.V14.Composers.Player;

namespace Karen.Revisions.V14.Handlers.Player;
public class GetInfoHandler : IHandler {
    public short Header => 7;

    private readonly IMessageDispatcher dispatcher;

    public GetInfoHandler( IMessageDispatcher dispatcher ) {
        this.dispatcher = dispatcher;
    }

    public async Task HandleAsync( IKarenClient client, object body ) {
        if( client.Player is null )
            throw new Exception();

        await this.dispatcher.SendMessageAsync( client, new UserObjectMessage( client.Player.PlayerDetails ) );
    }
}
