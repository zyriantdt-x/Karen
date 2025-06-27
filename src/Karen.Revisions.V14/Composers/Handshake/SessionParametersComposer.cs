using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Handshake;
using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Handshake;
public class SessionParametersComposer : IComposer<SessionParametersMessage> {
    public short Header => 257;

    public void Compose( ref PacketWriter writer, SessionParametersMessage message ) {
        writer.Write( message.Parameters.Count );

        foreach( KeyValuePair<SessionParameters, string> parameter in message.Parameters ) {
            SessionParameters key = parameter.Key;
            string value = parameter.Value;

            writer.Write( ( int )key );

            if( !String.IsNullOrWhiteSpace( value ) && Int32.TryParse( value, out int value_as_int ) )
                writer.Write( value_as_int );
            else
                writer.Write( value );
        }
    }
}