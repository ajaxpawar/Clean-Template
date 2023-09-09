using Microsoft.AspNetCore.Mvc;
using Template.API.Wrappers;
using Template.Application.Common.Utilities;
using Template.Application.Features.Movie.Usecase;
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

        public MovieController(IMovieUsecases movieUsecases)
        {
            _movieUsecases = movieUsecases;
        }

        // GET: api/<MovieController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> Get()
        {
            List<AppMovie>? data = null;
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
        public async Task<ActionResult<object>> Post(string name, decimal cost)
        {
            return ApiResponse.Success(await _movieUsecases.AddMovie(name, cost)).ToResponse();

        }
    }
}
