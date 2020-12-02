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

            EmployeePayrollOperation employeePayrollOperation = new EmployeePayrollOperation();
            List<EmployeeModel> employeePayrollList = new List<EmployeeModel>();
            employeePayrollList.Add(new EmployeeModel { Name = "Sachin", Salary = 25000, Start = Convert.ToDateTime("2019-11-07"), Gender = 'M', Department = "Marketing", PhoneNumber = "8073121212", Address = "Vijay Nagar", Basic_Pay = 25000, Deductions = 1500, Taxable_Pay = 900, Income_Tax = 750, Net_Pay = 10000 });
            employeePayrollList.Add(new EmployeeModel { Name = "Dhoni", Salary = 27000, Start = Convert.ToDateTime("2018-10-17"), Gender = 'M', Department = "Sales", PhoneNumber = "8089921212", Address = "Shanthi Nagar", Basic_Pay = 20000, Deductions = 1000, Taxable_Pay = 1900, Income_Tax = 1750, Net_Pay = 1000 });
            //employeePayrollOperation.AddEmployeeToPayrollDataBase(employeePayrollList);
            //employeePayrollOperation.AddEmployeePayrollInToDataBaseUsingThread(employeePayrollList);
            employeePayrollOperation.AddEmployeePayrollInToDataBaseUsingSynchronization(employeePayrollList);
            Console.WriteLine("Added Succesfull ");

        }
    }
}
