namespace Karen.Common.Interfaces.Game.Services;
public interface IPlayerRepository {
    IPlayer? GetPlayer( int id );
    IPlayer? GetPlayer( string username );

    void RegisterPlayer( IPlayer player );
    void DeregisterPlayer( IPlayer player );
}
