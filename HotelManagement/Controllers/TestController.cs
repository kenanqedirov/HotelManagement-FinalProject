using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
	public class TestController : Controller
	{
		private readonly IBlogService _blogManager;

		public TestController(IBlogService blogManager)
		{
			_blogManager = blogManager;
		}

		public IActionResult Index()
		{
			var values= _blogManager.TGetList();
			return View(values);
		}
	}
}
