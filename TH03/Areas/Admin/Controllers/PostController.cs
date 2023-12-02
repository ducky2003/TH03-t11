using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TH03.Models;
namespace TH03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _dataContext;
        public PostController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var quey = _dataContext.Posts.OrderBy(m=>m.PostID).ToList();
            return View(quey);
        }
        public IActionResult Create()
        {
            var query = (from i in _dataContext.Menus
                         select new SelectListItem()
                         {
                             Text = i.MenuName,
                             Value = i.MenuID.ToString(),
                         }).ToList();
           
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Posts.Add(post);
                   _dataContext.SaveChanges();
            }
            return RedirectToAction("Index");   
        }
    }
}
