using Core.Application.Feactures.Rating.Commads.AddRating;
using Microsoft.AspNetCore.Mvc;

namespace MeiTansaku.WebApi.Controllers
{
    public class RatingController : BaseApiController
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RatingController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Rating")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RatingProduct(int rating, int productId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("uid"))?.Value;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(await Mediator.Send(new AddRatingCommand { Rating = rating, UserID = userIdClaim, ProductID = productId }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
