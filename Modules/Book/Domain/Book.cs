namespace LibraryManagement.Book.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
    }
}
