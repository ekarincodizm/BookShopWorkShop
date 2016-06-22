using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;
using BookModel;

namespace BookService.Interface
{
    public interface IShoppingCart
    {
        bool PushToCart(ShoppingCartModel cartModel);
        List<ShoppingCartSummaryModel> GetShoppingCart(int Id);
        List<ShoppingCartDetailModel> GetShoppingCartDetail(int userId);
        bool DeleteCart(int Id, int UserId);
        bool UpdateTotalBookInCart(int id, int userid, int quantityTotal);
        bool DeleteAllCart(int userId);
    }
}
