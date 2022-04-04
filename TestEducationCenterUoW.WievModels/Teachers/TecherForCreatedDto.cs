using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducationCenterUoW.WievModels.Teachers
{
    public class TecherForCreatedDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public IFormFile Image { get; set; }
    }
}
