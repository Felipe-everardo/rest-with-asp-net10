using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.Impl;

public class BookServicesImpl : IBookServices
{
    private IBookRepository _repository;

    public BookServicesImpl(IBookRepository repository) => _repository = repository;

    public List<Book> FindAll() => _repository.FindAll();
    public Book FindById(long id) => _repository.FindById(id);
    public Book Create(Book book) => _repository.Create(book);
    public Book Update(Book book) => _repository.Update(book);
    public void Delete(long id) => _repository.Delete(id);
}
