using E_Commerce_T.Data;
using E_Commerce_T.Data.Entities;
using E_Commerce_T.DTO.ResponseDTO;
using E_Commerce_T.DTO.ReuestDTO;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class NewCartItemService
    {
        private AppDbContext _context;
        public NewCartItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NewCartItemRes> AddCartItem(NewCartItemReq req)
        {
            var CartExists = await _context.Carts.FirstOrDefaultAsync(c => c.id == req.cartId);
            if(CartExists==null)
            {
                throw new InvalidOperationException("Cart does not exist");
            }

            var ProductVarExists = await _context.ProductVariants.FirstOrDefaultAsync(p => p.id == req.productVariantId);
            if (ProductVarExists == null)
            {
                throw new InvalidOperationException("Product variant does not exist");
            }

            var nCatItem = new CartItems
            {
                cartId = req.cartId,
                productVariantId = req.productVariantId,
                quantity = req.quantity
            };


            _context.CartItems.Add(nCatItem);
            await _context.SaveChangesAsync();

            var res = new NewCartItemRes
            {
                id = nCatItem.id,
                cartId = nCatItem.cartId,
                productVariantId = nCatItem.productVariantId,
                quantity = nCatItem.quantity
            };


            return res;



        }


    }
}
