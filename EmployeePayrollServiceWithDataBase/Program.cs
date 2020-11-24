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
            Console.WriteLine(employeeRepo.UpdateTables("update Employee_Payroll set Basic_Pay = 30000000.00 where Id=3"));
        }
    }
}
