using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibrarianWorkplaceAPI.Controllers
{
    public class BookController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            return Ok();
        }
    }
}