using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspnet_rest_api.data.Model;

namespace aspnet_rest_api.data.Dao
{
   public  class DbProductRepository : ProductRepository
    {
        public async Task<Product> FindById(long id)
        {
            using (var context = new ProductContext()) {
                return await context.Products.FindAsync(id);
            }
        }
         
        public IList<long> GetAllIds()
        {
            using(var context = new ProductContext()) {
                return context.Products.Select( o => o.Id).ToList();
            }
        }

        public async Task SaveAsync(List<Product> products)
        {
            using (var context = new ProductContext())
            {
                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
