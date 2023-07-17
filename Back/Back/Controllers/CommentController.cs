using Core.Application.Feactures.Comments.Commands.CreateComments;
using Core.Application.Feactures.Comments.Queries.GetAllCommentsByProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeiTansaku.WebApi.Controllers
{
    public class CommentController : BaseApiController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCommentCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await Mediator.Send(command);
                return CreatedAtAction(nameof(Post), new {command.ID},command);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int ID, [FromQuery] int page = 1)
        {
            try
            {
                var commentResponse = await Mediator.Send(new GetAllCommentsByProductQuery() { ProductID = ID});
                if (commentResponse is null)
                {
                    return NotFound();
                }
                return Ok(commentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
