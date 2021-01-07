using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Validators;
using Project.Core.DTO;
using Project.Core.IServices;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupsService _productGroupsService;

        public ProductGroupController(IProductGroupsService productGroupsService)
        {
            _productGroupsService = productGroupsService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductGroupDTO>>> GetAllProductGroup()
        {
            var product = await _productGroupsService.GetAllProductGroups();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupDTO>> GetProductById(int id)
        {
            var product = await _productGroupsService.GetProductGroupById(id);
            return Ok(product);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ProductGroupDTO>> GetProductByCode(string code)
        {
            var product = await _productGroupsService.GetProductGroupByCode(code);
            return Ok(product);
        }

        [HttpPost("")]
        public async Task<ActionResult<SaveProductDTO>> CreateProductGroup([FromBody] SaveProductGroupDTO saveProductGroupDTO)
        {
            var validator = new SaveProductGroupDTOValidator();
            var validateResult =await validator.ValidateAsync(saveProductGroupDTO);

            if (!validateResult.IsValid)
                return BadRequest(validateResult.Errors);

            var product = _productGroupsService.CreateProductGroup(saveProductGroupDTO);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductGroupDTO>> UpdateProductGroup(int id,[FromBody] SaveProductGroupDTO saveProductGroupDTO )
        {
            var validator = new SaveProductGroupDTOValidator();
            var validateResult = await validator.ValidateAsync(saveProductGroupDTO);

            if (!validateResult.IsValid)
                return BadRequest(validateResult.Errors);

            var productGroupToBeUpdate = await _productGroupsService.GetProductGroupById(id);

            if (productGroupToBeUpdate == null)
                return BadRequest();

            var UpdatedProductDTO = await _productGroupsService.UpdateProductGroup(productGroupToBeUpdate, saveProductGroupDTO);
            return Ok(UpdatedProductDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductGroups(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productGroupsService.GetProductGroupById(id);
            if (product == null)
                return BadRequest();

            await _productGroupsService.DeleteProductGroup(product);
            return NoContent();
        }
    }
}
