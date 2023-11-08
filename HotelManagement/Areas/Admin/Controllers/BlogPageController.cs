using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class BlogPageController : Controller
    {
        private readonly IBlogService _blogManager;

        public BlogPageController(IBlogService blogManager)
        {
            _blogManager = blogManager;
        }

        public IActionResult Index()
        {
            var blogList = _blogManager.TGetList().Where(a => a.isActiveBlog is true).ToList();
            return View(blogList);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog)
        {
            AddBlogValidator validationRules = new AddBlogValidator();
            ValidationResult result = validationRules.Validate(blog);
            if (result.IsValid)
            {
                var resource = Directory.GetCurrentDirectory();
                var extensions = Path.GetExtension(blog.BlogImageFile.FileName);
                var imageName = Guid.NewGuid() + extensions;
                var saveLocation = resource + "/wwwroot/images/blog_images/" + imageName;
                using var stream = new FileStream(saveLocation, FileMode.Create);
                await blog.BlogImageFile.CopyToAsync(stream);

                blog.BlogImage = imageName;
                blog.BlogStatus = true;
                _blogManager.TAdd(blog);
                return RedirectToAction("Index", "BlogPage", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(blog);
        }
        [HttpGet]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogManager.TGetById(id);
            blog.isActiveBlog = false;
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/blog_images/" + blog.BlogImage))
            {
                System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/blog_images/" + blog.BlogImage);
            }             
            _blogManager.TUpdate(blog);
            return RedirectToAction("Index", "BlogPage", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogManager.TGetById(id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            UpdateBlogValidator validationRules = new UpdateBlogValidator();
            ValidationResult result = validationRules.Validate(blog);
            if (result.IsValid)
            {
                var blogDb = _blogManager.TGetById(blog.BlogId);
                if (blog.BlogImageFile is null)
                {
                    blogDb.BlogImage = blog.BlogImage;
                }
                else
                {
                    if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/blog_images/" + blog.BlogImage))
                    {
                        System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/blog_images/" + blog.BlogImage);
                    }
                    var resource = Directory.GetCurrentDirectory();
                    var extensions = Path.GetExtension(blog.BlogImageFile.FileName);
                    var imageName = Guid.NewGuid() + extensions;
                    var saveLocation = resource + "/wwwroot/images/blog_images/" + imageName;
                    using var stream = new FileStream(saveLocation, FileMode.Create);
                    await blog.BlogImageFile.CopyToAsync(stream);

                    blogDb.BlogImage = imageName;
                }
                blogDb.BlogCategory = blog.BlogCategory;
                blogDb.BlogTitle = blog.BlogTitle;
                blogDb.BlogDescription = blog.BlogDescription;
                blogDb.BlogStatus = blog.BlogStatus;

                _blogManager.TUpdate(blogDb);
                return RedirectToAction("Index", "BlogPage", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(blog);
        }
        public IActionResult ChangeBlogStatus(int id)
        {
            var blog = _blogManager.TGetById(id);
            if (blog is not null)
            {
                if (blog.BlogStatus is true)
                {
                    blog.BlogStatus = false;
                }
                else
                {
                    blog.BlogStatus = true;
                }
                _blogManager.TUpdate(blog);
            }
            return RedirectToAction("Index", "BlogPage", new { area = "Admin" });
        }
        public IActionResult DetailBlog(int id)
        {
            var blog = _blogManager.TGetById(id);
            return View(blog);
        }
    }
}
