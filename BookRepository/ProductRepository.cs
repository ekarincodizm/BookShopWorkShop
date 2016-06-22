using BookDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BookRepository
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int productId)
        {
            using (var db = new IconextBookShopEntities())
            {
                var product = db.Products.Include("Category").FirstOrDefault(x => x.Id == productId);

                return product;
            }
        }

        public System.Collections.Generic.List<Product> GetProducts()
        {
            using (var db = new IconextBookShopEntities())
            {
                var products = db.Products.Include("Category").ToList();
                return products;
            }
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            using (var db = new IconextBookShopEntities())
            {
                var products = db.Products.Where(x => x.CategoryId == categoryId).ToList();
                return products;
            }
        }

        public bool Save(Product product)
        {
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int productId)
        {
            bool isSuccess = true;
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    var product = db.Products.Where(x => x.Id == productId).FirstOrDefault();
                    product.IsActive = false;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;

        }

        public bool UpdateBalance(int productId, int balance)
        {
            using (var db = new IconextBookShopEntities())
            {
                var product = db.Products.FirstOrDefault(m => m.Id == productId);
                if (product != null)
                {
                    product.Balance = balance;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}