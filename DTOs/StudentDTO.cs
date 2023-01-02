using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "full name")]
        public string? FullName { get; set; }
        [Required]
        [Display(Name = "major")]
        public string? Major { get; set; }
        [Required]
        [Display(Name = "yearly payment")]
        public int YearlyPayment { get; set; }
        [Required]
        [Display(Name = "payment for month")]
        public int PaymentForMonth { get; set; }
        public int Remainder => YearlyPayment - PaymentForMonth;
    }
}