using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    public class ShoppingCartDetailModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int ProductBalance { get; set; }
    }
}
