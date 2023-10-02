using MediatR;
using Template.Application.Configuration.Data;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Command
{
    public class AddMoveCommand : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public class AddMoveCommandHandler : IRequestHandler<AddMoveCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public AddMoveCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(AddMoveCommand request, CancellationToken cancellationToken)
            {
                AppMovie entity = new AppMovie
                {
                    Id = new MovieId(Guid.NewGuid()),
                    Name = request.Name,
                    Cost = request.Cost
                };
                _context.AppMovie.Add(entity);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return "Movie added Succefully";
            }
        }
    }
}
