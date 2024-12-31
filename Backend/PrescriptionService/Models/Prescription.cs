﻿using System.ComponentModel.DataAnnotations;

namespace PrescriptionService.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int UserId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineDosage { get; set; }
        public string MedicineDirection { get; set; }
    }
}
