using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
	public class ContactFormManager : IContactFormService
	{
		private readonly IContactFormDAL _contactFormDAL;

		public ContactFormManager(IContactFormDAL contactFormDAL)
		{
			_contactFormDAL = contactFormDAL;
		}

		public List<ContactForm> TGetList()
		{
			return _contactFormDAL.GetList();
		}

		public void TAdd(ContactForm t)
		{
			_contactFormDAL.Insert(t);
		}

		public void TDelete(ContactForm t)
		{
			_contactFormDAL.Delete(t);
		}

		public ContactForm TGetById(int id)
		{
			return _contactFormDAL.GetById(id);
		}

		public void TUpdate(ContactForm t)
		{
			_contactFormDAL.Update(t);
		}
	}
}
