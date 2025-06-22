using Microsoft.EntityFrameworkCore.Internal;

namespace Karen.Server.Storage;

public class KarenDbContextFactory : IKarenDbContextFactory {
    private readonly IDbContextFactory<KarenDbContext> storage_factory;

    public KarenDbContextFactory( IDbContextFactory<KarenDbContext> storage_factory ) {
        this.storage_factory = storage_factory;
    }

    public async Task<IKarenDbContext> CreateDbContextAsync() {
        KarenDbContext ctx = await this.storage_factory.CreateDbContextAsync();
        return ctx;
    }
}
