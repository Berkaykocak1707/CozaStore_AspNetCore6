using Entities.Models;

namespace DataAccess.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IQueryable<Category> Categorys { get; }
        
        IQueryable<Category> FindAllCategorys();
        Category GetCategoryById(int? categoryId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}