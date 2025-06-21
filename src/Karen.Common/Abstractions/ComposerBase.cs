using Karen.Common.Encoding;
using System.IO.Pipelines;

namespace Karen.Common.Abstractions;
public abstract class ComposerBase {
    private PipeWriter? writer;

    public abstract short Header { get; }

    protected async Task Write( object obj, bool as_object = false ) {
        if( as_object ) {
            await this.WriteString( obj.ToString() ?? String.Empty, append_terminator: false );
            return;
        }

        switch( obj ) {
            case string s:
                await this.WriteString( s );
                break;
            case int i:
                _ = await this.writer!.WriteAsync( VL64Encoding.Encode( i ) );
                break;
            case bool b:
                _ = this.writer!.WriteAsync( VL64Encoding.Encode( b ? 1 : 0 ) );
                break;
            default:
                await this.WriteString( obj.ToString() ?? String.Empty );
                break;
        }
    }

    protected async Task WriteKeyValue( object key, object value ) {
        await this.WriteString( $"{key}:{value}" );
        _ = await this.writer!.WriteAsync( new byte[] { 13 } ); // delimiter
    }

    protected async Task WriteValue( object key, object value ) {
        await this.WriteString( $"{key}={value}" );
        _ = await this.writer!.WriteAsync( new byte[] { 13 } ); // delimiter
    }

    protected async Task WriteDelimiter( object key, object value, string? delim = null ) {
        await this.WriteString( $"{key}{delim ?? ""}{value}", append_terminator: false );
    }

    /*public override string ToString() {
        string content = $"{this.Header} | {System.Text.Encoding.UTF8.GetString( RemainingBytes )}";

        for( int i = 0 ; i < 14 ; i++ ) {
            content = content.Replace( ( ( char )i ).ToString(), $"{{{i}}}" );
        }

        return content;
    }*/

    protected async Task WriteString( string value, bool append_terminator = true ) {
        _ = await this.writer!.WriteAsync( System.Text.Encoding.UTF8.GetBytes( value ) );
        if( append_terminator )
            _ = await this.writer!.WriteAsync( new byte[] { 2 } );
    }

    public async Task WriteToPipeAsync( PipeWriter writer, bool with_flush ) {
        this.writer = writer;

        await this.writer!.WriteAsync( Base64Encoding.Encode( this.Header, 2 ) ); // write the header

        await this.ComposeAsync(); // write the contents

        await this.writer!.WriteAsync( new( [1] ) ); // wtf ? write the end


        if( with_flush ) _ = await writer.FlushAsync();
    }

    protected abstract Task ComposeAsync();
}
