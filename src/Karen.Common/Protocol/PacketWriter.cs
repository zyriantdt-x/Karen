using Karen.Common.Encoding;
using System.Buffers;
using System.IO.Pipelines;

namespace Karen.Common.Protocol;
public class PacketWriter {
    private readonly PipeWriter writer;

    public PacketWriter( PipeWriter writer ) {
        this.writer = writer;
    }

    public void Write( object obj, bool as_object = false ) {
        if( as_object ) {
            this.WriteString( obj.ToString() ?? String.Empty, append_terminator: false );
            return;
        }

        switch( obj ) {
            case string s:
                this.WriteString( s );
                break;
            case int i:
                this.writer.Write( VL64Encoding.Encode( i ) );
                break;
            case bool b:
                this.writer.Write( VL64Encoding.Encode( b ? 1 : 0 ) );
                break;
            default:
                this.WriteString( obj.ToString() ?? String.Empty );
                break;
        }
    }

    public void WriteKeyValue( object key, object value ) {
        this.WriteString( $"{key}:{value}" );
        this.writer!.Write( new byte[] { 13 } ); // delimiter
    }

    public void WriteValue( object key, object value ) {
        this.WriteString( $"{key}={value}" );
        this.writer!.Write( new byte[] { 13 } ); // delimiter
    }

    public void WriteDelimiter( object key, object value, string? delim = null ) {
        this.WriteString( $"{key}{delim ?? ""}{value}", append_terminator: false );
    }

    /*public override string ToString() {
        string content = $"{this.Header} | {System.Text.Encoding.UTF8.GetString( RemainingBytes )}";

        for( int i = 0 ; i < 14 ; i++ ) {
            content = content.Replace( ( ( char )i ).ToString(), $"{{{i}}}" );
        }

        return content;
    }*/

    public void WriteString( string value, bool append_terminator = true ) {
        this.writer!.Write( System.Text.Encoding.UTF8.GetBytes( value ) );
        if( append_terminator )
            this.writer!.Write( new byte[] { 2 } );
    }

    /*public async Task WriteToPipeAsync( PipeWriter writer, bool with_flush ) {
        this.writer = writer;

        this.writer!.Write( Base64Encoding.Encode( this.Header, 2 ) ); // write the header

        this.Compose(); // write the contents

        this.writer!.Write( new( [ 1 ] ) ); // wtf ? write the end

        if( with_flush ) _ = await writer.FlushAsync();
    }

    public abstract void Compose();*/
}
