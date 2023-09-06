using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Responses;
using Portfolio.Application.Dtos.Projects;
using Portfolio.Application.Interfaces.Services;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        string ItemName = "Project";
        private readonly IProjectServices _;

        public ProjectsController(IProjectServices service)
        {
            _ = service;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllProjects(string? search)
        {
            var results = await _.GetAllProjectsAsync(search);
            return Ok(results);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProject(string id)
        {
            var result = await _.GetProjectByIdAsync(id);

            if (result == null)
            {
                return NotFound(ControllerResponses.NotFound(ItemName, id));
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] CreateProjectDto dto)
        {
            await _.CreateProjectAsync(dto);
            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditProject(string id, [FromBody] UpdateProjectDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");

            var result = await _.UpdateProjectAsync(id, dto);

            return !result ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var result = await _.DeleteProjectAsync(id);
            return !result ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }

    }
}
