using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Handshake;
public class AvailableSetsComposer : IComposer<AvailableSetsMessage> {
    public short Header => 8;

    public void Compose( ref PacketWriter writer, AvailableSetsMessage message ) {
        writer.Write( $"[{message.AvailableSets}]" );
    }
}
