
using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Handshake;
public class CryptoParametersComposer : IComposer<CryptoParametersMessage> {
    public short Header => 277;

    public void Compose( ref PacketWriter writer, CryptoParametersMessage message ) {
        writer.Write( 0 );
    }
}
