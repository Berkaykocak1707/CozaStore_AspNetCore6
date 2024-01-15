using DataAccess.Contracts;
using Entities.Models;

namespace DataAccess.Repository
{
    public class InformationRepository : RepositoryBase<Information>, IInformationRepository
    {
        public InformationRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Information> Informations => FindAll(false);
        
        public void CreateInformation(Information information)
        {
            Create(information);
            _context.SaveChanges();
        }

        public void DeleteInformation(Information information)
        {
            Delete(information);
            _context.SaveChanges();
        }

        public IQueryable<Information> FindAllInformations()
        {
            return FindAll(false);
        }

        public Information GetInformationById(int? informationId)
        {
            return FindByCondition(information => information.InfoId.Equals(informationId), false);
        }

        public void UpdateInformation(Information information)
        {
            Update(information);
            _context.SaveChanges();
        }
    }
}