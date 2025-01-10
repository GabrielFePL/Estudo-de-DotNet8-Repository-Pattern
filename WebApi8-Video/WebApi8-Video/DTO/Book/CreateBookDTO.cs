using WebApi8_Video.DTO.Relationship;

namespace WebApi8_Video.DTO.Book
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public AuthorBookDTO Author { get; set; }
    }
}
