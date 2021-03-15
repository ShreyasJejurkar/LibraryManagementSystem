using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibraryManagement.Book.Application;
using LibraryManagement.Book.Application.Contracts.Commands.CreateBook;
using LibraryManagement.Book.Application.Contracts.Commands.RemoveBook;
using LibraryManagement.Book.Application.Contracts.Queries.GetAllBooks;
using LibraryManagement.Book.Application.Contracts.Queries.GetBook;
using LibraryManagement.Protobuf;

namespace LibraryManagement.Book.Service
{
    public class BookService : Protobuf.Book.BookBase
    {
        private readonly IBookApplicationService _bookApplicationService;
        private readonly IMapper _mapper;

        public BookService(IBookApplicationService bookApplicationService, IMapper mapper)
        {
            _bookApplicationService = bookApplicationService;
            _mapper = mapper;
        }
        
        public override async Task<GetBookResponse> GetBook(GetBookRequest request, ServerCallContext context)
        {
            var response = await _bookApplicationService.GetBookAsync(_mapper.Map<GetBookQuery>(request));
            return _mapper.Map<GetBookResponse>(response);
        }

        public override async Task<GetAllBooksResponse> GetAllBooks(Empty request, ServerCallContext context)
        {
            var response = await _bookApplicationService.GetAllBooksAsync(new GetAllBooksQuery());
            return new GetAllBooksResponse
            {
                GetBookResponse = { _mapper.Map<List<GetBookQueryResponse>,List<GetBookResponse>>(response) }
            };
        }

        public override async Task<AddBookResponse> AddBook(AddBookRequest request, ServerCallContext context)
        {
            var response = await _bookApplicationService.AddBookAsync(_mapper.Map<CreateBookCommand>(request));
            return  _mapper.Map<AddBookResponse>(response);
        }
        
        public override async Task<RemoveBookResponse> RemoveBook(RemoveBookRequest request, ServerCallContext context)
        {
            var response = await _bookApplicationService.RemoveBook(_mapper.Map<RemoveBookCommand>(request));
            return _mapper.Map<RemoveBookResponse>(response);
        }
    }
}
