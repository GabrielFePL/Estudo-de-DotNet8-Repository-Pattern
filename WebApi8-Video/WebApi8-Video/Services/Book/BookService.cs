using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.DTO.Book;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Book
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<BookModel>>> GetBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(b => b.Author).ToListAsync();
                response.Data = books;
                response.Message = "Livros Retornados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBook(int id)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(dbBook => dbBook.Id == id);
                if (book == null)
                {
                    response.Message = "Livro não encontrado.";
                    return response;
                }
                response.Data = book;
                response.Message = "Livro Retornado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books
                    .Include(b => b.Author)
                    .Where(dbBook => dbBook.Author.Id == authorId)
                    .ToListAsync();
                if (books == null)
                {
                    response.Message = "Livros não encontrados.";
                    return response;
                }
                response.Data = books;
                response.Message = "Livros Retornados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> CreateBook(CreateBookDTO createBook)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FindAsync(createBook.Author.Id);
                if (author == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                var book = new BookModel
                {
                    Title = createBook.Title,
                    Author = author
                };
                _context.Add(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.Include(b => b.Author).ToListAsync();
                response.Message = "Livro Criado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> UpdateBook(UpdateBookDTO updateBook)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.FindAsync(updateBook.Id);
                if (book == null)
                {
                    response.Message = "Livro não encontrado.";
                    return response;
                }
                var author = await _context.Authors.FindAsync(updateBook.Author.Id);
                if (author == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                book.Title = updateBook.Title;
                book.Author = author;
                _context.Update(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.ToListAsync();
                response.Message = "Livro Atualizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int id)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.Include(b => b.Author).ToListAsync();
                response.Message = "Livro Deletado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
