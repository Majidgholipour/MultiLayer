using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Validators;
using Project.Core.DTO;
using Project.Core.IServices;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProduct()
        {
            var product = await _productService.GetAllProducts();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("code")]
        public async Task<ActionResult<ProductDTO>> GetProductByCode(string code)
        {
            var product = await _productService.GetProductByCode(code);
            return Ok(product);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] SaveProductDTO saveProductDTO)
        {
            var validator = new SaveProductDTOValidator();
            var validateResult = await validator.ValidateAsync(saveProductDTO);

            if (!validateResult.IsValid)
                return BadRequest(validateResult.Errors);

            var product = await _productService.CreateProduct(saveProductDTO);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id,[FromBody] SaveProductDTO saveProductDTO)
        {
            var validator = new SaveProductDTOValidator();
            var validatorResult = await validator.ValidateAsync(saveProductDTO);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var productToBeUpdate = await _productService.GetProductById(id);

            if (productToBeUpdate == null)
                return BadRequest();

            var UpdatedProductDTO = await _productService.UpdateProduct(productToBeUpdate, saveProductDTO);
            return Ok(UpdatedProductDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productService.GetProductById(id);
            if (product == null)
                return BadRequest();

            await _productService.DeleteProduct(product);
            return NoContent();
        }
    }
}
