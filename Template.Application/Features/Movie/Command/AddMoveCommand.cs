using MediatR;
using Template.Application.Configuration.Data;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Command
{
    public class AddMoveCommand : IRequest<AppMovie>
    {
        public string Name { get;set; }
        public decimal Cost { get;set; }
        public class AddMoveCommandHandler : IRequestHandler<AddMoveCommand, AppMovie>
        {
            private readonly IApplicationDbContext _context;

            public AddMoveCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<AppMovie> Handle(AddMoveCommand request, CancellationToken cancellationToken)
            {
                AppMovie entity = new AppMovie { Name=request.Name,Cost=request.Cost};
                _context.AppMovie.Add(entity);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return entity;
            }
        }
    }
}
