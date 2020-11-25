using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServiceWithDataBase
{
    /// <summary>
    /// Getters and setters
    /// </summary>
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Start { get; set; }
        public char Gender { get; set; }
        public string Department { get; set; }
        public int DepartmentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int SalaryId { get; set; }
        public decimal Basic_Pay { get; set; }
        public decimal BasicSalaryPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
        public string Location { get; set; }
    }
}
