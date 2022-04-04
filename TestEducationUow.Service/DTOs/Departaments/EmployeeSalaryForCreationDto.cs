using System;
using System.ComponentModel.DataAnnotations;
using TestEducationCenterUoW.Domain.Enums;

namespace TestEducationUow.Service.DTOs.Departaments
{
    public class EmployeeSalaryForCreationDto
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
