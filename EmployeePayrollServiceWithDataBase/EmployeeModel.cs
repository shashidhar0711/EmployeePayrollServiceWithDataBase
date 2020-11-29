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
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
        public string Location { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeModel"/> class.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Salary">The salary.</param>
        /// <param name="Start">The start.</param>
        /// <param name="Gender">The gender.</param>
        /// <param name="Department">The department.</param>
        /// <param name="DepartmentNumber">The department number.</param>
        /// <param name="PhoneNumber">The phone number.</param>
        /// <param name="Address">The address.</param>
        /// <param name="SalaryId">The salary identifier.</param>
        /// <param name="Basic_Pay">The basic pay.</param>
        /// <param name="Deductions">The deductions.</param>
        /// <param name="Taxable_Pay">The taxable pay.</param>
        /// <param name="Income_Tax">The income tax.</param>
        /// <param name="Net_Pay">The net pay.</param>
        /// <param name="Location">The location.</param>
        public EmployeeModel(int Id,string Name,decimal Salary,DateTime Start, char Gender, string Department,int DepartmentNumber,string PhoneNumber,
            string Address,int SalaryId,decimal Basic_Pay,decimal Deductions,decimal Taxable_Pay,decimal Income_Tax,decimal Net_Pay,string Location)
        {
            this.Id = Id;
            this.Name = Name;
            this.Salary = Salary;
            this.Start = Start;
            this.Gender = Gender;
            this.Department = Department;
            this.DepartmentNumber = DepartmentNumber;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.SalaryId = SalaryId;
            this.Basic_Pay = Basic_Pay;
            this.Deductions = Deductions;
            this.Taxable_Pay = Taxable_Pay;
            this.Income_Tax = Income_Tax;
            this.Net_Pay = Net_Pay;
            this.Location = Location;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeModel"/> class.
        /// </summary>
        public EmployeeModel()
        {
        }
    }
}
