using Authentication.Models;
using ChatbotService.DTOs;
using ChatbotService.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace ChatbotService.Services
{
    public class ChatbotServices : IChatbotService
    {
        private readonly IHttpClientFactory factory;

        public ChatbotServices(IHttpClientFactory factory)
        {
            this.factory = factory;
        }
        public async Task<string> GetDuePayment(int userId)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5003/api/Payment/{userId}");
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetInsuranceDetails(int userId)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5004/api/Insurance/{userId}");
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> GetPrescription(int userId)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5002/api/Prescription/{userId}");
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        //public async Task<string> SetAppointment(int userId, DateOnly appointmentDate, TimeOnly appointmentTime)
        //{
        //    var client = factory.CreateClient();
        //    var requestBody = new
        //    {
        //        userId = userId,
        //        appointmentDate = appointmentDate,
        //        appointmentTime = appointmentTime
        //    };

        //    var jsonRequest = JsonConvert.SerializeObject(requestBody);
        //    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        //    var response = await client.PostAsync("https://localhost:5005/api/Appointment", content);
        //    var result = await response.Content.ReadAsStringAsync();
        //    return result;
        //}
    }
}
