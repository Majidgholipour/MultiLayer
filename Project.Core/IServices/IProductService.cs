using Project.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllArtists();
        Task<ProductDTO> GetArtistById(int id);
        Task<ProductDTO> CreateArtist(SaveProductDTO newProduct);
        Task<ProductDTO> UpdateArtist(ProductDTO ProductToBeUpdated, SaveProductDTO Product);
        Task DeleteArtist(ProductDTO Product);
    }
}
