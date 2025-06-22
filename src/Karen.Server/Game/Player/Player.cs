namespace Karen.Server.Game.Player;
public class Player : IPlayer {
    public PlayerDetails PlayerDetails { get; }
    public IKarenClient KarenClient { get; }

    public Player(IKarenClient client, PlayerDetails details) {
        this.PlayerDetails = details;
        this.KarenClient = client;
    }
}
