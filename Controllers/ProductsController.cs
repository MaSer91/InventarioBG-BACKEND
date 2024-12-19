using InventarioBackend.DTOs;
using InventarioBackend.Models;
using InventarioBackend.Services;
using Microsoft.AspNetCore.Mvc;
using InventarioBackend.Middleware;

namespace InventarioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("Error al obtener los productos", ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(new ErrorResponse("Producto no encontrado", $"No se encontró un producto con ID {id}"));
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var createdProduct = await _productService.CreateProduct(productDto);
                return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Name }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("Error al crear el producto", ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProduct(id, productDto);
                if (updatedProduct == null)
                {
                    return NotFound(new ErrorResponse("Producto no encontrado", $"No se encontró un producto con ID {id}"));
                }

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("Error al actualizar el producto", ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var deleted = await _productService.DeleteProduct(id);
                if (!deleted)
                {
                    return NotFound(new ErrorResponse("Producto no encontrado", $"No se encontró un producto con ID {id}"));
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("Error al eliminar el producto", ex.Message));
            }
        }
    }
}
