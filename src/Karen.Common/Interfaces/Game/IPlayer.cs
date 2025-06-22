using Karen.Common.Dto;

namespace Karen.Common.Interfaces.Game;
public interface IPlayer {
    PlayerDetails PlayerDetails { get; }
    IKarenClient KarenClient { get; }
}
