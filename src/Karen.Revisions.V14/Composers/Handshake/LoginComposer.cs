using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;

namespace Karen.Revisions.V14.Composers.Handshake;
public class LoginComposer : IComposer<LoginMessage> {
    public short Header => 3;

    public void Compose( ref PacketWriter writer, LoginMessage message ) {
    }
}
