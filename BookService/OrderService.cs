using System;
using System.Web;
using BookRepository;
using BookService.Interface;

namespace BookService
{
    public class OrderService : IOrderService
    {
        public BookModel.OrderModel GetById(int orderId)
        {
            var orderRepository = new OrderRepository();
            var orderRepositoryModel = orderRepository.GetById(orderId);
            return null;

        }
        public int? InsertOrder(DateTime nowDateTime, int userId)
        {
            var orderRepository = new OrderRepository();
            return orderRepository.InsertOrder(userId, nowDateTime);
        }
    }
}