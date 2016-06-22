using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookService;
using iCONEXTWorkShop.Filters;
using iCONEXTWorkShop.Helper;
using iCONEXTWorkShop.ViewModels;

namespace iCONEXTWorkShop.Controllers
{
    [LoginAuthorize]
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetShoppingCartList()
        {
            int Id = Convert.ToInt32(SessionManager.UserData.Id);

            ShoppingCartSummaryViewModel shoppingCartSummary = new ShoppingCartSummaryViewModel(); ;
            List<ShoppingCartViewModel> shoppingCart = new List<ShoppingCartViewModel>();
            ShoppingCartService shoppingCartService = new ShoppingCartService();

            double totalPrice = 0;
            foreach (var item in shoppingCartService.GetShoppingCart(Id))
            {
                var product = new ShoppingCartViewModel();
                product.UserId = item.UserId;
                product.Author = item.Author;
                product.Balance = item.Balance;
                product.Image = String.Concat(Url.Content("~/Content/images/Product/"), item.Image, ".jpg");
                product.Price = item.Price;
                product.PriceSum = item.Price * item.Quantity;
                product.ProductId = item.ProductId;
                product.Quantity = item.Quantity;
                product.Title = item.Title;
                shoppingCart.Add(product);
                totalPrice = totalPrice + product.PriceSum;
            }

            shoppingCartSummary.Price = totalPrice;
            shoppingCartSummary.Discount = 0;
            shoppingCartSummary.PoductList = shoppingCart;
            shoppingCartSummary.Total = totalPrice;

            return Json(shoppingCartSummary);
        }

        [HttpPost]
        public ActionResult DeleteCart(string id)
        {
            try
            {
                int userId = Convert.ToInt32(SessionManager.UserData.Id);
                ShoppingCartService shoppingCartService = new ShoppingCartService();
                if (shoppingCartService.DeleteCart(Convert.ToInt32(id), userId))
                {
                    JSONViewModel json = new JSONViewModel();
                    json.Message = "Success";
                    json.StatusCode = 200;
                    return Json(json);
                }
                else
                {
                    JSONViewModel json = new JSONViewModel();
                    json.Message = "Fail to delete!";
                    json.StatusCode = 500;
                    return Json(json);
                }
            }
            catch (Exception ex)
            {
                JSONViewModel json = new JSONViewModel();
                json.Message = ex.Message;
                json.StatusCode = 500;
                return Json(json);
            }
        }

        [HttpPost]
        public ActionResult UpdateBookTotalInCart(int id, int quantity)
        {
            try
            {
                int userId = Convert.ToInt32(SessionManager.UserData.Id);
                ShoppingCartService shoppingCartService = new ShoppingCartService();
                if (shoppingCartService.UpdateTotalBookInCart(Convert.ToInt32(id), userId, quantity))
                {
                    JSONViewModel json = new JSONViewModel();
                    json.Message = "Success";
                    json.StatusCode = 200;
                    return Json(json);
                }
                else
                {
                    JSONViewModel json = new JSONViewModel();
                    json.Message = "Fail to update!";
                    json.StatusCode = 500;
                    return Json(json);
                }
            }
            catch (Exception ex)
            {
                JSONViewModel json = new JSONViewModel();
                json.Message = ex.Message;
                json.StatusCode = 500;
                return Json(json);
            }
        }

        [HttpPost]
        public ActionResult ConfirmShoppingCart()
        {
            try
            {
                ShoppingCartService shoppingCartService = new ShoppingCartService();
                int userId = Convert.ToInt32(SessionManager.UserData.Id);
                OrderService orderService = new OrderService();
                int? orderId = orderService.InsertOrder(DateTime.Now, userId);
                if (orderId != null && shoppingCartService.GetShoppingCart(userId).Count != 0)
                {
                    var shoppingCart = new ShoppingCartService();
                    var shoppingCartDetails = shoppingCart.GetShoppingCartDetail(userId);
                    var productService = new ProductService();
                    
                    bool isValidQuantity = true;
                    foreach (var item in shoppingCartDetails)
                    {
                        if (!(item.ProductBalance >= item.Quantity))
                        {
                            isValidQuantity = false;
                        }
                    }
                    if (!isValidQuantity)
                    {
                        JSONViewModel json = new JSONViewModel();
                        json.Message = "จำนวนสินค้าในคลังไม่เพียงพอ";
                        json.StatusCode = 400;
                        return Json(json);
                    }

                    OrderDetailService orderDetailService = new OrderDetailService();
                    if (orderDetailService.InsertOrderDetail(Convert.ToInt32(orderId), userId))
                    {
                        foreach (var item in shoppingCartDetails)
                        {
                            productService.UpdateBalance(item.ProductId, item.ProductBalance - item.Quantity);
                        }

                        if (shoppingCartService.DeleteAllCart(userId))
                        {
                            JSONViewModel json = new JSONViewModel();
                            json.Message = orderId.ToString();
                            json.StatusCode = 200;
                            return Json(json);
                        }
                        else
                        {
                            JSONViewModel json = new JSONViewModel();
                            json.Message = "Cannot Delete all item in cart";
                            json.StatusCode = 500;
                            return Json(json);
                        }
                    }
                    else
                    {
                        JSONViewModel json = new JSONViewModel();
                        json.Message = "Cannot Insert item to order detail";
                        json.StatusCode = 500;
                        return Json(json);
                    }
                }
                else
                {
                    JSONViewModel json = new JSONViewModel();
                    json.Message = "Order detail not found";
                    json.StatusCode = 500;
                    return Json(json);
                }
            }
            catch (Exception ex)
            {
                JSONViewModel json = new JSONViewModel();
                json.Message = ex.Message;
                json.StatusCode = 500;
                return Json(json);
            }
        }
    }
}