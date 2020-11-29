using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollServiceWithDataBase
{
    public class EmployeePayrollOperation
    {
        /// <summary>
        /// Establishing the connection string
        /// </summary>
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

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
                this.AddEmployee(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.Name);
            });
            Console.WriteLine(this.employeePayrollList.ToString());
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Salary", model.Salary);
                    command.Parameters.AddWithValue("@Start", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    command.Parameters.AddWithValue("@Income_Tax", model.Income_Tax);
                    command.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
                    this.sqlConnection.Open();
                    /// It used to executing queries that does not return any data.
                    var result = command.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                /// Connections closes
                this.sqlConnection.Close();
            }
            return false;
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
