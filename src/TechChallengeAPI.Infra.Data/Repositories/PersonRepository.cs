using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Person> GetPersonByDocument(string document)
        {
            return contexto.Person
                    .Where(x => x.Document == document && x.Status == Status.Active)
                    .ToList();
        }
    }
}