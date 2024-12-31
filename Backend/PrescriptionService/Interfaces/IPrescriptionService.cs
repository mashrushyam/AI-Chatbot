using PrescriptionService.DTOs;

namespace PrescriptionService.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(int userId);

    }
}
