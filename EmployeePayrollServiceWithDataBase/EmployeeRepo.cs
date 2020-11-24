using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
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
                            Console.WriteLine();
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

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
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
                    command.Parameters.AddWithValue("@Start", model.Start);
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
        }

        /// <summary>
        /// Updates the tables.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool UpdateTables(string updateQuery)
        {
            using (this.sqlConnection)
            {
                try
                {
                    /// Connections opens
                    this.sqlConnection.Open();
                    SqlCommand command = this.sqlConnection.CreateCommand();
                    /// Gets or sets the sql statement to execute at the data base
                    command.CommandText = updateQuery;
                    /// It used to executing queries that does not return any data.
                    /// Instead returns the number of rows affected.
                    int numberOfAffectedRows = command.ExecuteNonQuery();
                    if (numberOfAffectedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    /// Connections closes
                    this.sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Gets the employee data with give range.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <exception cref="Exception"></exception>
        public void GetEmployeeDataWithGiveRange(string updateQuery)
        {
            try
            {
                /// Creating a references of employee model class
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    //string updateQuery = "select * from Employee_Payroll where start between cast('2019-01-01' as date) and SYSDATETIME()";
                    SqlCommand command = new SqlCommand(updateQuery, this.sqlConnection);
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

                            Console.WriteLine(employeeModel.Id + " , " + employeeModel.Name + " , " + employeeModel.Salary + " , " + employeeModel.Start + " , " +
                            employeeModel.Gender + " , " + employeeModel.Address + " , " + employeeModel.Department + " , " + employeeModel.PhoneNumber + " , " +
                            employeeModel.Basic_Pay + " , " + employeeModel.Deductions + " , " + employeeModel.Taxable_Pay + " , " + employeeModel.Income_Tax + " , " + employeeModel.Net_Pay);
                            Console.WriteLine();

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

        /// <summary>
        /// Sums the of salary gender.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <exception cref="Exception"></exception>
        public void SumOfSalaryByGender(string updateQuery)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    SqlCommand command = new SqlCommand(updateQuery, this.sqlConnection);
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
                            Console.WriteLine("Gender = " + dataReader.GetString(0)+ " , " +"Sum Of Salary = "+ dataReader.GetDecimal(1));
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

        /// <summary>
        /// Averages the salary by gender.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <exception cref="Exception"></exception>
        public void AverageSalaryByGender(string updateQuery)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    SqlCommand command = new SqlCommand(updateQuery, this.sqlConnection);
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
                            /// It will print average of salary
                            Console.WriteLine("Gender = " + dataReader.GetString(0) + " , " + "Average Of Salary = " + dataReader.GetDecimal(1));
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

        /// <summary>
        /// Minimums the salary by gender.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <exception cref="Exception"></exception>
        public void MinimumSalaryByGender(string updateQuery)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    SqlCommand command = new SqlCommand(updateQuery, this.sqlConnection);
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
                            /// It will print Minimum of salary
                            Console.WriteLine("Gender = " + dataReader.GetString(0) + " , " + "Minimum Of Salary = " + dataReader.GetDecimal(1));
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

        /// <summary>
        /// Maximums the salary by gender.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <exception cref="Exception"></exception>
        public void MaximumSalaryByGender(string updateQuery)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    SqlCommand command = new SqlCommand(updateQuery, this.sqlConnection);
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
                            /// It will print Maximum Salary
                            Console.WriteLine("Gender = " + dataReader.GetString(0) + " , " + "Maximum Of Salary = " + dataReader.GetDecimal(1));
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

        /// <summary>
        /// Counts the salary by gender.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <exception cref="Exception"></exception>
        public void CountSalaryByGender(string updateQuery)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Writing sql query
                    SqlCommand command = new SqlCommand(updateQuery, this.sqlConnection);
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
                            /// It will print number of counts
                            Console.WriteLine("Gender = " + dataReader.GetString(0) + " , " + "Number Of Count = " + dataReader.GetDecimal(1));
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

        /// <summary>
        /// Deletes the data from table.
        /// </summary>
        /// <param name="updateQuery">The update query.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteDataFromTable(string updateQuery)
        {
            using (this.sqlConnection)
            {
                try
                {
                    /// Connections opens
                    this.sqlConnection.Open();
                    SqlCommand command = this.sqlConnection.CreateCommand();
                    /// Gets or sets the sql statement to execute at the data base
                    command.CommandText = updateQuery;
                    /// It used to executing queries that does not return any data.
                    /// Instead returns the number of rows affected.
                    int numberOfAffectedRows = command.ExecuteNonQuery();
                    if (numberOfAffectedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    /// Connections closes
                    this.sqlConnection.Close();
                }
            }
        }
    }
}
