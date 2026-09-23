using E_Commerce_T.Data;
using E_Commerce_T.DTO.Jwt;
using E_Commerce_T.DTO.ResponseDTO;
using E_Commerce_T.DTO.ReuestDTO;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class LoginService
    {
        private readonly AppDbContext _context;
        private JwtCon _JwtCon;
        public LoginService(AppDbContext context, JwtCon jwtCon)
        {
            _context = context;
            _JwtCon = jwtCon;
        }

        public async Task<AuthResDTO> loginS(LoginReqDTO req)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == req.email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(req.password, user.password))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }


            var token = _JwtCon.GenerateToken(user);

            var response = new AuthResDTO
            {
                id = user.id,
                username = user.userName,
                email = user.email,
                token = token
            };

            return response;

        }


    }
}
