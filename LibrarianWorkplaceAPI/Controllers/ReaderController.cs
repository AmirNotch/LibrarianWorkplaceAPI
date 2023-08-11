using Microsoft.AspNetCore.Mvc;

namespace LibrarianWorkplaceAPI.Controllers
{
    public class ReaderController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}