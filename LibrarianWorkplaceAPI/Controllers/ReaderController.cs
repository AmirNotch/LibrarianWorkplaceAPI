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
    }
}