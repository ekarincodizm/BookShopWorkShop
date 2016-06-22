using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    public class OrderDetailModel
    {
        public int id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Isbn { get; set; }
        public string CategoryName { get; set; }
        public DateTime OrderDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
    }
}
