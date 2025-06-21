using Karen.Common.Interfaces;
using Karen.Common.Protocol;
using Karen.Revisions.V14.Messages.Handshake;
using System.Text.RegularExpressions;

namespace Karen.Revisions.V14.Parsers.Handshake;
internal class TryLoginParser : IParser<TryLoginMessage> {
    public short Header => 4;

    public TryLoginMessage Parse( ref PacketReader reader ) {
        return new TryLoginMessage() {
            Username = Regex.Replace( reader.ReadString(), @"[^a-zA-Z0-9\-]", "" ),
            Password = Regex.Replace( reader.ReadString(), @"[^a-zA-Z0-9\-]", "" )
        };
    }
}
