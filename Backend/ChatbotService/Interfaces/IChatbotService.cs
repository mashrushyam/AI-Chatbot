using ChatbotService.DTOs;

namespace ChatbotService.Interfaces
{
    public interface IChatbotService
    {
        //Task<string> SetAppointment(int userId, DateOnly appointmentDate, TimeOnly appointmentTime);
        Task<string> GetDuePayment(int userId);
        Task<string> GetPrescription(int userId);
        Task<string> GetInsuranceDetails(int userId);
    }
}
