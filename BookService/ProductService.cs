using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookDB;
using BookModel;
using BookRepository;
using BookService.Interface;

namespace BookService
{
    public class ProductService : IProductService
    {
        public ProductModel Get(int productId)
        {
            var productRepository = new ProductRepository();
            var modelProductRepository = productRepository.Get(productId);
            var model = new ProductModel();
            model.Title = modelProductRepository.Title;
            model.Author = modelProductRepository.Author;
            model.Balance = modelProductRepository.Balance;
            model.CategoryId = modelProductRepository.CategoryId;
            model.CreateBy = modelProductRepository.CreateBy;
            model.CreateTime = modelProductRepository.CreateTime;
            model.Detail = modelProductRepository.Detail;
            model.Id = modelProductRepository.Id;
            model.Image = modelProductRepository.Image;
            model.IsActive = modelProductRepository.IsActive;
            model.Isbn = modelProductRepository.Isbn;
            model.Price = modelProductRepository.Price;
            model.UpdateBy = modelProductRepository.UpdateBy;
            //model.UpdateTime = modelProductRepository.UpdateTime;
            model.CategoryName = modelProductRepository.Category.Name;
            return model;
        }

        public List<ProductModel> GetProducts()
        {
            var productRepository = new ProductRepository();
            var modelProductsRepository = productRepository.GetProducts();
            var model = new List<ProductModel>();
            foreach (var item in modelProductsRepository)
            {
                var productModel = new ProductModel();
                productModel.Title = item.Title;
                productModel.Author = item.Author;
                productModel.Balance = item.Balance;
                productModel.CategoryId = item.CategoryId;
                productModel.CategoryName = item.Category.Name;
                productModel.CreateBy = item.CreateBy;
                productModel.CreateTime = item.CreateTime;
                productModel.Detail = item.Detail;
                productModel.Id = item.Id;
                productModel.Image = item.Image;
                productModel.IsActive = item.IsActive;
                productModel.Isbn = item.Isbn;
                productModel.Price = item.Price;
                productModel.UpdateBy = item.UpdateBy;
                productModel.UpdateTime = item.UpdateTime;
                model.Add(productModel);
            }
            return model;
        }


        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            var productRepository = new ProductRepository();
            var modelProductsRepository = productRepository.GetProductsByCategory(categoryId);
            var model = new List<ProductModel>();
            foreach (var item in modelProductsRepository)
            {
                var productModel = new ProductModel();
                productModel.Title = item.Title;
                productModel.Author = item.Author;
                productModel.Balance = item.Balance;
                productModel.CategoryId = item.CategoryId;
                productModel.CreateBy = item.CreateBy;
                productModel.CreateTime = item.CreateTime;
                productModel.Detail = item.Detail;
                productModel.Id = item.Id;
                productModel.Image = item.Image;
                productModel.IsActive = item.IsActive;
                productModel.Isbn = item.Isbn;
                productModel.Price = item.Price;
                productModel.UpdateBy = item.UpdateBy;
                productModel.UpdateTime = item.UpdateTime;
                model.Add(productModel);
            }
            return model;
        }

        public bool Delete(int productId)
        {
            ProductRepository productRepository = new ProductRepository();
            
            return productRepository.Delete(productId);
	}
        public bool UpdateBalance(int orderId, int balance)
        {
            var productRepository = new ProductRepository();
            return productRepository.UpdateBalance(orderId, balance);
        }

        public bool Save(ProductModel product)
        {
            ProductRepository productRepository = new ProductRepository();
            Product model = new Product();
            model.Title = product.Title;
            model.Author = product.Author;
            model.Image = product.Image;
            model.Detail = product.Detail;
            model.Balance = product.Balance;
            model.Isbn = product.Isbn;
            model.Price = product.Price;
            model.CategoryId = product.CategoryId;
            model.CreateBy = product.CreateBy;
            model.CreateTime = product.CreateTime;
            model.UpdateBy = product.UpdateBy;
            model.UpdateTime = product.UpdateTime;
            model.IsActive = product.IsActive;

            if (productRepository.Save(model))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}