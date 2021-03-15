using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrpcControllerBase<T> : ControllerBase where T : ClientBase<T>
    {
        protected T Service => HttpContext.RequestServices.GetService(typeof(T)) as T;
    }
}