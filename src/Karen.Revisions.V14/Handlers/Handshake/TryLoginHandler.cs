using Karen.Common.Interfaces;
using Karen.Revisions.V14.Messages.Handshake;

namespace Karen.Revisions.V14.Handlers.Handshake;
public class TryLoginHandler : IHandler<TryLoginMessage> {
    public short Header => 4;

    public Task HandleAsync( IKarenClient client, TryLoginMessage body ) {
        throw new NotImplementedException();
    }
}
