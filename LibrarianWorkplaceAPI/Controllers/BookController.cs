using System.Threading.Tasks;
using Application.LibrarianWorkplace;
using Application.LibrarianWorkplace.Params;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibrarianWorkplaceAPI.Controllers
{
    public class BookController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetBooks([FromQuery]BookParams param)
        {
            return HandlePagedResult(await Mediator.Send(new ListBooks.Query{Params = param}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            return Ok();
        }
    }
}