using Entities.Dtos;
using Entities.Models;

namespace Business.Contracts
{
    public interface IAboutService
    {
        IEnumerable<AboutDto>? FindAllAbouts();
        AboutDto GetAboutById(int aboutId);
        AboutForUpdateDto GetAboutByIdForUpdate(int aboutId);
        void CreateAbout(AboutForCreationDto aboutDto);
        void UpdateAbout(AboutForUpdateDto aboutDto);
        void DeleteAbout(int aboutId);
    }
}