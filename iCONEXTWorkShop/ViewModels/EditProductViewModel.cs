using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace iCONEXTWorkShop.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public int Balance { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public List<SelectListItem> Categories { get; set; } 
    }
}