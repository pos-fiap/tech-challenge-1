using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCLocacoes.Application.BaseResponse;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace RCLocacoes.Api.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<Address>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Address>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResponse(await _addressService.GetAll());
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        [HttpPost("register"), Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(BaseOutput<Address>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Address>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterAddress([FromBody] AddressDto addressDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _addressService.RegisterAddress(addressDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete("delete"), Authorize]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAddress([FromQuery, NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _addressService.DeleteAddress(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
