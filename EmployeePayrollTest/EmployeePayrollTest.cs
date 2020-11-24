using EmployeePayrollServiceWithDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
