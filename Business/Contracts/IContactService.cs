using Entities.Dtos;
using Entities.Models;

public interface IContactService
{
    IEnumerable<ContactDto> FindAllContacts();
    ContactDto GetContactById(int contactId);
    ContactForUpdateDto GetContactByIdForUpdateDto(int contactId);
    void CreateContact(ContactForCreationDto contactDto);
    void UpdateContact(ContactForUpdateDto contactDto);
    void DeleteContact(int contactId);
}