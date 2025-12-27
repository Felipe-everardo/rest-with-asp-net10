using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services;

// Define o contrato das regras de negócio para a entidade Person. O Controller depende deste contrato.
public interface IPersonServices
{
    List<Person> FindAll();
    Person FindById(long id);
    Person Create(Person person);
    Person Update(Person person);
    void Delete(long id);
}
