using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;

namespace Karen.Revisions.V14.Composers.Handshake;
public class HelloComposer : IComposer<HelloMessage> {
    public short Header => 0;

    public void Compose( ref PacketWriter writer, HelloMessage message ) {
        
    }
}
