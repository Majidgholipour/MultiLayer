using Microsoft.EntityFrameworkCore;
using Project.Core.Models;
using Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class ProductGroupRepository : Repository<ProductGroup>, IProductGroupRepository
    {
        private MyDbContext MyDbContext
        {
            get { return Context as MyDbContext; }
        }
        public ProductGroupRepository(MyDbContext context):base(context)
        {

        }
        public async Task<ProductGroup> GetByCode(string Code)
        {
            return await MyDbContext.ProductGroups.SingleOrDefaultAsync(p => p.Code == Code);
        }
    }
}
