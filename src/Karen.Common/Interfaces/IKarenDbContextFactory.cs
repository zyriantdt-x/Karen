namespace Karen.Common.Interfaces;
public interface IKarenDbContextFactory {
    Task<IKarenDbContext> CreateDbContextAsync();
}
