using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
