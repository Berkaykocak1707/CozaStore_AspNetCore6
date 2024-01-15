using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateCategory(CategoryForCreationDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            _repositoryManager.Category.Create(categoryEntity);
            _repositoryManager.Save();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _repositoryManager.Category.GetCategoryById(categoryId);
            _repositoryManager.Category.DeleteCategory(category);
        }

        public IEnumerable<CategoryDto> FindAllCategorys()
        {
            var category = _repositoryManager.Category.FindAllCategorys();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(category);
            return categoryDto;
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            var category = _repositoryManager.Category.GetCategoryById(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public CategoryForUpdateDto GetCategoryByIdForUpdate(int categoryId)
        {
            var category = _repositoryManager.Category.GetCategoryById(categoryId);
            var categoryDto = _mapper.Map<CategoryForUpdateDto>(category);
            return categoryDto;
        }

        public void UpdateCategory(CategoryForUpdateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _repositoryManager.Category.UpdateCategory(category);
        }
    }
}