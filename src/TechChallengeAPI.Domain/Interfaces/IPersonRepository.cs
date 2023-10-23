using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        public IList<Person> GetPersonByDocument(string document);
    }
}
