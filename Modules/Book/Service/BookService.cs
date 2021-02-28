using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibraryManagement.Book.Infrastructure;
using LibraryManagement.Protobuf;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Book.Service
{
    public class BookService : Protobuf.Book.BookBase
    {
        private readonly BookDbContext _bookDbContext;

        public BookService(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        
        public override async Task<GetBookResponse> GetBook(GetBookRequest request, ServerCallContext context)
        {
            var book = await _bookDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);

            var response = new GetBookResponse
            {
                BookId = book.Id,
                AuthorId = book.AuthorId,
                BookName = book.BookName
            };

            return response;
        }

        public override async Task<GetAllBooksResponse> GetAllBooks(Empty request, ServerCallContext context)
        {
            var books = await _bookDbContext.Books.AsNoTracking().ToListAsync();

            IList<GetBookResponse> bookResponses = new List<GetBookResponse>();

            foreach (var item in books)
            {
                bookResponses.Add(new GetBookResponse
                {
                    BookId = item.Id,
                    AuthorId = item.AuthorId,
                    BookName = item.BookName
                });
            }
            
            return new GetAllBooksResponse
            {
                GetBookResponse = { bookResponses }
            };
        }

        public override async Task<AddBookResponse> AddBook(AddBookRequest request, ServerCallContext context)
        {
            var book = new Domain.Book
            {
                BookName = request.BookName,
                AuthorId =  request.AuthorId
            };

            await _bookDbContext.Books.AddAsync(book);
            await _bookDbContext.SaveChangesAsync();

            return new AddBookResponse
            {
                BookId = book.Id
            };
        }

        public override async Task<RemoveBookResponse> RemoveBook(RemoveBookRequest request, ServerCallContext context)
        {
            var book = await _bookDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);

            if (book is not null)
            {
                _bookDbContext.Entry(book).State = EntityState.Deleted;
                await _bookDbContext.SaveChangesAsync();
                return new RemoveBookResponse
                {
                    Deleted = true
                };
            }

            return new RemoveBookResponse
            {
                Deleted = false
            };
        }
    }
}
