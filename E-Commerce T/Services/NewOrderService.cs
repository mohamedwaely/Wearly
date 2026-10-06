using E_Commerce_T.Data;
using E_Commerce_T.Data.Entities;
using E_Commerce_T.DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_T.Services
{
    public class NewOrderService
    {
        private AppDbContext _context;
        public NewOrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NewOrderResDTO> makeOrder(long userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.userId == userId);
            if (cart == null)
            {
                throw new InvalidDataException("Cart not found for the userId");
            }

            var cartItems = await _context.CartItems
                .Where(ci => ci.cartId == cart.id)
                .Include(ci => ci.productVariant)
                    .ThenInclude(pv => pv.color)
                .Include(ci => ci.productVariant)
                    .ThenInclude(pv => pv.size)
                .Include(ci => ci.productVariant)
                    .ThenInclude(pv => pv.product)
                .ToListAsync();

            if (!cartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty for the userId");
            }

            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.userId == userId);
            if (address == null)
            {
                throw new InvalidOperationException("Address not found for the userId");
            }

            foreach (var item in cartItems)
            {
                if (item.quantity > item.productVariant.quantity)
                {
                    throw new InvalidOperationException(
                        $"Not enough stock for '{item.productVariant.product.name}' " +
                        $"({item.productVariant.color.name}, {item.productVariant.size.name}). " +
                        $"Available: {item.productVariant.quantity}, Requested: {item.quantity}");
                }
            }

            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    userId = userId,
                    AddressId = address.id,
                    orderedAt = DateTime.UtcNow,
                    updatedAt = DateTime.UtcNow,
                    status = OrderStatus.Pending,
                    orderItems = new List<OrderItems>()
                };

                decimal total = 0;
                foreach(var item in cartItems)
                {
                    var PVariant = item.productVariant;
                    var VariantPrice = GetCurrentPrice(PVariant);

                    order.orderItems.Add(new OrderItems
                    {
                        productVariantId = PVariant.id,
                        quantity = item.quantity,
                        Price = VariantPrice,
                        ProductName = PVariant.product.name,
                        ColorName = PVariant.color.name,
                        SizeName = PVariant.size.name
                    });
                    total += VariantPrice * item.quantity;
                    PVariant.quantity -= item.quantity;
                }

                order.TotalAmount = total;

                await _context.Orders.AddAsync(order);
                _context.CartItems.RemoveRange(cartItems);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new NewOrderResDTO
                {
                    id = order.id,
                    status = order.status.ToString(),
                    totalAmount = order.TotalAmount,
                    orderedAt = order.orderedAt,
                    itemCount = order.orderItems.Count
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        private decimal GetCurrentPrice(ProductVariant PVariant)
        {
            var now = DateTime.UtcNow;
            var discountActive = PVariant.discountPercentage.HasValue &&
                                 PVariant.discountStartDate.HasValue &&
                                 PVariant.discountEndDate.HasValue &&
                                 now >= PVariant.discountStartDate.Value &&
                                 now <= PVariant.discountEndDate.Value;
            if(!discountActive)
            {
                return PVariant.price;
            }
            else
            {
                var discountAmount = PVariant.price * (PVariant.discountPercentage!.Value / 100);
                return PVariant.price - discountAmount;
            }

        }



    }
}
