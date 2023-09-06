using AutoMapper;
using MongoDB.Bson;
using Portfolio.Application.Dtos.BlogCategories;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Interfaces.Services;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Services
{
    public class BlogCategoryServices : IBlogCategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogCategoryServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private ObjectId parseId(string id)
        {
            var Id = ObjectId.Parse(id);
            return Id;
        }

        public async Task<bool> CreateBlogCategoryAsync(CreateBlogCategoryDto dto)
        {
            var model = _mapper.Map<BlogCategoryEntity>(dto);

            var result = await _unitOfWork.BlogCategory.CreateAsync(model);
            return result;
        }

        public async Task<bool> DeleteBlogCategoryAsync(string id)
        {
            var result = await _unitOfWork.BlogCategory.DeleteAsync(parseId(id));
            return result;
        }

        public async Task<IReadOnlyList<GetBlogCategoryDto>> GetAllBlogCategoriesAsync(string? searchText)
        {
            var FromDb = (searchText == null) ?
            await _unitOfWork.BlogCategory.GetAllAsync()
            :
            await _unitOfWork.BlogCategory.Query("Name", searchText);

            var results = _mapper.Map<IReadOnlyList<GetBlogCategoryDto>>(FromDb);
            return results;
        }

        public async Task<GetBlogCategoryDto> GetBlogCategoryByIdAsync(string id)
        {
            var FromDb = await _unitOfWork.BlogCategory.GetByIdAsync(parseId(id));

            var result = _mapper.Map<GetBlogCategoryDto>(FromDb);
            return result;
        }

        public async Task<bool> UpdateBlogCategoryAsync(string id, UpdateBlogCategoryDto dto)
        {
            var model = _mapper.Map<BlogCategoryEntity>(dto);

            var result = await _unitOfWork.BlogCategory.UpdateAsync(parseId(id), model);
            return result;
        }
    }
}
