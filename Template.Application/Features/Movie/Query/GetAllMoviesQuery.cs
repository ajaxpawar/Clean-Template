using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Configuration.Data;
using Template.Application.Features.Movie.Virtual_Models;
using Template.Application.Services.LocalServices;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Query
{
    public class GetAllMoviesQuery : IRequest<List<MovieModel>>
    {
        public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieModel>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IHashingService _hashingservice;

            public GetAllMoviesQueryHandler(IApplicationDbContext context, IHashingService hashingservice)
            {
                _context = context;
                _hashingservice = hashingservice;
            }

            public async Task<List<MovieModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
            {
                var appMovies = await _context.AppMovie.AsNoTracking().ToListAsync(cancellationToken);
                //var response = appMovies.Select(entity => (MovieModel)entity).ToList();
                var response = appMovies.Select(entity => MovieModel.ToMovieModel(entity, _hashingservice)).ToList();

                return response;
            }
        }
    }
}
