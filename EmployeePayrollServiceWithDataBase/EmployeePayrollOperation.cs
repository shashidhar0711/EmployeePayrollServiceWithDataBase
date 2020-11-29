using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServiceWithDataBase
{
    public class EmployeePayrollOperation
    {
        public List<EmployeeModel> employeePayrollList = new List<EmployeeModel>();

        /// <summary>
        /// UC10 wihtout using threads
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        public void AddEmployeeToPayroll(List<EmployeeModel> employeePayrollList)
        {
            employeePayrollList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee Being Added: " + employeeData.Name);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.Name);
            });
            Console.WriteLine(this.employeePayrollList.ToString());
        }

        /// <summary>
        /// Adds the employee payroll into the other employee payroll
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        public void AddEmployeePayroll(EmployeeModel employeeModel)
        {
            employeePayrollList.Add(employeeModel);
        }
    }
}
