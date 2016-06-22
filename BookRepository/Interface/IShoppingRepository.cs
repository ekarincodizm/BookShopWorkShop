using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;

namespace BookRepository.Interface
{
    public interface IShoppingRepository
    {
        bool AddItemCart(ShoppingCart shoppingCart);
        List<ShoppingCart> GetList(int Id);
        bool DeleteShoppingCart(int Id, int UserId);
        bool UpdateShoppingCartTotal(int id, int userid, int quantityTotal);

        bool DeleteAllCart(int userId);
    }
}


