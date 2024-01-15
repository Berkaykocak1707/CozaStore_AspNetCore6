using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class ContactManager : IContactService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ContactManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateContact(ContactForCreationDto contactDto)
        {
            var contactEntity = _mapper.Map<Contact>(contactDto);
            _repositoryManager.Contact.CreateContact(contactEntity);
        }

        public void DeleteContact(int contactId)
        {
            var contact = _repositoryManager.Contact.GetContactById(contactId);
            _repositoryManager.Contact.DeleteContact(contact);
        }

        public IEnumerable<ContactDto> FindAllContacts()
        {
            var contact = _repositoryManager.Contact.FindAll(false);
            var contactDto = _mapper.Map<IEnumerable<ContactDto>>(contact);
            return contactDto;
        }

        public ContactDto GetContactById(int contactId)
        {
            var contact = _repositoryManager.Contact.GetContactById(contactId);
            var contactDto = _mapper.Map<ContactDto>(contact);
            return contactDto;
        }

        public ContactForUpdateDto GetContactByIdForUpdateDto(int contactId)
        {
            var contact = _repositoryManager.Contact.GetContactById(contactId);
            var contactDto = _mapper.Map<ContactForUpdateDto>(contact);
            return contactDto;
        }

        public void UpdateContact(ContactForUpdateDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            _repositoryManager.Contact.UpdateContact(contact);
        }
    }
}