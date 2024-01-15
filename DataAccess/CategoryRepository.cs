using DataAccess.Contracts;
using Entities.Models;

namespace DataAccess.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Category> Categorys => FindAll(false);
        
        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
            _context.SaveChanges();
        }

        public IQueryable<Category> FindAllCategorys()
        {
            return FindInclude(false, p => p.Products);
        }

        public Category GetCategoryById(int? categoryId)
        {
            return FindByCondition(category => category.Id.Equals(categoryId), false);
        }


        public void UpdateCategory(Category category)
        {
            Update(category);
            _context.SaveChanges();
        }
    }
}