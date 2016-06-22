using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCONEXTWorkShop.ViewModels
{
    public class ShoppingCartSummaryViewModel
    {
        public List<ShoppingCartViewModel> PoductList { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
    }
}