using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BookModel;
using BookService;
using iCONEXTWorkShop.ViewModels;

namespace iCONEXTWorkShop.Controllers
{
    public class ManageProductController : Controller
    {
        public ActionResult AddBook()
        {
            var categoryService = new CategoryService();
            var categories = categoryService.GetCategory();
            var model = new AddProductViewModel();
            model.Categories = new List<SelectListItem>();
            foreach (var item in categories)
            {
                model.Categories.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.name });
            }
            return View(model);
        }

        private HttpContext context = System.Web.HttpContext.Current;
        [HttpPost]
        public ActionResult AddBook(HttpPostedFileBase file, AddProductViewModel model)
        {
            Session["Username"] = "Admin";
            var userName = Session["Username"];
            var imagePath = CreateMD5(model.Title + DateTime.Now + DateTime.Now.Millisecond + model.Detail) ;
            
            var addViewModel = new ProductModel();
            addViewModel.Title = model.Title;
            addViewModel.Author = model.Author;
            addViewModel.Image = imagePath;
            addViewModel.Detail = model.Detail;
            addViewModel.Balance = model.Balance;
            addViewModel.Isbn = model.Isbn;
            addViewModel.Price = model.Price;
            addViewModel.CategoryId = model.CategoryId;
            addViewModel.CreateBy = userName.ToString();
            addViewModel.CreateTime = DateTime.Now;
            addViewModel.UpdateBy = "Test Admin";
            addViewModel.UpdateTime = DateTime.Now;
            addViewModel.IsActive = true;

            bool uploadImageIsComplete = true;
            if (file != null && file.ContentLength > 0)
                try
                {
                    var fileName = imagePath + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/Content/images/Product/"), fileName);
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    uploadImageIsComplete = false;
                }
            else
            {
                uploadImageIsComplete = false;
            }


            if (uploadImageIsComplete)
            {
                ProductService productService = new ProductService();
                if (productService.Save(addViewModel))
                {
                    // return RedirectToRoute("~Success");
                }
                else
                {
                   // return RedirectToRoute("~Error");
                }
            }

            return RedirectToAction("ManageProductView", "ManageProduct");
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        public ActionResult ManageProductView()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            ProductService productService = new ProductService();
            productModels = productService.GetProducts();

            List<ManageProductViewModel> manageProductViewModels = new List<ManageProductViewModel>();
            foreach (var item in productModels)
            {
                var manageProductViewModel = new ManageProductViewModel();
                manageProductViewModel.Id = item.Id;
                manageProductViewModel.Title = item.Title;
                manageProductViewModel.Author = item.Author;
                manageProductViewModel.CategoryName = item.CategoryName;
                manageProductViewModel.Price = item.Price;
                manageProductViewModel.Balance = item.Balance;
                manageProductViewModel.IsActive = item.IsActive;

                manageProductViewModels.Add(manageProductViewModel);
            }

            return View("ManageProductView", manageProductViewModels);
        }


        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            ProductService productService = new ProductService();
            ProductModel productModel = new ProductModel();
            productModel = productService.Get(productId);
            var image = productModel.Image + ".jpg";

            if (productService.Delete(productId))
            {
                //DeleteImageOnServer(image);
            }

            return RedirectToAction("ManageProductView","ManageProduct");
        }

        private void DeleteImageOnServer(string image)
        {
            string fullPath = Request.MapPath("~/Content/images/Product/" + image);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            ProductService productService = new ProductService();
            EditProductViewModel editProductViewModel = new EditProductViewModel();
            ProductModel productModel = new ProductModel();
            productModel = productService.Get(productId);

            editProductViewModel.Id = productModel.Id;
            editProductViewModel.Title = productModel.Title;
            editProductViewModel.Author = productModel.Author;
            editProductViewModel.Price = productModel.Price;
            editProductViewModel.Balance = productModel.Balance;
            editProductViewModel.Detail = productModel.Detail;
            editProductViewModel.Isbn = productModel.Isbn;
            editProductViewModel.UpdateBy = productModel.UpdateBy;
            editProductViewModel.UpdateTime = productModel.UpdateTime;
            editProductViewModel.Image = productModel.Image;
            editProductViewModel.CategoryId = productModel.CategoryId;

            //var model = new AddProductViewModel();
            CategoryService categoryService = new CategoryService();
            List<CategotyModel> categorys = new List<CategotyModel>();
            categorys = categoryService.GetCategory();


            return View(editProductViewModel);
        }
    }
}