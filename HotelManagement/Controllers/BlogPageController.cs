using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.Controllers
{
    public class BlogPageController : Controller
    {
        private IBlogService _blogManager;

        public BlogPageController(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IActionResult Index()
        {
            var values = _blogManager.TGetList().Where(a=>a.BlogStatus == true).ToList();
            return View(values);
        }
    }
}
