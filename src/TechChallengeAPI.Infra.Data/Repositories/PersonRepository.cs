using Microsoft.EntityFrameworkCore;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;
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