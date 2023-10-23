using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enums;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Person> GetPersonByDocument(string document)
        {
            return context.Person
                    .Where(x => x.Document == document && x.Status == Status.Active)
                    .ToList();
        }
    }
}