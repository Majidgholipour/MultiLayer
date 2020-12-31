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
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDTO> CreateProduct(SaveProductDTO newProduct)
        {
            var productToCreate = _mapper.Map<SaveProductDTO, Product>(newProduct);
            await _unitOfWork.Products.AddAsync(productToCreate);
            await _unitOfWork.CommitAsync();

            var product = await GetProductById(productToCreate.Id);
            return product;

        }

        public async Task DeleteProduct(ProductDTO Product)
        {
            var productToRemove = _mapper.Map<ProductDTO, Product>(Product);
            _unitOfWork.Products.Remove(productToRemove);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var product = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return _mapper.Map<Product, ProductDTO>(product);

        }

        public async Task<ProductDTO> GetProductByCode(string code)
        {
            var product = await _unitOfWork.Products.GetProductByCode(code);
            return _mapper.Map<Product, ProductDTO>(product);

        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO ProductToBeUpdated, SaveProductDTO Product)
        {
            var newProduct = _mapper.Map<ProductDTO, Product>(ProductToBeUpdated);
            var newProductBasic = _mapper.Map<ProductDTO, Product>(ProductToBeUpdated);
            newProductBasic.Caption = newProduct.Caption;
            newProductBasic.Code = newProduct.Caption;
            await _unitOfWork.CommitAsync();

            return await GetProductById(newProduct.Id);
        }
    }
}
