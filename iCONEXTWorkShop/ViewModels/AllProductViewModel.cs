using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCONEXTWorkShop.ViewModels
{
    public class AllProductViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Balance { get; set; }
    }
}