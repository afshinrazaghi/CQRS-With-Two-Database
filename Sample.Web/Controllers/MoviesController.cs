using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Core.MovieApplication.Commands.AddMovie;
using Sample.Core.MovieApplication.Queries.GetMovieByName;

namespace Sample.Web.Controllers
{
    [ApiController]
    [Route("Movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ISender _sender;

        public MoviesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(AddMovieCommand model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = await _sender.Send(model, cancellationToken);

            return Ok(command);
        }


        [HttpGet("GetMovieByName")]
        public async Task<IActionResult> GetMovieByName([FromQuery] GetMovieByNameQuery model, CancellationToken cancellationToken)
        {
            var query = await _sender.Send(model, cancellationToken);

            return Ok(query);
        }
    }
}
