using BookDB;
using BookModel;
using BookRepository;
using BookService.Interface;
using System;
using System.Collections.Generic;

namespace BookService
{
    public class ShoppingCartService : IShoppingCart
    {
        public bool PushToCart(ShoppingCartModel cartModel)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ProductId = cartModel.ProductId;
            shoppingCart.Quantity = cartModel.Quantity;
            shoppingCart.UserId = cartModel.UserId;

            ShoppingReposity reposity = new ShoppingReposity();
            if (reposity.AddItemCart(shoppingCart))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ShoppingCartSummaryModel> GetShoppingCart(int Id)
        {
            List<ShoppingCartSummaryModel> shoppingCartList = new List<ShoppingCartSummaryModel>();
            ShoppingReposity shoppingReposity = new ShoppingReposity();

            foreach (var item in shoppingReposity.GetList(Id))
            {
                ShoppingCartSummaryModel shoppingCart = new ShoppingCartSummaryModel();
                shoppingCart.ProductId = item.Id;
                shoppingCart.UserId = item.UserId;
                shoppingCart.Author = item.Product.Author;
                shoppingCart.Image = item.Product.Image;
                shoppingCart.Price = item.Product.Price;
                shoppingCart.Quantity = item.Quantity;
                shoppingCart.Title = item.Product.Title;
                shoppingCart.Balance = item.Product.Balance;

                shoppingCartList.Add(shoppingCart);
            }

            return shoppingCartList;
        }

        public bool DeleteCart(int Id, int UserId)
        {
            ShoppingReposity shoppingReposity = new ShoppingReposity();
            return shoppingReposity.DeleteShoppingCart(Id, UserId) ? true : false;
        }

        public bool UpdateTotalBookInCart(int id, int userid, int quantityTotal)
        {
            try
            {
                ShoppingReposity shoppingReposity = new ShoppingReposity();
                return shoppingReposity.UpdateShoppingCartTotal(id, userid, quantityTotal) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAllCart(int userId)
        {
            try
            {
                ShoppingReposity shoppingCartRepository = new ShoppingReposity();
                return shoppingCartRepository.DeleteAllCart(userId) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ShoppingCartDetailModel> GetShoppingCartDetail(int userId)
        {
            var shoppingCartDetailModels = new List<ShoppingCartDetailModel>();
            ShoppingReposity shoppingReposity = new ShoppingReposity();

            foreach (var item in shoppingReposity.GetList(userId))
            {
                var shoppingCartDetail = new ShoppingCartDetailModel();
                shoppingCartDetail.Title = item.Product.Title;
                shoppingCartDetail.Author = item.Product.Author;
                shoppingCartDetail.CategoryName = item.Product.Category.Name;
                shoppingCartDetail.Detail = item.Product.Detail;
                shoppingCartDetail.Image = item.Product.Image;
                shoppingCartDetail.Isbn = item.Product.Isbn;
                shoppingCartDetail.Price = item.Product.Price;
                shoppingCartDetail.ProductId = item.ProductId;
                shoppingCartDetail.Quantity = item.Quantity;
                shoppingCartDetail.ProductBalance = item.Product.Balance;
                shoppingCartDetailModels.Add(shoppingCartDetail);
            }

            return shoppingCartDetailModels;
        }
    }
}