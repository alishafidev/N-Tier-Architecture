using APP.DAL.Models;

public class BookService(IBookRepo _bookRepo) : IBookService
{
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _bookRepo.GetAllAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _bookRepo.GetByIdAsync(id);
    }

    public async Task<Book> CreateBookAsync(Book book)
    {
        return await _bookRepo.CreateAsync(book);
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        return await _bookRepo.UpdateAsync(book);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        return await _bookRepo.DeleteAsync(id);
    }
}