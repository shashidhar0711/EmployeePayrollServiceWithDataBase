using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollServiceWithDataBase
{
    /// <summary>
    /// Employee repo class to create connection
    /// </summary>
    public class EmployeeRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                /// Creating a references of employee model class
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    string query = "select * from Employee_Payroll";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    /// Opening connection
                    this.sqlConnection.Open();
                    /// Executing the sql query
                    SqlDataReader dataReader = command.ExecuteReader();
                    /// If not null
                    /// Read all data form database
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.Id = dataReader.GetInt32(0);
                            employeeModel.Name = dataReader.GetString(1);
                            employeeModel.Salary = dataReader.GetDecimal(2);
                            employeeModel.Start = dataReader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dataReader.GetString(4));
                            employeeModel.Department = dataReader.GetString(5);
                            employeeModel.PhoneNumber = dataReader.GetString(6);
                            employeeModel.Address = dataReader.GetString(7);
                            employeeModel.Basic_Pay = dataReader.GetDecimal(8);
                            employeeModel.Deductions = dataReader.GetDecimal(9);
                            employeeModel.Taxable_Pay = dataReader.GetDecimal(10);
                            employeeModel.Income_Tax = dataReader.GetDecimal(11);
                            employeeModel.Net_Pay = dataReader.GetDecimal(12);
                            Console.WriteLine(employeeModel.Id +" , "+ employeeModel.Name + " , " + employeeModel.Salary + " , " + employeeModel.Start + " , " +
                            employeeModel.Gender + " , " + employeeModel.Address + " , " + employeeModel.Department + " , " + employeeModel.PhoneNumber + " , " +
                            employeeModel.Basic_Pay + " , " + employeeModel.Deductions + " , " + employeeModel.Taxable_Pay + " , " + employeeModel.Income_Tax + " , " + employeeModel.Net_Pay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                    /// Closing connection
                    this.sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
