using Microsoft.AspNetCore.Authorization;
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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _customerService = CustomerService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<Customer>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Customer>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResponse(await _customerService.Get());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<List<Customer>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Customer>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return CustomResponse(await _customerService.GetById(Id));
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseOutput<Customer>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Customer>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerDto customerDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _customerService.Create(customerDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteCustomer([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _customerService.Delete(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
