using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibraryManagement.Author.Infrastructure;
using LibraryManagement.Protobuf;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Author.Service
{
    public class AuthorService : Protobuf.Author.AuthorBase
    {
        private readonly AuthorDbContext _authorDbContext;

        public AuthorService(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        public override async Task<GetAuthorResponse> GetAuthor(GetAuthorRequest request, ServerCallContext context)
        {
            var author = await _authorDbContext.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.AuthorId);

            if (author != null)
            {
                return new GetAuthorResponse
                {
                    AuthorId = author.Id,
                    AuthorName = author.Name
                };
            }

            return new GetAuthorResponse();
        }

        public override async Task<GetAllAuthorsResponse> GetAllAuthors(Empty request, ServerCallContext context)
        {
            return new GetAllAuthorsResponse();
        }
    }
}