using System.Threading.Tasks;
using LibraryManagement.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    public class AuthorController : GrpcControllerBase<Author.AuthorClient>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Service.GetAuthorAsync(new GetAuthorRequest { AuthorId = 1});
            return Ok(response);
        }
    }
}