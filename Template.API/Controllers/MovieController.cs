using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template.API.Model.Request.Movie;
using Template.API.Wrappers;
using Template.Application.Common.Utilities;
using Template.Application.Features.Movie.Command;
using Template.Application.Features.Movie.Usecase;
using Template.Application.Features.Movie.Virtual_Models;
using Template.Domain.Entitys;

/*
 *If Yous using templates snippet in application 
 * use snippet shortcut:
 *  apiget : To genrate HttpGet Method 
 *  apipost : To genrate HttpPost Method 
 *  Template Snippet location : /Snippet
 */

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class MovieController : ControllerBase
    {
        private readonly IMovieUsecases _movieUsecases;
        private readonly ILogger<MovieController> _logger;
        public MovieController(IMovieUsecases movieUsecases, ILogger<MovieController> logger)
        {
            _movieUsecases = movieUsecases;
            _logger = logger;
        }

        // GET: api/<MovieController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> Get()
        {
            List<MovieModel>? data = null;
            data = await _movieUsecases.GetAllMovies();
            if (ValidationUtils.IsNotNullAndNotEmpty(data))
            {
                return ApiResponse.Success(data).ToResponse();
            }
            else
            {
                throw new KeyNotFoundException("No Data Presetnt In The Movies  ");
            }
        }


        //POST api/<MovieController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> Post(AddMovieRequest request)
        {
            _logger.LogInformation($"Received Request >> Post  with Body >> {JsonConvert.SerializeObject(request)}");
            return ApiResponse.Success(await _movieUsecases.AddMovie(new AddMoveCommand { Name = request.Title, Cost = request.Cost })).ToResponse();

        }
    }
}
