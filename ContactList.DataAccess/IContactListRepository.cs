using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DataAccess
{
    public interface IContactListRepository
    {
        List<Contact> GetAllContacts();

        void UpdateData(Contact contact);
    }
}
