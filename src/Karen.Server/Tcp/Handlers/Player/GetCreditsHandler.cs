using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Revisions.V14.Composers.Player;

namespace Karen.Server.Tcp.Handlers.Player;
public class GetCreditsHandler : IHandler {
    public short Header => 8;

    private readonly IMessageDispatcher dispatcher;

    public GetCreditsHandler( IMessageDispatcher dispatcher ) {
        this.dispatcher = dispatcher;
    }

    public async Task HandleAsync( IKarenClient client, object body ) {
        if( client.Player is null )
            throw new Exception("Player was null."); // eventually we'll make this its own type

        await this.dispatcher.SendMessageAsync( client, 
            new CreditsBalanceMessage() { Credits = client.Player.PlayerDetails.Credits } );
    }
}
