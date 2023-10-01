using MediatR;
using Template.Application.Features.Movie.Command;
using Template.Application.Features.Movie.Query;
using Template.Application.Features.Movie.Virtual_Models;

namespace Template.Application.Features.Movie.Usecase
{
    public class MovieUsecases : IMovieUsecases
    {
        private readonly IMediator _mediator;

        public MovieUsecases(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Add(AddMoveCommand addmoviecmd)
        {
            return await _mediator.Send(addmoviecmd);
        }

        public async Task<MovieModel> Get(int id)
        {
            return await _mediator.Send(new GetMoviesByIdQuery{Id=id});
        }

        //Create your Usecase
        public async Task<List<MovieModel>> GetAll()
        {
            return await _mediator.Send(new GetAllMoviesQuery());
        }
    }

}
