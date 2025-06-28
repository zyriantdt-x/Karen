using Karen.Common.Interfaces;
using Karen.Common.Interfaces.Game.Services;
using Karen.Common.Messages.Outgoing.Alerts;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Revisions.V14.Messages.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class TryLoginHandler : IHandler<TryLoginMessage> {
    public short Header => 4;

    private readonly IPlayerAuthService auth;
    private readonly IMessageDispatcher dispatcher;

    public TryLoginHandler( IPlayerAuthService auth, IMessageDispatcher dispatcher ) {
        this.auth = auth;
        this.dispatcher = dispatcher;
    }

    public async Task HandleAsync( IKarenClient client, TryLoginMessage body ) {
        bool is_login_successful = await this.auth.TryLoginAsync( client, body.Username, body.Password );
        if( is_login_successful ) {
            await this.dispatcher.SendMessageAsync( client, new LoginMessage() );
            await this.dispatcher.SendMessageAsync( client, new RightsMessage() );
        } else {
            await this.dispatcher.SendMessageAsync(
                    client, new AlertMessage() { Message = "Username or password is incorrect." } );
        }
    }
}
