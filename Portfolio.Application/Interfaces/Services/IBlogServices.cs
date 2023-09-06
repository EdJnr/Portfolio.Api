using Portfolio.Application.Dtos.Blog;
using Portfolio.Application.Dtos.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces.Services
{
    public interface IBlogServices
    {
        Task<IReadOnlyList<GetBlogDto>> GetAllBlogsAsync(string? category,string? searchText);

        Task<GetBlogDto> GetBlogByIdAsync(string id);

        Task<bool> CreateBlogAsync(CreateBlogDto dto);

        Task<bool> UpdateBlogAsync(string id, UpdateBlogDto dto);

        Task<bool> DeleteBlogAsync(string id);
    }
}
