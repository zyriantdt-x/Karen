using Karen.Common.Encoding;
using System.Buffers;
using System.Text;

namespace Karen.Common.Protocol;

public readonly ref struct PacketReader {
    private readonly SequenceReader<byte> reader;

    public PacketReader( ReadOnlySequence<byte> packet ) {
        this.reader = new( packet );
    }

    public int ReadInt() {
        if( this.reader.Remaining < 1 )
            throw new InvalidOperationException( "Not enough data to read int" );

        int length = ( this.reader.UnreadSpan[ 0 ] >> 3 ) & 7;

        if( this.reader.Remaining < length )
            throw new InvalidOperationException( "Not enough data for VL64 int" );

        ReadOnlySpan<byte> span = this.PeekSpan( length );
        int value = VL64Encoding.Decode( span );
        this.reader.Advance( length );

        return value;
    }

    public int ReadBase64() {
        if( this.reader.CurrentSpan.Length - this.reader.CurrentSpanIndex < 2 )
            throw new InvalidOperationException( "Not enough data for base64" );

        ReadOnlySpan<byte> bytes = this.reader.CurrentSpan.Slice( this.reader.CurrentSpanIndex, 2 );
        this.reader.Advance( 2 );

        return Base64Encoding.Decode( bytes );
    }

    public bool ReadBoolean() {
        return this.ReadInt() == 1;
    }

    public string ReadString() {
        return System.Text.Encoding.Default.GetString( this.PeekSpan( this.ReadBase64() ) );
    }

    public byte ReadByte() {
        return this.reader.TryRead( out byte b )
               ? throw new InvalidOperationException( "Unable to read byte" )
               : b;
    }

    public ReadOnlySpan<byte> PeekSpan( int length ) {
        return this.reader.CurrentSpan.Length - this.reader.CurrentSpanIndex >= length
            ? this.reader.CurrentSpan.Slice( this.reader.CurrentSpanIndex, length )
            : throw new InvalidOperationException( "PeekSpan only supports single-span sequences" );
    }

    public SequencePosition Position => this.reader.Position;
}
