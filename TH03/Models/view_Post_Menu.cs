﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TH03.Models
{
    [Table("view_Post_Menu")]
    public class view_Post_Menu
    {
        [Key]
        public long PostID { get; set; }
        public string?  Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? link { get; set; }
        public string? Author { get; set; }
        public string? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int PostOrder { get; set; }
        public int MenuID { get; set; }
        public int Category{ get; set; }
        public int Status { get; set; }
        public string? MenuName { get; set; }
    }
}
