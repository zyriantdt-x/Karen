using Microsoft.EntityFrameworkCore;

namespace Karen.Game.Player;
public class PlayerDetailsService : IPlayerDetailsService {
    private readonly IKarenDbContextFactory storage_factory;

    public PlayerDetailsService(IKarenDbContextFactory storage_factory) {
        this.storage_factory = storage_factory;
    }

    public async Task<PlayerDetails?> GetPlayerDetails( int id ) {
        IKarenDbContext storage = await this.storage_factory.CreateDbContextAsync();

        PlayerDetailsEntity? pd = await storage.PlayerDetails.FindAsync( id );

        return pd?.MapToDto();
    }

    public async Task<PlayerDetails?> GetPlayerDetails( string username ) {
        IKarenDbContext storage = await this.storage_factory.CreateDbContextAsync();

        PlayerDetailsEntity? pd = await storage.PlayerDetails.FirstOrDefaultAsync( p => p.Username == username );

        return pd?.MapToDto();
    }

    public async Task<PlayerDetails?> GetPlayerDetails( string username, string password ) {
        IKarenDbContext storage = await this.storage_factory.CreateDbContextAsync();

        PlayerDetailsEntity? pd = await storage.PlayerDetails.FirstOrDefaultAsync( p => p.Username == username && p.Password == password );

        return pd?.MapToDto();
    }

    public Task SetPlayerDetails( PlayerDetails player_details ) {
        throw new NotImplementedException();
    }
}
