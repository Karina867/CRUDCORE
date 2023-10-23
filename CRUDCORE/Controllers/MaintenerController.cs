using CRUDCORE.Business;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCORE.Controllers
{
    public class MaintenerController : Controller
    {
        ContactBusiness _bd = new ContactBusiness();

        public IActionResult ListContact()
        {
            // show contact list 

            var olist = _bd.getContacts();
            return View(olist);
        }

        public IActionResult AddContact()
        {
            // show view
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactModel contact)
        {
            //save object type ContactModel
            if (!ModelState.IsValid)
                return View();
            var result = _bd.addContact(contact);
            if (result)
                return RedirectToAction("ListContact");
            else
                return View();
        }

        public IActionResult Edit(int IdContact)
        {
            // show view
            var contact = _bd.getContact(IdContact);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            // show view
            if (!ModelState.IsValid)
                return View();
            var result = _bd.editContact(contact);
            if (result)
                return RedirectToAction("ListContact");
            else
                return View();
        }

        public IActionResult Delete(int IdContact)
        {
            // show view
            var contact = _bd.getContact(IdContact);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            // show view        
            var result = _bd.deleteContact(contact.IdCotact);
            if (result)
                return RedirectToAction("ListContact");
            else
                return View();
        }

    }
}
