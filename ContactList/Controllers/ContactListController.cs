using ContactList.DataAccess;
using ContactList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ContactList.Controllers
{
    public class ContactListController : Controller
    {
        private readonly IMemoryCacheAccessor _memoryCacheAccessor;
        public ContactListController(IMemoryCacheAccessor memoryCacheAccessor)
        {
            _memoryCacheAccessor = memoryCacheAccessor;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = new List<Contact>();
            contacts = _memoryCacheAccessor.GetCachedContacts();

            return View(contacts);
        }

        public IActionResult Details(String Name)
        {
            Contact contact = _memoryCacheAccessor.GetCachedContacts().Where(x => x.Name.ToLower() == Name.ToLower()).FirstOrDefault();

            return View(contact);
        }

        [HttpGet]
        public ActionResult Edit(String Name)
        {
            Contact contact = _memoryCacheAccessor.GetCachedContacts().Where(x => x.Name.ToLower() == Name.ToLower()).FirstOrDefault();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            _memoryCacheAccessor.UpdateData(contact);
            return RedirectToAction("index");
        }
    }
}
