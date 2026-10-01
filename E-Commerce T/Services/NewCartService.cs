using E_Commerce_T.Data;
using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class NewCartService
    {
        private AppDbContext _context;
        public NewCartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> NewCart(long userId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.id == userId);
            if(!userExists)
            {
                throw new ArgumentException($"User with ID {userId} does not exist.");
            }

            var newCart = new Cart
            {
                userId = userId,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };

            _context.Carts.Add(newCart);
            await _context.SaveChangesAsync();

            return newCart;
        }

    }
}
