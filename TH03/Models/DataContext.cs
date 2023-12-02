﻿using Microsoft.EntityFrameworkCore;
using TH03.Areas.Admin.Models;

namespace TH03.Models
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<view_Post_Menu> PostMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
