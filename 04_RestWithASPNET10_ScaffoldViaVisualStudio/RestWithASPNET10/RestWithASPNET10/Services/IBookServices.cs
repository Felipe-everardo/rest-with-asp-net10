using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services;

public interface IBookServices
{
    List<Book> FindAll();
    Book FindById(long id);
    Book Create(Book book);
    Book Update(Book book);
    void Delete(long id);
}
