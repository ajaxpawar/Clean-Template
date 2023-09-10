using MediatR;
using Template.Application.Features.Movie.Command;
using Template.Application.Features.Movie.Query;
using Template.Application.Features.Movie.Virtual_Models;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Usecase
{
    public class MovieUsecases : IMovieUsecases
    {
        private readonly IMediator _mediator;

        public MovieUsecases(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> AddMovie(AddMoveCommand addmoviecmd)
        {
            return await _mediator.Send(addmoviecmd);
        }

        //Create your Usecase
        public async Task<List<MovieModel>> GetAllMovies()
        {
            return await _mediator.Send(new GetAllMoviesQuery());
        }
    }
}
