using SampleCommerce.Models.EntityModels;
using SampleCommerce.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleEFCore.Databases;

namespace SampleCommerce.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        
        public ProductRepository(SampleCommerceDbContext db)  : base(db)
        {
            
        }
    }
}
