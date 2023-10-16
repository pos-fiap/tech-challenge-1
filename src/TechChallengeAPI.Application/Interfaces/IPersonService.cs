using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IPersonService
    {
        Task<BaseOutput<int>> RegisterPerson(PersonDTO personDto);
        Task<BaseOutput<Person>> UpdatePerson(PersonDTO personDto);
        Task<bool> VerifyPerson(string name);
        Task<bool> VerifyPerson(int Id);
        Task<BaseOutput<bool>> DeletePerson(int Id);

        Task<BaseOutput<List<Person>>> GetAllPersons();
        Task<BaseOutput<Person>> GetPerson(int Id);
        Task<BaseOutput<Person>> GetPerson(PersonDTO personDto);
        Task<Person> GetPerson(string name);


    }
}