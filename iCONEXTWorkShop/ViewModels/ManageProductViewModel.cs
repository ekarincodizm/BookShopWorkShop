using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace iCONEXTWorkShop.ViewModels
{
    public class ManageProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public int Balance { get; set; }

        public bool IsActive { get; set; }

    }
}