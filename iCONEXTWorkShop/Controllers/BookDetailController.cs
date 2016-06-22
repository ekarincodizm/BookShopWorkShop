using System;
using System.Security.Policy;
using iCONEXTWorkShop.ViewModels;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookService;

namespace iCONEXTWorkShop.Controllers
{
    public class BookDetailController : Controller
    {
        public ActionResult Index(int Id)
        {
            var productService = new ProductService();
            var product = productService.Get(Id);
            var model = new BookDetailViewModel();
            model.Auther = product.Author;
            model.CategoryName = product.CategoryName;
            model.Detail = product.Detail;
            model.Image = String.Concat(Url.Content("~/Content/images/Product/"), product.Image, ".jpg");
            model.Isbn = product.Isbn;
            model.Price = product.Price;
            model.Title = product.Title;
            model.Balance = product.Balance;
            model.Id = product.Id;
            return View(model);
        }
    }
}