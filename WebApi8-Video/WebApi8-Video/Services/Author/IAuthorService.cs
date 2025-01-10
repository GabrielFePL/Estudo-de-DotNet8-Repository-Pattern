using WebApi8_Video.DTO.Author;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Author
{
    public interface IAuthorService
    {
        public Task<ResponseModel<List<AuthorModel>>> GetAuthors();
        public Task<ResponseModel<AuthorModel>> GetAuthor(int id);
        public Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId);
        public Task<ResponseModel<List<AuthorModel>>> CreateAuthor(CreateAuthorDTO createAuthor);
        public Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(UpdateAuthorDTO updateAuthor);
        public Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int id);
    }
}
