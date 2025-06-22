using System.Collections.Concurrent;

namespace Karen.Server.Game.Player;
public class PlayerRepository : IPlayerRepository {
    private readonly ConcurrentDictionary<int, IPlayer> players;

    public PlayerRepository() {
        this.players = [];
    }

    public void RegisterPlayer( IPlayer player ) {
        if( !this.players.TryAdd( player.PlayerDetails.Id, player ) ) {
            throw new Exception();
        }
    }

    public void DeregisterPlayer( IPlayer player ) {
        if( !this.players.TryRemove( player.PlayerDetails.Id, out _ ) ) {
            throw new Exception();
        }
    }

    public IPlayer? GetPlayer( int id ) {
        return this.players.TryGetValue( id, out IPlayer? p ) ? p : null;
    }

    public IPlayer? GetPlayer( string username ) {
        return this.players.FirstOrDefault( kvp => kvp.Value.PlayerDetails.Username == username ).Value;
    }
}
