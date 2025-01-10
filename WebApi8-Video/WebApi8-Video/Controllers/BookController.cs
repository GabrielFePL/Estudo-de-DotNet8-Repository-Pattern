using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.DTO.Author;
using WebApi8_Video.DTO.Book;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Book;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("Listar-Livros")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBooks()
        {
            var books = await _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("Buscar-Livro/{id}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBook(int id)
        {
            var book = await _bookService.GetBook(id);
            return Ok(book);
        }

        [HttpGet("Buscar-Livros-Por-Autor/{id}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBooksByAuthorId(int id)
        {
            var books = await _bookService.GetBooksByAuthorId(id);
            return Ok(books);
        }

        [HttpPost("Criar-Livro")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(CreateBookDTO createBook)
        {
            var books = await _bookService.CreateBook(createBook);
            return Ok(books);
        }

        [HttpPut("Atualizar-Livro/{id}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateBook(UpdateBookDTO updateBook)
        {
            var books = await _bookService.UpdateBook(updateBook);
            return Ok(books);
        }

        [HttpDelete("Deletar-Livro/{id}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int id)
        {
            var books = await _bookService.DeleteBook(id);
            return Ok(books);
        }
    }
}
