using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asynchronous_Assignment.Models;
using Asynchronous_Assignment.Repositories;
using System.Threading.Tasks;


namespace Asynchronous_Assignment.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return View(contacts);
        }
        // GET: Contacts
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            await _contactRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}