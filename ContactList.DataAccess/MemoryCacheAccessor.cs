using ContactList.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DataAccess
{
    public class MemoryCacheAccessor : IMemoryCacheAccessor
    {
        private readonly IMemoryCache _memoryCache;

        private readonly IContactListRepository _contactListRepository;

        private const string cacheKey = "Contact";

        public MemoryCacheAccessor(IMemoryCache memoryCache,

        IContactListRepository contactListRepository)

        {
            _memoryCache = memoryCache;

            _contactListRepository = contactListRepository;

        }
        public List<Contact> GetCachedContacts()
        {
            

            if (!_memoryCache.TryGetValue(cacheKey,

            out List<Contact> cachedData))
            {
                cachedData = _contactListRepository.GetAllContacts();

                _memoryCache.Set(cacheKey, cachedData,
                TimeSpan.FromMinutes(10));
            }

            return cachedData;
        }

        public void UpdateData(Contact contact)
        {
            _contactListRepository.UpdateData(contact);

            List<Contact>  cachedData = _contactListRepository.GetAllContacts();

            _memoryCache.Set(cacheKey, cachedData,
                 TimeSpan.FromMinutes(10));
        }
    }
}
