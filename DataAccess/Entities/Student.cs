using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Student : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Major { get; set; }
        public int YearlyPayment { get; set; }
        public int PaymentForMonth { get; set; }
        public int Remainder => YearlyPayment - PaymentForMonth;
    }
}