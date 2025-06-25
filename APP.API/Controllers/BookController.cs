using APP.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace APP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IBookService _bookService) : ControllerBase
{
    [HttpGet("books")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("books/{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost("books")]
    public async Task<IActionResult> CreateBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdBook = await _bookService.CreateBookAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("books/{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
    {
        if (id != book.Id || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedBook = await _bookService.UpdateBookAsync(book);
        if (updatedBook == null)
        {
            return NotFound();
        }

        return Ok(updatedBook);
    }

    [HttpDelete("books/{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _bookService.DeleteBookAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}