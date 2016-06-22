using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BookDB;

namespace BookRepository
{
    public interface IProductRepository
    {
        Product Get(int productId);
        List<Product> GetProducts();
        List<Product> GetProductsByCategory(int categoryId);
        bool Save(Product product);
        bool UpdateBalance(int productId, int balance);
        bool Delete(int productId);

    }
}
