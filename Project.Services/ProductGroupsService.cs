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
    public class ProductGroupsService : IProductGroupsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductGroupsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductGroupDTO> CreateProductGroup(SaveProductGroupDTO newProductGroup)
        {
            try
            {
                var productGroupsToCreate = _mapper.Map<SaveProductGroupDTO, ProductGroup>(newProductGroup);
                await _unitOfWork.productGroups.AddAsync(productGroupsToCreate);
                await _unitOfWork.CommitAsync();

                var productGroups = await GetProductGroupById(productGroupsToCreate.Id);
                return productGroups;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task DeleteProductGroup(ProductGroupDTO ProductGroup)
        {
            var productGroupToRemove = _mapper.Map<ProductGroupDTO, ProductGroup>(ProductGroup);
            _unitOfWork.productGroups.Remove(productGroupToRemove);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProductGroupDTO>> GetAllProductGroups()
        {
            var productGroup = await _unitOfWork.productGroups.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductGroup>, IEnumerable<ProductGroupDTO>>(productGroup);
        }

        public async Task<ProductGroupDTO> GetProductGroupByCode(string code)
        {
            var productGroup = await _unitOfWork.productGroups.GetByCode(code);
            return _mapper.Map<ProductGroup, ProductGroupDTO>(productGroup);
        }

        public async Task<ProductGroupDTO> GetProductGroupById(int id)
        {
            var productGroup = await _unitOfWork.productGroups.GetByIdAsync(id);
            return _mapper.Map<ProductGroup, ProductGroupDTO>(productGroup);
        }

        public async Task<ProductGroupDTO> UpdateProductGroup(ProductGroupDTO ProductToBeUpdated, SaveProductGroupDTO ProductGroup)
        {
            var newProduct = _mapper.Map<SaveProductGroupDTO, ProductGroup>(ProductGroup);
            var newProductBasic  = _mapper.Map<ProductGroupDTO, ProductGroup>(ProductToBeUpdated);

            newProductBasic.Caption = newProduct.Caption;
            newProductBasic.Code = newProduct.Code;

            await _unitOfWork.CommitAsync();

            return await GetProductGroupById(newProduct.Id);
        }
    }
}
