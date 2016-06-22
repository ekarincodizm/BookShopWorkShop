using BookRepository.Interface;
using System;
using System.Linq;
using BookDB;

namespace BookRepository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetById(int orderId)
        {
            using (var db = new IconextBookShopEntities())
            {
                var order = db.Orders.Include("User").Include("OrderDetail").FirstOrDefault(x => x.Id == orderId);

                return order;
            }
        }


        public int? InsertOrder(int userId, DateTime nowDateTime)
        {
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    var order = new Order { UserId = userId, TimeStamp = nowDateTime};
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return order.Id;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}