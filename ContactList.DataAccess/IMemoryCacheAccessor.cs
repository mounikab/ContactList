using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DataAccess
{
    public interface IMemoryCacheAccessor
    {
        List<Contact> GetCachedContacts();

        void UpdateData(Contact contact);
    }
}
