using Entities.Models;

namespace DataAccess.Contracts
{
    public interface IInformationRepository : IRepositoryBase<Information>
    {
        IQueryable<Information> Informations { get; }
        
        IQueryable<Information> FindAllInformations();
        Information GetInformationById(int? informationId);
        void CreateInformation(Information information);
        void UpdateInformation(Information information);
        void DeleteInformation(Information information);
    }
}