using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entitys;

namespace Template.Infrastructure.Persistence.Configuration.Movie
{
    /// <summary>
    /// Configure Entity and Db Table
    /// </summary>
    public class AppMovieConfiguration : IEntityTypeConfiguration<AppMovie>
    {
        public void Configure(EntityTypeBuilder<AppMovie> entity)
        {
            entity.ToTable("Movie");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
             .HasColumnType("nvarchar(36)")
             .HasMaxLength(50)
             .IsRequired();

            entity.Property(e => e.Cost)
             .HasColumnType("decimal(18,2)")
             .IsRequired();
        }
    }
}
