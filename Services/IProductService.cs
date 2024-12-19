using InventarioBackend.Data;
using InventarioBackend.DTOs;
using InventarioBackend.Models;

namespace InventarioBackend.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateProduct(ProductDto productDto);
        Task<ProductDto> UpdateProduct(int id, ProductDto productDto);
        Task<bool> DeleteProduct(int id);
    }

}
