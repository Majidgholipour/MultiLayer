using AutoMapper;
using Project.Core;
using Project.Core.DTO;
using Project.Core.IServices;
using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDTO> CreateArtist(SaveProductDTO newProduct)
        {
            var productToCreate = _mapper.Map<SaveProductDTO, Product>(newProduct);
            await _unitOfWork.Products.AddAsync(productToCreate);
            await _unitOfWork.CommitAsync();

            var product = await GetArtistById(productToCreate.Id);
            return product;

        }

        public async Task DeleteArtist(ProductDTO Product)
        {
            var productToRemove = _mapper.Map<ProductDTO, Product>(Product);
             _unitOfWork.Products.Remove(productToRemove);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllArtists()
        {
            var product = _unitOfWork.Products.GetAllAsync();
            return  _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
        }

        public Task<ProductDTO> GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateArtist(ProductDTO ProductToBeUpdated, SaveProductDTO Product)
        {
            throw new NotImplementedException();
        }
    }
}
