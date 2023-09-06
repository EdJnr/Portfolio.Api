using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Responses;
using Portfolio.Application.Dtos.Blog;
using Portfolio.Application.Dtos.BlogCategories;
using Portfolio.Application.Interfaces.Services;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        string ItemName = "Blog Category";
        private readonly IBlogCategoryServices _;

        public BlogCategoriesController(IBlogCategoryServices service)
        {
            _ = service;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogCategories(string? searchText)
        {
            var results = await _.GetAllBlogCategoriesAsync(searchText);
            return Ok(results);
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddBlogCategory([FromBody] CreateBlogCategoryDto dto)
        {
            await _.CreateBlogCategoryAsync(dto);
            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditBlogCategory(string id, [FromBody] UpdateBlogCategoryDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");

            var result = await _.UpdateBlogCategoryAsync(id, dto);

            return !result ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBlogCategory(string id)
        {
            var result = await _.DeleteBlogCategoryAsync(id);
            return !result ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }
    }
}
