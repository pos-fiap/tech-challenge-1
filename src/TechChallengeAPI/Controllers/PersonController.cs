﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using TechChallenge.Application.BaseResponse;
using TechChallenge.Application.DTOs;
using TechChallenge.Application.Interfaces;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Api.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<List<Person>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Person>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResponse(await _personService.GetAllPersons());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]      
        [ProducesResponseType(typeof(BaseOutput<Person>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Person>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterPerson([FromBody] PersonDTO personDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _personService.RegisterPerson(personDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut]        
        [ProducesResponseType(typeof(BaseOutput<Person>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Person>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteUser([FromBody] PersonDTO personDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _personService.UpdatePerson(personDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]       
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeletePerson([FromQuery, NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _personService.DeletePerson(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}