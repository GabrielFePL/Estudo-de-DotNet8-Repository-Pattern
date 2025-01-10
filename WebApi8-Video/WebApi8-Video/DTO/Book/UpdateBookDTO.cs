using WebApi8_Video.DTO.Relationship;

namespace WebApi8_Video.DTO.Book
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorBookDTO Author { get; set; }
    }
}
