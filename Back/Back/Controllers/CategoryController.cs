using Application.Enum;
using Core.Application.Feactures.Categories.Queries.GetAllCategories;
using Core.Application.Feactures.Categories.Queries.GetCategoryById;
using Core.Application.Feactures.Categories.Queries.GetPreviewCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeiTansaku.WebApi.Controllers
{
    public class CategoryController : BaseApiController
    {

        [HttpGet]
        //[Authorize(Roles = "Owner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categoryResponse = await Mediator.Send(new GetAllCategoriesQuery());
                if (categoryResponse.Count == 0)
                {
                    return NotFound();
                }
                return Ok(categoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("preview/{quantity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int quantity)
        {
            try
            {
                var categoryResponse = await Mediator.Send(new GetPreviewCategoryQuery() { quantity = quantity });
                if (categoryResponse.Count == 0)
                {
                    return NotFound();
                }
                return Ok(categoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("products/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int ID, [FromQuery]int page = 1,[FromQuery]int pageSize = 20)
        {
            try
            {
                var categoryResponse = await Mediator.Send(new GetCategoryWithProductsQuery() { ID = ID, Page = page, PageSize = pageSize });
                if (categoryResponse is null)
                {
                    return NotFound();
                }
                return Ok(categoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
