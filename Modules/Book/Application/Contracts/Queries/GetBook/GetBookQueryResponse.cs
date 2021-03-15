namespace LibraryManagement.Book.Application.Contracts.Queries.GetBook
{
    public class GetBookQueryResponse
    {
		public int Id { get; set; }
		public string Name { get; set; } = default!;
		public int AuthorId { get; set; }
    }
}