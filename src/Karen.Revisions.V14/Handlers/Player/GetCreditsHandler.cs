using Karen.Common.Interfaces;
using Karen.Revisions.V14.Composers.Player;

namespace Karen.Revisions.V14.Handlers.Player;
public class GetCreditsHandler : IHandler {
    public short Header => 8;

    public async Task HandleAsync( IKarenClient client, object body ) {
        await client.SendAsync( new CreditBalanceComposer() { Credits = client.Player!.PlayerDetails.Credits } );
    }
}
