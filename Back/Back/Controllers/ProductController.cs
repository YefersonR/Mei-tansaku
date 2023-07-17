using Core.Application.Feactures.Products.Queries.GetProductById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeiTansaku.WebApi.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int ID)
        {
            try
            {
                var productResponse = await Mediator.Send(new GetProductDetailsQuery { ID = ID });
                if (productResponse is null)
                {
                    return NotFound();
                }
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
