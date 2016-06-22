using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCONEXTWorkShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public int Balance { get; set; }
        public double PriceSum { get; set; }
    }
}