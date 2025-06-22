using Karen.Common.Storage.Entities;

namespace Karen.Server.Storage;

public class KarenDbContext : DbContext, IKarenDbContext {
    public DbSet<PlayerDetailsEntity> PlayerDetails { get; set; }

    public KarenDbContext( DbContextOptions<KarenDbContext> options ) : base( options ) {

    }

    protected override void OnModelCreating( ModelBuilder builder ) {
        base.OnModelCreating( builder );
    }
}
