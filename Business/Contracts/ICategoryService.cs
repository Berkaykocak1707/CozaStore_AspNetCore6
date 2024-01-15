using Entities.Dtos;
using Entities.Models;

public interface ICategoryService
{
    IEnumerable<CategoryDto> FindAllCategorys();
    CategoryDto GetCategoryById(int categoryId);
    CategoryForUpdateDto GetCategoryByIdForUpdate(int categoryId);
    void CreateCategory(CategoryForCreationDto categoryDto);
    void UpdateCategory(CategoryForUpdateDto categoryDto);
    void DeleteCategory(int categoryId);
}