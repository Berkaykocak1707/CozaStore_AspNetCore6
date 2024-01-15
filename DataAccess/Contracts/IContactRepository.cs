using Entities.Models;

namespace DataAccess.Contracts
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        IQueryable<Contact> Contacts { get; }
        
        IQueryable<Contact> FindAllContacts();
        Contact GetContactById(int? contactId);
        void CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}