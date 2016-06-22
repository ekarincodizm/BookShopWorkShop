using System;
using System.Collections.Generic;
using System.Web;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookModel;
using BookService;
using iCONEXTWorkShop.Filters;
using iCONEXTWorkShop.Helper;
using iCONEXTWorkShop.ViewModels;
using Microsoft.AspNet.Identity;

namespace iCONEXTWorkShop.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var model = new List<AllProductViewModel>();
            var modelService = new ProductService();
            var products = modelService.GetProducts();
            foreach (var item in products)
            {
                var product = new AllProductViewModel();
                product.Id = item.Id;
                product.Image = String.Concat(Url.Content("~/Content/images/Product/"), item.Image, ".jpg");
                product.Title = item.Title;
                product.Price = item.Price;
                product.Balance = item.Balance;
                model.Add(product);
            }
            
                ViewData["CategoryId"] = 0;
            

            return View(model);
        }

        public ActionResult SearchProduct()
        {
            string searchText = Request.QueryString["searchText"] != null ? Request.QueryString["searchText"] : string.Empty;
            var model = new List<AllProductViewModel>();
            var modelService = new ProductService();
            var products = modelService.GetProducts();
            foreach (var item in products)
            {
                var product = new AllProductViewModel();
                product.Id = item.Id;
                product.Image = String.Concat(Url.Content("~/Content/images/Product/"), item.Image, ".jpg");
                product.Title = item.Title;
                product.Price = item.Price;
                product.Balance = item.Balance;

                if (((item.Title).ToLower()).Contains(searchText.ToLower()))
                {
                    model.Add(product);
                }
                ViewData["CategoryId"] = 0;
            }
            return View("Index", model);
        }

        [HttpPost]
        [LoginAuthorize]
        public ActionResult Cart(CartViewModel CartViewModel)
        {
            ShoppingCartModel cartModel = new ShoppingCartModel();
            cartModel.UserId = Convert.ToInt32(SessionManager.UserData.Id);
            cartModel.ProductId = CartViewModel.ProductId;
            cartModel.Quantity = CartViewModel.Quantity;
            ShoppingCartService cartService = new ShoppingCartService();
            if (cartService.PushToCart(cartModel))
            {
                JSONViewModel json = new JSONViewModel();
                json.Message = "Success";
                json.StatusCode = 200;
                return Json(json);
            }
            else
            {
                JSONViewModel json = new JSONViewModel();
                json.Message = "Fail to Add!";
                json.StatusCode = 500;
                return Json(json);
            }
            
            
        }

        [LoginAuthorize]
        public ActionResult CartStatus()
        {
            int Id = Convert.ToInt32(SessionManager.UserData.Id);
            JSONViewModel json = new JSONViewModel();

            if (Id != null)
            {
                ShoppingCartService cartService = new ShoppingCartService();
                json.Message = cartService.GetShoppingCart(Id).Count.ToString();
                json.StatusCode = 200;
            }
            else
            {
                json.Message = "Fail load total cart!";
                json.StatusCode = 500;   
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndexCategory(int Id)
        {
            var model = new List<AllProductViewModel>();
            var modelService = new ProductService();
            var products = modelService.GetProductsByCategory(Id);
            foreach (var item in products)
            {
                var product = new AllProductViewModel();
                product.Id = item.Id;
                product.Image = String.Concat(Url.Content("~/Content/images/Product/"), item.Image, ".jpg");
                product.Title = item.Title;
                product.Price = item.Price;
                product.Balance = item.Balance;
                model.Add(product);

            }
            ViewData["CategoryId"] = Id;
            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Category()
        {
            var model = new List<CategoryViewModel>();
            var modelService = new CategoryService();

            foreach (var categoryItem in modelService.GetCategory())
            {
                var category = new CategoryViewModel();
                category.Id = categoryItem.Id;
                category.name = categoryItem.name;
                model.Add(category);
            }

            return View("_Category", model);
        }
    }
}