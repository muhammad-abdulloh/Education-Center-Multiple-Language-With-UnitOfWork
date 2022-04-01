using System;
using System.ComponentModel.DataAnnotations;

namespace TestEducationUow.Service.DTOs.Departaments
{
    public class EmployeeSalaryForCreationDto
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public string PaymentType { get; set; }
    }
}
