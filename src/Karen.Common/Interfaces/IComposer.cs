using Karen.Common.Protocol;

namespace Karen.Common.Interfaces;
public interface IComposer {
    short Header { get; }
    void Compose( ref PacketWriter writer, object message );
}

public interface IComposer<T> : IComposer {
    new void Compose( ref PacketWriter writer, T message );

    void IComposer.Compose( ref PacketWriter writer, object message ) {
        this.Compose( ref writer, message );
    }
}