using Karen.Common.Interfaces.Game;
using Karen.Common.Protocol;
using System.IO.Pipelines;

namespace Karen.Common.Interfaces;
public interface IKarenClient {
    Guid Uuid { get; init; }
    IPlayer? Player { get; set; }

    bool HasPonged { get; set; }

    PipeWriter Writer { get; }

    //Task SendAsync( ComposerBase composer, bool queued = false );
    Task FlushAsync();

    ValueTask KillAsync();
}
