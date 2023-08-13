using System;
using System.Threading.Tasks;
using Application.LibrarianWorkplace;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibrarianWorkplaceAPI.Controllers
{
    public class ReaderController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReader(Guid id)
        {
            return HandleResult(await Mediator.Send(new DetailsReader.Query{Id = id}));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetReaderByName([FromBody]string name)
        {
            return HandleResult(await Mediator.Send(new DetailsReaderByName.Query{Name = name}));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateReader([FromBody]Reader reader)
        {
            return HandleResult(await Mediator.Send(new CreateReader.Command{Reader = reader}));
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditReader([FromQuery]Guid id,[FromBody]Reader reader)
        {
            return HandleResult(await Mediator.Send(new EditReader.Command{Id = id, Reader = reader}));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReader(Guid id)    
        {
            return HandleResult(await Mediator.Send(new DeleteReader.Command{Id = id}));
        }
        
        [HttpPost]
        public async Task<IActionResult> TakeBook([FromQuery]Guid readerGuid, Guid bookGuid)
        {
            return HandleResult(await Mediator.Send(new TakeBook.Command{ReaderGuid = readerGuid, BookGuid = bookGuid}));
        }
        
        [HttpPost]
        public async Task<IActionResult> GiveBook([FromQuery]Guid readerGuid, Guid bookGuid)
        {
            return HandleResult(await Mediator.Send(new GiveBook.Command{ReaderGuid = readerGuid, BookGuid = bookGuid}));
        }
    }
}