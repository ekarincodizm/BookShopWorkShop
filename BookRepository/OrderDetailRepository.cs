using System;
using BookDB;
using BookRepository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;

namespace BookRepository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<BookDB.OrderDetail> GetByOrderId(int orderId)
        {
            using (var db = new IconextBookShopEntities())
            {
                var orderDetails = db.OrderDetails
                    .Include(x => x.Order)
                    .Include(x => x.Order.User)
                    .Where(x => x.OrderId == orderId).ToList();
                return orderDetails;
            }
        }


        public bool InsertOrderDetail(List<OrderDetail> orderDetails, int orderId)
        {
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    db.OrderDetails.AddRange(orderDetails);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}