using aspnet_rest_api.data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_rest_api.data.Dao
{
    class ProductDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var products = new List<Product>
            {
            new Product() { Name ="Guitar", Quantity=30, SalesAmount=10},
            new Product() { Name ="Amp", Quantity=20, SalesAmount=5}
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges(); 
        }
    }
}
