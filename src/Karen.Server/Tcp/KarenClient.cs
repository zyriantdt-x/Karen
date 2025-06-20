using System.IO.Pipelines;

namespace Karen.Server.Tcp;

public class KarenClient : IKarenClient {
    public Guid Uuid { get; init; } = Guid.NewGuid();

    public int PlayerId { get; set; } = -1;

    public bool HasPonged { get; set; }

    private readonly ConnectionContext connection_ctx;

    public KarenClient( ConnectionContext connection_ctx ) {
        this.connection_ctx = connection_ctx;
    }

    public async Task FlushAsync() {
        _ = await this.connection_ctx.Transport.Output.FlushAsync(); // not sure if we should change this...
    }

    public ValueTask KillAsync() {
        return this.connection_ctx.Transport.Output.CompleteAsync();
    }

    public async Task SendAsync( ComposerBase composer, bool queued = false ) {
        await composer.WriteToPipeAsync( this.connection_ctx.Transport.Output, !queued );
    }
}
