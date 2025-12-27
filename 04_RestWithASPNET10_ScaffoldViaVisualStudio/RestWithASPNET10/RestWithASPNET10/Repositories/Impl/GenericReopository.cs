using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model.Base;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Repositories.Impl;

public class GenericReopository<T> : IRepository<T> where T : BaseEntity
{
    private MSSQLContext _context;
    private DbSet<T> _dataset;

    public GenericReopository(MSSQLContext context)
    {
        _context = context;
        _dataset = _context.Set<T>();
    }

    public List<T> FindAll()
    {
        return _dataset.ToList();
    }
    public T FindById(long id)
    {
        return _dataset.Find(id);
    }
    public T Create(T item)
    {
        _context.Add(item);
        _context.SaveChanges();
        return item;
    }
    public T Update(T item)
    {
        var existingItem = _dataset.Find(item.Id);
        if (existingItem == null) return null;
        _context.Entry(existingItem).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return existingItem;
    }

    public void Delete(long id)
    {
        var existingItem = _dataset.Find(id);
        if (existingItem == null) return;
        _dataset.Remove(existingItem);
        _context.SaveChanges();
    }

    public bool Exists(long id)
    {
        return _dataset.Any(p => p.Id == id);
    }
}
