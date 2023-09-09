using MediatR;
using Template.Application.Features.Movie.Command;
using Template.Application.Features.Movie.Query;
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

        public async Task<AppMovie> AddMovie(string name, decimal cost)
        {
            return await _mediator.Send(new AddMoveCommand { Name = name, Cost = cost });
        }

        //Create your Usecase
        public async Task<List<AppMovie>> GetAllMovies()
        {
            return await _mediator.Send(new GetAllMoviesQuery());
        }
    }
}
