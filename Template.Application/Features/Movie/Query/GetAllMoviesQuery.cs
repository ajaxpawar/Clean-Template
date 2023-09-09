using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Configuration.Data;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Query
{
    public class GetAllMoviesQuery:IRequest<List<AppMovie>>
    {
        public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<AppMovie>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllMoviesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<AppMovie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
            {
                List<AppMovie> appMovies= new List<AppMovie>();
                appMovies = await _context.AppMovie.AsNoTracking().ToListAsync(cancellationToken);
                return appMovies;
            }
        }
    }
}
