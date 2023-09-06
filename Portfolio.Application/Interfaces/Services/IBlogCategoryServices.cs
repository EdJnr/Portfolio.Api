using Portfolio.Application.Dtos.BlogCategories;
using Portfolio.Application.Dtos.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces.Services
{
    public interface IBlogCategoryServices
    {
        Task<IReadOnlyList<GetBlogCategoryDto>> GetAllBlogCategoriesAsync(string? searchText);

        Task<GetBlogCategoryDto> GetBlogCategoryByIdAsync(string id);

        Task<bool> CreateBlogCategoryAsync(CreateBlogCategoryDto dto);

        Task<bool> UpdateBlogCategoryAsync(string id, UpdateBlogCategoryDto dto);

        Task<bool> DeleteBlogCategoryAsync(string id);
    }
}
