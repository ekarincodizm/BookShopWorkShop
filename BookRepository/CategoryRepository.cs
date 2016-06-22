using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDB;
using BookRepository.Interface;

namespace BookRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategory()
        {
            using (var db = new IconextBookShopEntities())
            {
                var category = db.Categories.ToList();
                return category;
            }
        }
    }
}
