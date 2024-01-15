using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class InformationManager : IInformationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public InformationManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateInformation(InformationForCreationDto informationDto)
        {
            var informationEntity = _mapper.Map<Information>(informationDto);
            _repositoryManager.Information.CreateInformation(informationEntity);
        }

        public void DeleteInformation(int informationId)
        {
            var information = _repositoryManager.Information.GetInformationById(informationId);
            _repositoryManager.Information.DeleteInformation(information);
        }

        public IEnumerable<InformationDto> FindAllInformations()
        {
            var information = _repositoryManager.Information.FindAll(false);
            var informationDto = _mapper.Map<IEnumerable<InformationDto>>(information);
            return informationDto;
        }

        public InformationDto GetInformationById(int informationId)
        {
            var information = _repositoryManager.Information.GetInformationById(informationId);
            var informationDto = _mapper.Map<InformationDto>(information);
            return informationDto;
        }

        public InformationForUpdateDto GetInformationByIdForUpdat(int informationId)
        {
            var information = _repositoryManager.Information.GetInformationById(informationId);
            var informationDto = _mapper.Map<InformationForUpdateDto>(information);
            return informationDto;
        }

        public void UpdateInformation(InformationForUpdateDto informationDto)
        {
            var information = _mapper.Map<Information>(informationDto);
            _repositoryManager.Information.UpdateInformation(information);
        }
    }
}