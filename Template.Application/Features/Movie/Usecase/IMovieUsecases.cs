using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Usecase
{
    public interface IMovieUsecases
    {
        Task<List<AppMovie>> GetAllMovies();
        Task<AppMovie> AddMovie(string name,decimal cost);
    }
}
