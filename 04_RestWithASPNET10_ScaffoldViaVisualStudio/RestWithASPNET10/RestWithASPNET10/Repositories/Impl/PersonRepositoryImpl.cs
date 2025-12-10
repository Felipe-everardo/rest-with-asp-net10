using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Repositories.Impl;

// Contém o código C# que lida diretamente com o Entity Framework Core (_context).

public class PersonRepositoryImpl : IPersonRepository
{
    private MSSQLContext _context;

    public PersonRepositoryImpl(MSSQLContext context)
    {
        _context = context;
    }
    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }
    public Person FindById(long id)
    {
        return _context.Persons.Find(id);
    }
    public Person Create(Person person)
    {
        _context.Add(person);
        _context.SaveChanges();
        return person;
    }
    public Person Update(Person person)
    {
        var existingPerson = _context.Persons.Find(person.Id);
        if (existingPerson == null) return null;
        _context.Entry(existingPerson).CurrentValues.SetValues(person);
        _context.SaveChanges();
        return existingPerson;
    }
    public void Delete(long id)
    {
        var existingPerson = _context.Persons
            .Find(id);
        if (existingPerson == null) return;
        _context.Remove(existingPerson);
        _context.SaveChanges();
    }
}
