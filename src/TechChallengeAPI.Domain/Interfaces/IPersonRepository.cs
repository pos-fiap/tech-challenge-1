using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        public IList<Person> GetPersonByDocument(string document);
    }
}
