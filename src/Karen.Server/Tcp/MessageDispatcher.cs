namespace Karen.Server.Tcp;

public class MessageDispatcher : IMessageDispatcher {
    private readonly ILogger<MessageDispatcher> logger;
    private readonly IComposerFactory composers;

    public MessageDispatcher( ILogger<MessageDispatcher> logger, IComposerFactory composers ) {
        this.logger = logger;
        this.composers = composers;
    }

    public async Task SendMessageAsync<T>( IKarenClient client, T message ) {
        PacketWriter writer = new( client.Writer );

        this.composers.CreateComposer<T>()
                      .Compose( ref writer , message );

        await client.FlushAsync();
    }
}
