using Karen.Common.Protocol;
using System.Buffers;

namespace Karen.Common.Interfaces;
public interface IParser {
    short Header { get; }
    object Parse( ref PacketReader reader );
}

public interface IParser<T> : IParser {
    new T Parse( ref PacketReader reader );

    object IParser.Parse( ref PacketReader reader ) {
        return this.Parse( ref reader )!;
    }
}