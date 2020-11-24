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
            /// Writing sql query to find sum ,average, minimum, maximum, count of salary 
            employeeRepo.SumOfSalaryByGender("select Gender,Sum(Salary) as 'Sum of Salary' from Employee_Payroll where Gender = 'M' group by Gender");
            employeeRepo.AverageSalaryByGender("select Gender,Avg(Salary) as 'Average of Salary' from Employee_Payroll where Gender = 'M' group by Gender");
            employeeRepo.MinimumSalaryByGender("select Gender,Min(Salary) as 'Maximum of Salary' from Employee_Payroll where Gender = 'M' group by Gender");
            employeeRepo.MaximumSalaryByGender("select Gender,Max(Salary) as 'Minimum of Salary' from Employee_Payroll where Gender = 'M' group by Gender");
            employeeRepo.CountSalaryByGender("select Gender,Count(Salary) as 'Number of count' from Employee_Payroll where Gender = 'M' group by Gender");

        }
    }
}
