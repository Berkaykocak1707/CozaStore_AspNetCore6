using Entities.Models;

namespace DataAccess.Contracts
{
    public interface IAboutRepository : IRepositoryBase<About>
    {
        IQueryable<About> Abouts { get; }
        
        IQueryable<About> FindAllAbouts();
        About GetAboutById(int aboutId);
        void CreateAbout(About about);
        void UpdateAbout(About about);
        void DeleteAbout(About about);
    }
}