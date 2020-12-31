using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Core.Models;
using Project.Core.Repositories;

namespace Project.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context)
            : base(context)
        { }
      
        public async Task<IEnumerable<Product>> GetAllWithProductAsync()
        {
            return await MyDbContext.Products
                .ToListAsync();
        }

        public async Task<Product> GetWithProductByIdAsync(int id)
        {
            return await MyDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductByCode(string code)
        {
            return await MyDbContext.Products.SingleOrDefaultAsync(p => p.Code == code);
        }

        private MyDbContext MyDbContext
        {
            get { return Context as MyDbContext; }
        }
    }
}
