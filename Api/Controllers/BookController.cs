using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using LibraryManagement.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly Book.BookClient _bookClient;

        public BookController(Book.BookClient bookClient)
        {
            _bookClient = bookClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allBooksResponse = await _bookClient.GetAllBooksAsync(new Empty());
            return Ok(allBooksResponse.GetBookResponse);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bookResponse = await _bookClient.GetBookAsync(new GetBookRequest { BookId = id });
            return Ok(bookResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookRequest bookRequest)
        {
            var serviceResponse =  await _bookClient.AddBookAsync(bookRequest);
            return Ok(serviceResponse);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveBookRequest request)
        {
            var response = await _bookClient.RemoveBookAsync(request);
            return Ok(response);
        }
    }
}
