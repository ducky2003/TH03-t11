using Microsoft.AspNetCore.Mvc;
using TH03.Models;

namespace TH03.Components
{
    [ViewComponent (Name = "MenuView")]
    public class MenuViewComponent : ViewComponent

    {
        private DataContext _context;
        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _context.Menus
                         where i.IsActive == true && i.Position == 1
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
