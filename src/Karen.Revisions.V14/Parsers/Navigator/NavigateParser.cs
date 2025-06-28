using Karen.Common.Interfaces;
using Karen.Common.Protocol;
using Karen.Common.Messages.Incoming.Handshake;

namespace Karen.Revisions.V14.Parsers.Navigator;
public class NavigateParser : IParser<NavigateMessage> {
    public short Header => 150;

    public NavigateMessage Parse( ref PacketReader reader ) {
        return new() {
            HideFull = reader.ReadInt() == 1,
            CategoryId = reader.ReadInt()
        };
    }
}
