using E_Commerce_T.Data;
using E_Commerce_T.Data.Entities;
using E_Commerce_T.DTO.ResponseDTO;
using E_Commerce_T.DTO.ReuestDTO;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class RegisterService
    {
        private readonly AppDbContext _context;
        public RegisterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AuthResDTO> RegisterNewUser (RegisterReqDTO NUser)
        {
            var EmailExists = await _context.Users.AnyAsync(u => u.email == NUser.email);
            if (EmailExists)
            {
                throw new InvalidOperationException("Email Address Already Exists");
            }

            var hashed_password = BCrypt.Net.BCrypt.HashPassword(NUser.password);

            User user = new User
            {
                userName = NUser.username,
                password = hashed_password,
                email = NUser.email,
                createdAt = DateTime.UtcNow,
                role = UserRole.User
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var res = new AuthResDTO
            {
                id = user.id,
                email = user.email,
                username = user.userName,
                token = String.Empty
            };

            return res;


        }
    }
}
