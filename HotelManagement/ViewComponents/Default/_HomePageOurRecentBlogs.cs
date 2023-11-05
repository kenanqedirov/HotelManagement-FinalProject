using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelManagement.ViewComponents.Default
{
    public class _HomePageOurRecentBlogs : ViewComponent
    {
        private readonly IBlogService _blogManager;

        public _HomePageOurRecentBlogs(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogManager.TGetList().OrderByDescending(a=>a.BlogId).Take(3).ToList();
            return View(values);
        }
    }
}
