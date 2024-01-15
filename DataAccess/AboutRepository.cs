using DataAccess.Contracts;
using Entities.Models;
namespace DataAccess
{
    public class AboutRepository : RepositoryBase<About>, IAboutRepository
    {
        public AboutRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<About> Abouts => FindAll(false);

        public void CreateAbout(About about)
        {
            Create(about);
            _context.SaveChanges();
        }

        public void DeleteAbout(About about)
        {
            Delete(about);
            _context.SaveChanges();
        }

        public IQueryable<About> FindAllAbouts()
        {
           return FindAll(false);
        }

        public About GetAboutById(int aboutId)
        {
            return FindByCondition(a => a.AboutId.Equals(aboutId), false);
        }

        public void UpdateAbout(About about)
        {
            Update(about);
            _context.SaveChanges();
        }
    }
}
