using Karen.Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace Karen.Common.Interfaces;
public interface IKarenDbContext {
    DbSet<PlayerDetailsEntity> PlayerDetails { get; set; }
}
