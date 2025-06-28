using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Player;
public class CreditBalanceComposer : IComposer<CreditsBalanceMessage> {
    public short Header => 6;

    public void Compose( ref PacketWriter writer, CreditsBalanceMessage message ) {
        writer.Write( $"{message.Credits}.0" );
    }
}