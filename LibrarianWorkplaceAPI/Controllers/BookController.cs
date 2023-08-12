using System;
using System.Threading.Tasks;
using Application.LibrarianWorkplace;
using Application.LibrarianWorkplace.Params;
using Domain;
using Microsoft.AspNetCore.Authentication;
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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            return HandleResult(await Mediator.Send(new DetailsBook.Query {Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]Book book)
        {
            return HandleResult(await Mediator.Send(new CreateBook.Command{Book = book}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity([FromQuery]Guid id,[FromBody]Book book)
        {
            return HandleResult(await Mediator.Send(new EditBook.Command{Id = id, Book = book}));
        }
    }
}