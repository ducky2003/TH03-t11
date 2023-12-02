using Microsoft.AspNetCore.Mvc;
using TH03.Models;
using TH03.Utilities;
using TH03.Areas.Admin.Models;
namespace TH03.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {private readonly DataContext _dataContext;
        public RegisterController(DataContext dataContext)
        {
            dataContext = _dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if(user == null)
            {
                return NotFound();
            }
            var check = _dataContext.AdminUsers.Where(m=>m.Email == user.Email).FirstOrDefault();
            if(check != null) {
            Functions._MessEmail = string.Empty;
            return RedirectToAction("Index","Register");}
            Functions._MessEmail = string.Empty;
            user.Pass = Functions.MD5Passwod(user.Pass);
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
