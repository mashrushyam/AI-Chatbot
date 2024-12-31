using InsuranceService.Datas;
using InsuranceService.DTOs;
using InsuranceService.Interfaces;
using InsuranceService.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceService.Services
{
    public class InsuranceServices : IInsuranceService
    {
        private readonly InsuranceDbContext context;

        public InsuranceServices(InsuranceDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<InsuranceDto>> GetInsurancesDetailsAsync(int userId)
        {
            var insurance = await context.Insurances
                .Where(i => i.UserId == userId)
                .ToListAsync();

            var result = insurance.Select(a => new InsuranceDto
            {
                InsuranceName = a.InsuranceName,
                InsuranceEnd = a.InsuranceEnd,
                InsuranceStart = a.InsuranceStart,
                InsuranceStatus = a.InsuranceStatus,
            }).ToList();

            return result;
        }
    }
}
