using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using LibraryManagement.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    public class BookController : GrpcControllerBase<Book.BookClient>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allBooksResponse = await Service.GetAllBooksAsync(new Empty());
            return Ok(allBooksResponse.GetBookResponse);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bookResponse = await Service.GetBookAsync(new GetBookRequest { Id = id });
            return Ok(bookResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookRequest bookRequest)
        {
            var serviceResponse =  await Service.AddBookAsync(bookRequest);
            return Ok(serviceResponse);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveBookRequest request)
        {
            var response = await Service.RemoveBookAsync(request);
            return Ok(response);
        }
    }
}
