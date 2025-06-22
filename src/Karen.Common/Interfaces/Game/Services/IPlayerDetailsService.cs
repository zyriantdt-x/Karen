using Karen.Common.Dto;

namespace Karen.Common.Interfaces.Game.Services;
public interface IPlayerDetailsService {
    Task<PlayerDetails> GetPlayerDetails( int id );
    Task<PlayerDetails> GetPlayerDetails( string username );

    Task<PlayerDetails> SetPlayerDetails( PlayerDetails player_details );
}
