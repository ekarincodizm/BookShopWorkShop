using System;
using System.Collections.Generic;

namespace iCONEXTWorkShop.ViewModels
{
    public class BillViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductDetailForBill> Products { get; set; }
    }
}