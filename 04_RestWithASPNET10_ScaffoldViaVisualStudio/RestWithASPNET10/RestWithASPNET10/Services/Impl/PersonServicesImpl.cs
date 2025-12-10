using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.PersonServicesImpl;

// (Implementação): Esta classe é apenas um agente de passagem de mensagens.
// Ela recebe a chamada do Controller e a repassa imediatamente para o repositório
// (_repository.Create(person)).

public class PersonServicesImpl : IPersonServices
{
    private IPersonRepository _repository;
    
    public PersonServicesImpl(IPersonRepository repository) => _repository = repository;
 
    public List<Person> FindAll() =>  _repository.FindAll();

    public Person FindById(long id) => _repository.FindById(id);
  
    public Person Create(Person person) => _repository.Create(person);

    public Person Update(Person person) => _repository.Update(person);

    public void Delete(long id) => _repository.Delete(id);
}
