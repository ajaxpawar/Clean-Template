using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Template.Application.Configuration.Data;
using Template.Application.Services.Local_Services;
using Template.Domain.Entitys;

namespace Template.Infrastructure.Persistence
{
    public class TemplateDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTime;
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }
        public TemplateDbContext(
            DbContextOptions<TemplateDbContext> options,
            ICurrentUserService currentUserService,
            IDateTimeService dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<AppMovie> AppMovie { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
