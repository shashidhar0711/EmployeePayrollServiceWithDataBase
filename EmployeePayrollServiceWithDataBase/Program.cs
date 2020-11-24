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
            /// Writing sql query to delete data form employee payroll table and it returns false if exist
            Console.WriteLine(employeeRepo.DeleteDataFromTable("delete from Employee_Payroll where Id = 3"));

        }
    }
}
