using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class WorkingDaysViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public int? WorkingDays { get; set; }
    }
}