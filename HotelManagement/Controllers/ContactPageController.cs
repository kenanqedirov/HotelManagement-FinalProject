using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [AllowAnonymous]
    public class ContactPageController : Controller
    {
        private readonly IContactFormService _contactFormManager;

        public ContactPageController(IContactFormService contactFormManager)
        {
            _contactFormManager = contactFormManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                ContactForm form = new ContactForm()
                {
                    ContactFormName = model.Name,
                    ContactFormEmail = model.Mail,
                    ContactFormPhone = model.Phone,
                    ContactFormMessage = model.Message
                };
                _contactFormManager.TAdd(form);
                return RedirectToAction("Index","ContactPage");
            }
         
            return View(model);
        }

    }
}
