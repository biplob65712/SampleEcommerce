using SampleCommerce.Services;
using System.Diagnostics;

namespace SampleEcommerce.Examples
{
    public class CategoryResolver : ICategoryResolver
    {
        ICategoryService _categoryService; 
        public CategoryResolver(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            Debug.WriteLine($" Category Resolver -> Category Service Guid: {_categoryService.Guid}");
        }
    }
}
