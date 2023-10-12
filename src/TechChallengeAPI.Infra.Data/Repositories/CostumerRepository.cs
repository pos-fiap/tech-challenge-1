using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories
{
<<<<<<<< HEAD:src/TechChallengeAPI.Infra.Data/Repositories/CustomerRepository.cs
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext contexto) : base(contexto)
========
    public class CostumerRepository : BaseRepository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(ApplicationContext contexto) : base(contexto)
>>>>>>>> 2a00abc54098f34cf5a5a789647fd0c53560a41e:src/TechChallengeAPI.Infra.Data/Repositories/CostumerRepository.cs
        {
        }
    }
}
