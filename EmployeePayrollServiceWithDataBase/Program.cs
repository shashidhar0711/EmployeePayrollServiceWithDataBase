using System;

namespace EmployeePayrollServiceWithDataBase
{
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.GetEmployeeDataWithGiveRange("select * from Employee_Payroll where start between cast('2019-01-01' as date) and SYSDATETIME()");
        }
    }
}
