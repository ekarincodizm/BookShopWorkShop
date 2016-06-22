using System.Collections.Generic;
using BookModel;

namespace BookService.Interface
{
    public interface IProductService
    {
        ProductModel Get(int productId);
        List<ProductModel> GetProducts();
        List<ProductModel> GetProductsByCategory(int categoryId);

        bool UpdateBalance(int orderId, int balance);
        bool Delete(int productId);
    }
}