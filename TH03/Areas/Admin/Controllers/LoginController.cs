using Microsoft.AspNetCore.Mvc;
using TH03.Areas.Admin.Models;
using TH03.Models;
using TH03.Utilities;
namespace TH03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(AdminUser us)
        {
            if(us == null)
            {
                return NotFound();
            }
            string pw = Functions.MD5Passwod(us.Pass);
            var check = _dataContext.AdminUsers.Where(m=>(m.Email == us.Email) && (m.Pass== us.Pass)).FirstOrDefault();
            if (check == null)
            {
                Functions._Mess = "Invalid";
                return RedirectToAction("Index", "Login");
            }
            Functions._Mess = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
            {
                
            }
        }
    }
}
