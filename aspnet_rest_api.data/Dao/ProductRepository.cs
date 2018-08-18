using aspnet_rest_api.data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_rest_api.data.Dao
{
    public interface ProductRepository
    {
        IList<long> GetAllIds();
        Task SaveAsync(List<Product> products);
        Task<Product> FindById(long id);
    }
}
