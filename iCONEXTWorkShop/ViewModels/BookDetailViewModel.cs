using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace iCONEXTWorkShop.ViewModels
{
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public string Auther { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public int Balance { get; set; }
        public int Id { get; set; }
    }
}