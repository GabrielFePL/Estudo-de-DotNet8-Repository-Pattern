using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.DTO.Author;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Author;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("Listar-Autores")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthors()
        {
            var authors = await _authorService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("Buscar-Autor/{id}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return Ok(author);
        }

        [HttpGet("Buscar-Autor-Por-Livro/{id}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int id)
        {
            var author = await _authorService.GetAuthorByBookId(id);
            return Ok(author);
        }

        [HttpPost("Criar-Autor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(CreateAuthorDTO createAuthor)
        {
            var authors = await _authorService.CreateAuthor(createAuthor);
            return Ok(authors);
        }

        [HttpPut("Atualizar-Autor/{id}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> UpdateAuthor(UpdateAuthorDTO updateAuthor)
        {
            var authors = await _authorService.UpdateAuthor(updateAuthor);
            return Ok(authors);
        }

        [HttpDelete("Deletar-Autor/{id}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int id)
        {
            var authors = await _authorService.DeleteAuthor(id);
            return Ok(authors);
        }
    }
}
