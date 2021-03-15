using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Book.Application.Contracts.Commands.CreateBook;
using LibraryManagement.Book.Application.Contracts.Commands.RemoveBook;
using LibraryManagement.Book.Application.Contracts.Queries.GetAllBooks;
using LibraryManagement.Book.Application.Contracts.Queries.GetBook;

namespace LibraryManagement.Book.Application
{
    public interface IBookApplicationService
    {
        Task<GetBookQueryResponse> GetBookAsync(GetBookQuery bookQuery);
        Task<List<GetBookQueryResponse>> GetAllBooksAsync(GetAllBooksQuery query);
        Task<CreateBookCommandResponse> AddBookAsync(CreateBookCommand request);
        Task<RemoveBookCommandResponse> RemoveBook(RemoveBookCommand request);
    }
}