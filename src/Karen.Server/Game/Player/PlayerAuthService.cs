using Microsoft.Extensions.Logging;

namespace Karen.Server.Game.Player;
public class PlayerAuthService : IPlayerAuthService {
    private readonly ILogger<PlayerAuthService> logger;
    private readonly IPlayerRepository players;
    private readonly IPlayerDetailsService player_details;
    
    public PlayerAuthService( ILogger<PlayerAuthService> logger, IPlayerRepository players, IPlayerDetailsService player_details ) {
        this.logger = logger;
        this.players = players;
        this.player_details = player_details;
    }

    public async Task<bool> TryLoginAsync( IKarenClient client, string username, string password ) {
        PlayerDetails? pd = await this.player_details.GetPlayerDetails( username, password );
        if( pd is null ) return false;

        // obviously chck for bans

        Player player = new( client, pd );
        this.players.RegisterPlayer( player );
        client.Player = player;

        this.logger.LogInformation( $"User {player.PlayerDetails.Username} has logged in" );

        return true;
    }
}
