using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class AboutManager : IAboutService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AboutManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateAbout(AboutForCreationDto aboutDto)
        {
            var aboutEntity = _mapper.Map<About>(aboutDto);
            _repositoryManager.About.Create(aboutEntity);
            _repositoryManager.Save();
        }

        public void DeleteAbout(int aboutId)
        {
            var about = _repositoryManager.About.GetAboutById(aboutId);
            _repositoryManager.About.Delete(about);
        }

        public IEnumerable<AboutDto> FindAllAbouts()
        {
            var about = _repositoryManager.About.FindAll(false);
            var aboutDto = _mapper.Map<IEnumerable<AboutDto>>(about);
            return aboutDto;
        }

        public AboutDto GetAboutById(int aboutId)
        {
            var about = _repositoryManager.About.GetAboutById(aboutId);
            var aboutDto = _mapper.Map<AboutDto>(about);
            return aboutDto;

        }

        public AboutForUpdateDto GetAboutByIdForUpdate(int aboutId)
        {
            var about = _repositoryManager.About.GetAboutById(aboutId);
            var aboutDto = _mapper.Map<AboutForUpdateDto>(about);
            return aboutDto;
        }

        public void UpdateAbout(AboutForUpdateDto aboutDto)
        {
            var about = _mapper.Map<About>(aboutDto);
            _repositoryManager.About.UpdateAbout(about);
        }
    }
}
