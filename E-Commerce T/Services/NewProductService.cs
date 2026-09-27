using E_Commerce_T.Data;
using E_Commerce_T.Data.Entities;
using E_Commerce_T.DTO.ResponseDTO;
using E_Commerce_T.DTO.ReuestDTO;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class NewProductService
    {
        private AppDbContext _context;
        public NewProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddNewProduct(NewProductReqDTO req)
        {

            var categoryExists = await _context.Categories.AnyAsync(p => p.id == req.categoryId);
            if (!categoryExists)
            {
                throw new InvalidOperationException("Not Valid Category");
            }

            var brandExists = await _context.Brand.AnyAsync(p => p.id == req.brandId);
            if (!brandExists)
            {
                throw new InvalidOperationException("Not Valid Brand");
            }

            var product = new Product
            {
                name = req.name,
                description = req.description,
                categoryId = req.categoryId,
                brandId = req.brandId,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            _context.SaveChangesAsync();

            return product;

        }  
    }
}
