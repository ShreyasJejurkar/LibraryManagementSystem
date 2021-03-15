namespace LibraryManagement.Book.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int AuthorId { get; set; }
    }
}
