using Project.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> GetProductByCode(string code);
        Task<ProductDTO> CreateProduct(SaveProductDTO newProduct);
        Task<ProductDTO> UpdateProduct(ProductDTO ProductToBeUpdated, SaveProductDTO Product);
        Task DeleteProduct(ProductDTO Product);
    }
}
