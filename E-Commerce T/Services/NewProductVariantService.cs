using E_Commerce_T.Data;
using E_Commerce_T.Data.Entities;
using E_Commerce_T.DTO.ResponseDTO;
using E_Commerce_T.DTO.ReuestDTO;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class NewProductVariantService
    {
        private readonly AppDbContext _context;
        public NewProductVariantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductVariant> AddProductVariant(NewProductVariantDTO req)
        {
            var IsProductExists = await _context.Products.AnyAsync(p => p.id == req.productId);
            if (!IsProductExists)
            {
                throw new InvalidOperationException("Product Id Not Found");
            }

            var IsColorExists = await _context.Colors.AnyAsync(p => p.id == req.colorId);
            if (!IsColorExists)
            {
                throw new InvalidOperationException("Color Id Not Found");
            }

            var IsSizeExists = await _context.Sizes.AnyAsync(p => p.id == req.sizeId);
            if (!IsSizeExists)
            {
                throw new InvalidOperationException("Size Id Not Found");
            }


            var productVariant = new ProductVariant
            {
                quantity = req.quantity,
                discountPercentage = req.discountPercentage,
                discountStartDate = req.discountStartDate,
                discountEndDate = req.discountEndDate,
                price = req.price,
                productId = req.productId,
                sizeId = req.sizeId,
                colorId = req.colorId,
                IsActive = req.IsActive

            };

            _context.ProductVariants.Add(productVariant);
            _context.SaveChangesAsync();

            return productVariant;
        }
    }
}
