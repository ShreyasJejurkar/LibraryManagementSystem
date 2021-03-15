using System.Collections.Generic;
using AutoMapper;
using LibraryManagement.Book.Application.Contracts.Commands.CreateBook;
using LibraryManagement.Book.Application.Contracts.Commands.RemoveBook;
using LibraryManagement.Book.Application.Contracts.Queries.GetBook;
using LibraryManagement.Protobuf;

namespace LibraryManagement.Book.Service
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<GetBookRequest, GetBookQuery>();
            CreateMap<GetBookQueryResponse, GetBookResponse>();
            CreateMap<AddBookRequest, CreateBookCommand>();
            CreateMap<CreateBookCommandResponse, AddBookResponse>();
            CreateMap<RemoveBookRequest,RemoveBookCommand>();
            CreateMap<RemoveBookCommandResponse,RemoveBookResponse>();
        }
    }
}