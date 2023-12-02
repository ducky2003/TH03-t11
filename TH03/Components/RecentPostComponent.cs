using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH03.Models;

namespace TH03.Components
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly DataContext _context;
     public RecentPostComponent(DataContext context)
        {
            _context = context;

        }
     public async Task<IViewComponentResult> InvokeAsync()
    {
        var query = (from i in _context.Posts
                     where i.isActive == true && i.Status == 1
                     orderby i.PostID descending
                     select i).Take(5).ToList();
            return await Task.FromResult((IViewComponentResult)View("RecentPost", query));
    }
    }
   
}
