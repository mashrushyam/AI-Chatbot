using Microsoft.EntityFrameworkCore;
using PrescriptionService.Datas;
using PrescriptionService.DTOs;
using PrescriptionService.Interfaces;

namespace PrescriptionService.Services
{
    public class PrescriptionServices : IPrescriptionService
    {
        private readonly PrescriptionDbContext context;

        public PrescriptionServices(PrescriptionDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync(int userId)
        {
            var prescription = await context.Prescriptions
                .Where(i => i.UserId == userId)
                .ToListAsync();

            var result = prescription.Select(a => new PrescriptionDto
            {
                MedicineDosage = a.MedicineDosage,
                MedicineName = a.MedicineName,
                MedicineDirection = a.MedicineDirection,
            }).ToList();

            return result;
        }
    }
}
