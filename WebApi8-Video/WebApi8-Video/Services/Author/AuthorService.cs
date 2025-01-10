using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.DTO.Author;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AuthorModel>>> GetAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();
                response.Data = authors;
                response.Message = "Autores Retornados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthor(int id)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                response.Data = author;
                response.Message = "Autor Retornado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(dbBook => dbBook.Id == bookId);
                if (book == null)
                {
                    response.Message = "Livro não encontrado.";
                    return response;
                }
                response.Data = book.Author;
                response.Message = "Autor Retornado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(CreateAuthorDTO createAuthor)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = new AuthorModel()
                {
                    Name = createAuthor.Name,
                    LastName = createAuthor.LastName
                };
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor Criado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(UpdateAuthorDTO updateAuthor)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FindAsync(updateAuthor.Id);
                if (author == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                author.Name = updateAuthor.Name;
                author.LastName = updateAuthor.LastName;
                _context.Update(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor atualizado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int id)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor Deletado com Sucesso.";
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
