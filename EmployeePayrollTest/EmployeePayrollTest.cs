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
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            EmployeePayrollOperation employeePayrollOperation = new EmployeePayrollOperation();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperation.AddEmployeeToPayroll(employeeModel);
            DateTime stoptDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: "+(stoptDateTime - startDateTime));
        }
    }
}
