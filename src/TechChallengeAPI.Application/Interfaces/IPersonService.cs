﻿using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Models;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Interfaces
{
    public interface IPersonService
    {
        Task<BaseOutput<int>> Create(PersonDTO personDto);
        Task<BaseOutput<Person>> Update(PersonDTO personDto);
        Task<bool> Verify(string name);
        Task<bool> Verify(int Id);
        Task<BaseOutput<bool>> Delete(int Id);

        Task<BaseOutput<List<Person>>> GetAll();
        Task<BaseOutput<Person>> Get(int Id);
        Task<BaseOutput<Person>> Get(PersonDTO personDto);
        Task<Person> Get(string name);


    }
}