using System.Collections.Generic;
using BookModel;

namespace BookService.Interface
{
    public interface ICategoryService
    {
        List<CategotyModel> GetCategory();
    }
}