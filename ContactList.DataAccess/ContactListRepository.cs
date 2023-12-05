using ContactList.Models;

namespace ContactList.DataAccess
{
    public class ContactListRepository : IContactListRepository
    {
        private readonly List<Contact> contactList;
        public ContactListRepository()
        {
            contactList = new List<Contact>();
            for (int i = 1; i <= 50; i++)
            {
                Contact contact = CreateContact(i);
                contactList.Add(contact);
            }
        }
        private Contact CreateContact(int i)
        {
            Contact contact = new Contact();
            contact.Name = "Name" + i.ToString();
            contact.Email = "email" + i.ToString();
            contact.PhoneNumber = "PhoneNumber" + i.ToString();
            contact.Address = "Address" + i.ToString();

            return contact;
        }

        public List<Contact> GetAllContacts()
        {
            return contactList;
        }

        public void UpdateData(Contact contact)
        {
            Contact result = contactList.Where(x => x.Name.ToLower() == contact.Name.ToLower()).FirstOrDefault();
            if (result != null)
            {
                result.Address = contact.Address;
                result.PhoneNumber = contact.PhoneNumber;
                result.Email = contact.Email;
            }
        }
    }
}