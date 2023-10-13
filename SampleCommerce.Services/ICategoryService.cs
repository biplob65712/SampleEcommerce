using SampleCommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommerce.Services
{
    public interface ICategoryService
    {
        public Guid Guid { get; set; }
        ICollection<Category> Get(Expression<Func<Category, bool>> predicate = null);
    }
}
