using Microsoft.EntityFrameworkCore;
using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository; 

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            if(Guid == Guid.Empty)
            {
                Guid = Guid.NewGuid();
            }
            
        }

        public Guid Guid { get; set; }

        public ICollection<Category> Get(Expression<Func<Category, bool>> predicate = null)
        {
            return _categoryRepository.Get(predicate);
        }
    }
}
