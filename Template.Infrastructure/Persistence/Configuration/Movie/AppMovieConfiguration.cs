using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entitys;

namespace Template.Infrastructure.Persistence.Configuration.Movie
{
    public class AppMovieConfiguration : IEntityTypeConfiguration<AppMovie>
    {
        public void Configure(EntityTypeBuilder<AppMovie> entity)
        {
            entity.ToTable("MovieGUID");

            entity.HasKey(e => e.Id); // Use e => e.Id as the primary key

            entity.Property(e => e.Id)
                .HasConversion(
                    movieId => movieId.Value,
                    value => new MovieId(value)
                );

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
