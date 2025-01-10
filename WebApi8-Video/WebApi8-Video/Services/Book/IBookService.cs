using WebApi8_Video.DTO.Book;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Book
{
    public interface IBookService
    {
        public Task<ResponseModel<List<BookModel>>> GetBooks();
        public Task<ResponseModel<BookModel>> GetBook(int id);
        public Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId);
        public Task<ResponseModel<List<BookModel>>> CreateBook(CreateBookDTO createBook);
        public Task<ResponseModel<List<BookModel>>> UpdateBook(UpdateBookDTO updateBook);
        public Task<ResponseModel<List<BookModel>>> DeleteBook(int id);
    }
}
