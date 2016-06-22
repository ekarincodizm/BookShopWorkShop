using BookDB;
using BookRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookRepository
{
    public class ShoppingReposity : IShoppingRepository
    {
        public bool AddItemCart(ShoppingCart shoppingCart)
        {
            using (var db = new IconextBookShopEntities())
            {
                var ifHaveInCart = db.ShoppingCarts.FirstOrDefault(x => x.ProductId == shoppingCart.ProductId && x.UserId == shoppingCart.UserId);
                if (ifHaveInCart != null)
                {
                    try
                    {
                        ifHaveInCart.Quantity += shoppingCart.Quantity;
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        var item = new ShoppingCart();
                        item.ProductId = shoppingCart.ProductId;
                        item.Quantity = shoppingCart.Quantity;
                        item.UserId = shoppingCart.UserId;
                        item.TimeStamp = DateTime.Now;
                        db.ShoppingCarts.Add(item);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public List<ShoppingCart> GetList(int Id)
        {
            using (var db = new IconextBookShopEntities())
            {
                var items = db.ShoppingCarts.Where(x => x.UserId == Id).Include(x => x.Product).Include(x => x.Product.Category);
                return items.ToList();
            }
        }


        public bool DeleteShoppingCart(int Id, int userId)
        {
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    var item = db.ShoppingCarts.FirstOrDefault(x => x.Id == Id && x.UserId == userId);

                    if (item != null && item.Quantity > 0)
                    {
                        db.ShoppingCarts.Remove(item);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateShoppingCartTotal(int id, int userid, int quantityTotal)
        {
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    var item = db.ShoppingCarts.FirstOrDefault(x => x.Id == id && x.UserId == userid);

                    if (item != null)
                    {
                        item.Quantity = quantityTotal;
                        item.TimeStamp = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public bool DeleteAllCart(int userId)
        {
            try
            {
                using (var db = new IconextBookShopEntities())
                {
                    var shoppingCarts = db.ShoppingCarts.Where(x => x.UserId == userId);
                    db.ShoppingCarts.RemoveRange(shoppingCarts);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}