using Microsoft.EntityFrameworkCore;
using Template.Domain.Entitys;

namespace Template.Application.Configuration.Data
{
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Register all entity in this db context
        /// </summary>
        DbSet<AppMovie> AppMovie { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
