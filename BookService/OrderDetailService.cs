using BookModel;
using BookService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using BookDB;
using BookRepository;

namespace BookService
{
    public class OrderDetailService : IOrderDetailService
    {
        public List<OrderDetailModel> GetByOrderId(int orderId)
        {
            var orderDetailRepository = new OrderDetailRepository().GetByOrderId(orderId);
            var model = new List<OrderDetailModel>();
            foreach (var item in orderDetailRepository)
            {
                var orderDetailModel = new OrderDetailModel();
                orderDetailModel.Title = item.Title;
                orderDetailModel.Author = item.Author;
                orderDetailModel.CategoryName = item.CategoryName;
                orderDetailModel.Detail = item.Detail;
                orderDetailModel.Image = item.Image;
                orderDetailModel.Isbn = item.Isbn;
                orderDetailModel.OrderId = item.OrderId;
                orderDetailModel.Price = item.Price;
                orderDetailModel.ProductId = item.ProductId;
                orderDetailModel.Quantity = item.Quantity;
                orderDetailModel.OrderDate = item.Order.TimeStamp;
                orderDetailModel.FirstName = item.Order.User.FirstName;
                orderDetailModel.LastName = item.Order.User.LastName;
                orderDetailModel.Address = item.Order.User.Address;
                orderDetailModel.UserId = item.Order.UserId;
                model.Add(orderDetailModel);
            }
            return model;
        }

        public bool InsertOrderDetail(int orderId, int userId)
        {
            var shoppingCartDetails = new ShoppingCartService().GetShoppingCartDetail(userId);
            var orderDetails = new List<OrderDetail>();
            foreach (var item in shoppingCartDetails)
            {
                orderDetails.Add(new OrderDetail()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Title = item.Title,
                    Author = item.Author,
                    Image = item.Image,
                    Detail = item.Detail,
                    Isbn = item.Isbn,
                    CategoryName = item.CategoryName
                    });
            }
            var orderDetailRepository = new OrderDetailRepository();
            return orderDetailRepository.InsertOrderDetail(orderDetails, orderId);
        }
    }
}