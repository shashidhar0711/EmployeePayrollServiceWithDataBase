using System;
using System.Collections.Generic;

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
            /// Creating references of object class
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.GetAllDataFromEmployeePayrollTable();
            //employeeRepo.GetAllDataFromDepartmentTable();
            //employeeRepo.GetAllDataFromSalaryTable();
            //employeeRepo.GettingAggregateSalaryofEachGender();
            //employeeRepo.GetEmployeeDataWithGiveRangeOnNewTable();

            EmployeePayrollOperation employeePayrollOperations = new EmployeePayrollOperation();
            List<EmployeeModel> employeePayrollDataList = new List<EmployeeModel>();
            employeePayrollOperations.AddEmployeeToPayroll(employeePayrollDataList);
        }
    }
}
