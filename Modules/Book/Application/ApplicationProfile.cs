using AutoMapper;
using LibraryManagement.Book.Application.Contracts.Queries.GetBook;

namespace LibraryManagement.Book.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Domain.Book, GetBookQueryResponse>();
        }
    }
}