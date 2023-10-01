using MediatR;
using Microsoft.EntityFrameworkCore;
using Template.Application.Configuration.Data;
using Template.Application.Features.Movie.Virtual_Models;
using Template.Application.Services.LocalServices;

namespace Template.Application.Features.Movie.Query
{
    public class GetMoviesByIdQuery : IRequest<MovieModel>
    {
        public int Id { get; set; }
        public class GetMoviesByIdQueryHandler : IRequestHandler<GetMoviesByIdQuery, MovieModel>
        {
            private readonly IApplicationDbContext _context;
            private readonly IHashingService _hashingservice;

            public GetMoviesByIdQueryHandler(IApplicationDbContext context, IHashingService hashingservice)
            {
                _context = context;
                _hashingservice = hashingservice;
            }

            public async Task<MovieModel> Handle(GetMoviesByIdQuery request, CancellationToken cancellationToken)
            {
                MovieModel? response;
                var appMovies = await _context.AppMovie
                                    .Where(c => c.Id == request.Id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(cancellationToken);

                if (appMovies == null) return null;

 //               response = (MovieModel)appMovies;
                response = MovieModel.ToMovieModel(appMovies,_hashingservice);


                return response;
            }
        }
    }

}