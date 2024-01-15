using DataAccess.Contracts;
using Entities.Models;

namespace DataAccess.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Contact> Contacts => FindAll(false);
        
        public void CreateContact(Contact contact)
        {
            Create(contact);
            _context.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            Delete(contact);
            _context.SaveChanges();
        }

        public IQueryable<Contact> FindAllContacts()
        {
            return FindAll(false);
        }

        public Contact GetContactById(int? contactId)
        {
            return FindByCondition(contact => contact.ContactId.Equals(contactId), false);
        }

        public void UpdateContact(Contact contact)
        {
            Update(contact);
            _context.SaveChanges();
        }
    }
}