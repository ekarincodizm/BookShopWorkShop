using BookService;
using iCONEXTWorkShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCONEXTWorkShop.Filters;
using iCONEXTWorkShop.Helper;

//<?php  session_start();  ?>

namespace iCONEXTWorkShop.Controllers
{
    public class BillController : Controller
    {
        private HttpContext context = System.Web.HttpContext.Current;

        [LoginAuthorize]
        public ActionResult Index(int orderId)
        {
            var orderDetailService = new OrderDetailService();
            var orderDetail = orderDetailService.GetByOrderId(orderId);
            var sessionUserId = Convert.ToInt32(SessionManager.UserData.Id);
            if (orderDetail.Count <= 0 || sessionUserId == null)
            {
                return RedirectToAction("Error191");
            }

            if (orderDetail.First().UserId == Convert.ToInt32(sessionUserId))
            {
                var model = new BillViewModel();
                model.Products = new List<ProductDetailForBill>();
                double totalPrice = 0;
                foreach (var item in orderDetail)
                {
                    var billViewModel = new ProductDetailForBill();
                    billViewModel.Title = item.Title;
                    billViewModel.Quantity = item.Quantity;
                    billViewModel.Price = item.Price;
                    billViewModel.TotalPrice = item.Price * item.Quantity;
                    totalPrice += item.Price * item.Quantity;
                    model.Products.Add(billViewModel);
                }
                model.OrderId = orderDetail.First().OrderId;
                model.FirstName = orderDetail.First().FirstName;
                model.LastName = orderDetail.First().LastName;
                model.Address = orderDetail.First().Address;
                model.TotalPrice = totalPrice;
                model.OrderDate = DateTime.Now;
                return View(model);
            }
            else
            {
                return RedirectToAction("Error191");
            }
        }

        public ActionResult Error191()
        {
            return PartialView();
        }
    }
}