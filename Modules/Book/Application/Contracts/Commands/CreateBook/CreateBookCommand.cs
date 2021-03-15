namespace LibraryManagement.Book.Application.Contracts.Commands.CreateBook
{
    public record CreateBookCommand
    {
        public string Name { get; init; } = default!;
        public int AuthorId { get; init; }
    }
}