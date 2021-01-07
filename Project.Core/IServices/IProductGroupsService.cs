using Project.Core.DTO;
using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.IServices
{
   public interface IProductGroupsService
    {
        Task<IEnumerable<ProductGroupDTO>> GetAllProductGroups();
        Task<ProductGroupDTO> GetProductGroupById(int id);
        Task<ProductGroupDTO> GetProductGroupByCode(string code);
        Task<ProductGroupDTO> CreateProductGroup(SaveProductGroupDTO newProductGroup);
        Task<ProductGroupDTO> UpdateProductGroup(ProductGroupDTO ProductToBeUpdated, SaveProductGroupDTO ProductGroup);
        Task DeleteProductGroup(ProductGroupDTO ProductGroup);
    }
}
