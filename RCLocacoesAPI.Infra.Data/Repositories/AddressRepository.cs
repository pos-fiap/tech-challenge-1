using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;

namespace RCLocacoes.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
