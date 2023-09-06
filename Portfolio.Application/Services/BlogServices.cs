using AutoMapper;
using MongoDB.Bson;
using Portfolio.Application.Dtos.Blog;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Interfaces.Services;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private ObjectId parseId(string id)
        {
            var Id = ObjectId.Parse(id);
            return Id;
        }

        public async Task<bool> CreateBlogAsync(CreateBlogDto dto)
        {
            var model = _mapper.Map<BlogEntity>(dto);

            var result = await _unitOfWork.Blog.CreateAsync(model);
            return result;
        }

        public async Task<bool> DeleteBlogAsync(string id)
        {
            var result = await _unitOfWork.Blog.DeleteAsync(parseId(id));

            return result;
        }

        public async Task<IReadOnlyList<GetBlogDto>> GetAllBlogsAsync(string? category, string? searchText)
        {
            if (searchText != null)
            {
                var FromDb = await _unitOfWork.Blog.Query("Title", searchText);

                var results = _mapper.Map<IReadOnlyList<GetBlogDto>>(FromDb);
                return results;
            }

            var dbData = (category == null) ?
            await _unitOfWork.Blog.GetAllAsync()
            :
            await _unitOfWork.Blog.Query("Category", category);

            var DbResults = _mapper.Map<IReadOnlyList<GetBlogDto>>(dbData);
            return DbResults;
        }

        public async Task<GetBlogDto> GetBlogByIdAsync(string id)
        {
            var FromDb = await _unitOfWork.Blog.GetByIdAsync(parseId(id));

            var result = _mapper.Map<GetBlogDto>(FromDb);
            return result;
        }

        public async Task<bool> UpdateBlogAsync(string id, UpdateBlogDto dto)
        {
            var model = _mapper.Map<BlogEntity>(dto);

            var result = await _unitOfWork.Blog.UpdateAsync(parseId(id), model);
            return result;
        }
    }
}
