namespace Karen.Common.Interfaces;
public interface IMessageDispatcher {
    Task SendMessageAsync<T>( IKarenClient client, T message );
}
