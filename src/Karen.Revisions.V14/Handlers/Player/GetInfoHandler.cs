using Karen.Common.Interfaces;
using Karen.Revisions.V14.Composers.Player;

namespace Karen.Revisions.V14.Handlers.Player;
public class GetInfoHandler : IHandler {
    public short Header => 7;

    public async Task HandleAsync( IKarenClient client, object body ) {
        await client.SendAsync( new UserObjectComposer( client.Player!.PlayerDetails ) );
    }
}
