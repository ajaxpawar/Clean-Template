using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.Application.Configuration.Data;
using Template.Application.Features.Movie.Virtual_Models;

namespace Template.Application.Features.Movie.Query
{
    public class GetAllMoviesQuery : IRequest<List<MovieModel>>
    {
        public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieModel>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllMoviesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<MovieModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
            {
                var appMovies = await _context.AppMovie.AsNoTracking().ToListAsync(cancellationToken);
                var response = appMovies.Select(entity => (MovieModel)entity).ToList();
                //var response = appMovies.Select(entity => MovieModel.ToMovieModel(entity)).ToList();

                return response;
            }
        }
    }
}
