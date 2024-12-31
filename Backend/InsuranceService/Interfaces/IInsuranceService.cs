using InsuranceService.DTOs;

namespace InsuranceService.Interfaces
{
    public interface IInsuranceService
    {
        Task<IEnumerable<InsuranceDto>> GetInsurancesDetailsAsync(int userId);
    }
}
