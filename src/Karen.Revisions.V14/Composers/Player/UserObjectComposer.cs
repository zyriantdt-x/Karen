using Karen.Common.Dto;
using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Player;
public class UserObjectComposer : IComposer<UserObjectMessage> {
    public short Header => 5;

    public void Compose( ref PacketWriter writer, UserObjectMessage message ) {
        writer.Write( message.Id.ToString()! );
        writer.Write( message.Username );
        writer.Write( message.Figure );
        writer.Write( message.Sex );
        writer.Write( message.Mission );
        writer.Write( message.Tickets );
        writer.Write( message.PoolFigure );
        writer.Write( message.Film );
        writer.Write( message.ReceiveNews );
    }
}
