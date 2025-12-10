using RestWithASPNET10.Model;
using System.Diagnostics.Contracts;

namespace RestWithASPNET10.Repositories;

// Define o contrato de acesso aos dados.O Serviço depende deste contrato.

public interface IPersonRepository
{
    Person Create(Person person);
    Person FindById(long id);
    List<Person> FindAll();
    Person Update(Person person);
    void Delete(long id);
}
