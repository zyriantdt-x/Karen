using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Alerts;

namespace Karen.Revisions.V14.Composers.Alerts;
public class AlertComposer : IComposer<AlertMessage> {
    public short Header => 139;

    public void Compose( ref PacketWriter writer, AlertMessage message ) {
        writer.Write( message.Message );
    }
}
