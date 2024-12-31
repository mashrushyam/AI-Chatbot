
using PaymentService.DTOs;

namespace PaymentService.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetDuePaymentAsync(int userId);

    }
}
