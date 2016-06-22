using System;
using BookModel;

namespace BookService.Interface
{
    internal interface IOrderService
    {
        OrderModel GetById(int orderId);
        int? InsertOrder(DateTime nowDateTime, int userId);
    }
}