using EmployeePayrollServiceWithDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmployeePayrollTest
{
    [TestClass]
    public class EmployeePayrollTest
    {
        /// <summary>
        /// Givens the data to update data base it should return if exis true.
        /// </summary>
        [TestMethod]
        public void GivenDataToUpdateDataBase_ItShouldReturnIfExisTrue()
        {
            /// Act
            EmployeeRepo employeeRepo = new EmployeeRepo();
            bool updateBasicPay = employeeRepo.UpdateTables("update Employee_Payroll SET basic_Pay = 3000000.00 where Id=3");
            /// Assert
            Assert.AreEqual(updateBasicPay, true);
        }

        /// <summary>
        /// Givens the employee when added to list should match employee entries.
        /// </summary>
        [TestMethod]
        public void GivenEmployee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
            employeeModelList.Add(new EmployeeModel { Name = "Sachin",Salary = 25000, Start = new System.DateTime(2020 - 11 - 27), Gender = 'M', Department = "Marketing", PhoneNumber = "8073121212",Address = "Vijay Nagar", Basic_Pay = 25000, Deductions = 1500, Taxable_Pay = 900, Income_Tax = 750, Net_Pay = 10000 });
            employeeModelList.Add(new EmployeeModel { Name = "Dhoni", Salary = 27000, Start = new System.DateTime(2020 - 09 - 07), Gender = 'M', Department = "Sales", PhoneNumber = "8089921212", Address = "Shanthi Nagar", Basic_Pay = 20000, Deductions = 1000, Taxable_Pay = 1900, Income_Tax = 1750, Net_Pay = 1000 });
            EmployeePayrollOperation employeePayrollOperation = new EmployeePayrollOperation();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperation.AddEmployeeToPayroll(employeeModelList);
            DateTime stoptDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: "+(stoptDateTime - startDateTime));
        }
    }
}
