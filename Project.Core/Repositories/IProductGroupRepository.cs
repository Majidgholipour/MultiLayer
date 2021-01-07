using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface IProductGroupRepository:IRepository<ProductGroup>
    {
        Task<ProductGroup> GetByCode(string Code);
    }
}
