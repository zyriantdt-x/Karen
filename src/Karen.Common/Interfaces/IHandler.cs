using Karen.Common.Protocol;

namespace Karen.Common.Interfaces;
public interface IHandler {
    Task HandleAsync( IKarenClient client, object body );
}

public interface IHandler<T> : IHandler {
    Task HandleAsync( IKarenClient client, T body );

    Task IHandler.HandleAsync( IKarenClient client, object body ) {
        return this.HandleAsync( client, (T)body );
    }
}