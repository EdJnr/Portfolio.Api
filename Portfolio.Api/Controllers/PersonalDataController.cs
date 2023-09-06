using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Responses;
using Portfolio.Application.Dtos.PersonalData;
using Portfolio.Application.Dtos.Projects;
using Portfolio.Application.Interfaces.Services;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        string ItemName = "Personal Data";
        private readonly IPersonalDataServices _;

        public PersonalDataController(IPersonalDataServices service)
        {
            _ = service;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetPersonalData()
        {
            var results = await _.GetPersonalDataAsync();
            return Ok(results);
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddPersonalData([FromBody] CreatePersonalDataDto dto)
        {
            await _.CreatePersonalDataAsync(dto);
            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditPeronalData(string id, [FromBody] UpdatePersonalDataDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");

            var result = await _.UpdatePersonalDataAsync(id, dto);

            return !result ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePersonalData(string id)
        {
            var result = await _.DeletePersonalDataAsync(id);
            return !result ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }
    }
}
