using BookModel;
using BookRepository;
using BookService.Interface;
using System.Collections.Generic;

namespace BookService
{
    public class CategoryService : ICategoryService
    {
        public List<CategotyModel> GetCategory()
        {
            var categoryRepository = new CategoryRepository();
            var modelCategoryRepository = categoryRepository.GetCategory();
            var model = new List<CategotyModel>();
            foreach (var item in modelCategoryRepository)
            {
                var categoryModel = new CategotyModel();
                categoryModel.Id = item.Id;
                categoryModel.name = item.Name;
                model.Add(categoryModel);
            }
            return model;
        }
    }
}