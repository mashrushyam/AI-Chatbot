using Microsoft.EntityFrameworkCore;
using PaymentService.Datas;
using PaymentService.DTOs;
using PaymentService.Interfaces;

namespace PaymentService.Services
{
    public class PaymentServices : IPaymentService
    {
        private readonly PaymentDbContext context;

        public PaymentServices(PaymentDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<PaymentDto>> GetDuePaymentAsync(int userId)
        {
            var payment = await context.Payments
                .Where(i => i.UserId == userId)
                .ToListAsync();

            var result = payment.Select(a => new PaymentDto
            {
                PaymentAmount = a.PaymentAmount,
                PaymentDue = a.PaymentDue,
                PaymentStatus = a.PaymentStatus,
            }).ToList();

            return result;
        }
    }
}
