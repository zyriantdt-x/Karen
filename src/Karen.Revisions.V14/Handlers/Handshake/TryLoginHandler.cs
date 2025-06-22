using Karen.Common.Interfaces;
using Karen.Common.Interfaces.Game.Services;
using Karen.Revisions.V14.Composers.Alerts;
using Karen.Revisions.V14.Composers.Handshake;
using Karen.Revisions.V14.Composers.Player;
using Karen.Revisions.V14.Messages.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class TryLoginHandler : IHandler<TryLoginMessage> {
    public short Header => 4;

    private readonly IPlayerAuthService auth;

    public TryLoginHandler( IPlayerAuthService auth ) {
        this.auth = auth;
    }

    public async Task HandleAsync( IKarenClient client, TryLoginMessage body ) {
        bool is_login_successful = await this.auth.TryLoginAsync( client, body.Username, body.Password );
        if(!is_login_successful) {
            await client.SendAsync( new AlertComposer() { Message = "Username or password is incorrect." } );
            return;
        }

        await client.SendAsync( new LoginComposer() );
        await client.SendAsync( new RightsComposer() );
    }
}
