namespace LibraryManagement.Book.Application.Contracts.Commands.RemoveBook
{
    public class RemoveBookCommand
    {
        public int Id { get; set; }
    }
    
    public class RemoveBookCommandResponse
    {
        public bool Deleted { get; set; }
    }
}