using E_Commerce_T.Data;
using E_Commerce_T.DTO.ReuestDTO;

namespace E_Commerce_T.Services
{
    public class NewProductService
    {
        private AppDbContext _context;
        public NewProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<> AddNewProduct(NewProductReqDTO req)
        {

        }  
    }
}
