using Karen.Common.Abstractions;

namespace Karen.Common.Interfaces;
public interface IKarenClient {
    Guid Uuid { get; init; }
    int PlayerId { get; set; }

    bool HasPonged { get; set; }

    Task SendAsync( ComposerBase composer, bool queued = false );
    Task FlushAsync();

    ValueTask KillAsync();
}
