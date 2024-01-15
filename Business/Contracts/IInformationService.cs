using Entities.Dtos;
using Entities.Models;

public interface IInformationService
{
    IEnumerable<InformationDto> FindAllInformations();
    InformationDto GetInformationById(int informationId);
    InformationForUpdateDto GetInformationByIdForUpdat(int informationId);
    void CreateInformation(InformationForCreationDto informationDto);
    void UpdateInformation(InformationForUpdateDto informationDto);
    void DeleteInformation(int informationId);
}