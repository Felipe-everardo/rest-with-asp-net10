using RestWithASPNET10.Model;

namespace RestWithASPNET10.Repositories;

public interface IBookRepository
{
    List<Book> FindAll();
    Book FindById(long id);
    Book Update(Book book);
    Book Create(Book book);
    void Delete(long id);
}
