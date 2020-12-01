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

        public List<EmployeeModel> employeePayrollModelList = new List<EmployeeModel>();

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
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.Name);
            });
            Console.WriteLine(this.employeePayrollModelList.ToString());
        }

        /// <summary>
        /// Adds the employee payroll.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        public void AddEmployeePayroll(EmployeeModel employeeModel)
        {
            employeePayrollModelList.Add(employeeModel);
        }

        /// <summary>
        /// UC10 Without using threads
        /// Adds the employee to payroll data base.
        /// </summary>
        /// <param name="employeePayrollList">The employee payroll list.</param>
        public void AddEmployeeToPayrollDataBase(List<EmployeeModel> employeePayrollList)
        {
            employeePayrollList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee Being Added: " + employeeData.Name);
                this.AddEmployeeInToDataBase(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.Name);
            });
            Console.WriteLine(this.employeePayrollModelList.ToString());
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void AddEmployeeInToDataBase(EmployeeModel employeeDetails)
        {

            SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", employeeDetails.Name);
            command.Parameters.AddWithValue("@Salary", employeeDetails.Salary);
            command.Parameters.AddWithValue("@Start", employeeDetails.Start);
            command.Parameters.AddWithValue("@Gender", employeeDetails.Gender);
            command.Parameters.AddWithValue("@PhoneNumber", employeeDetails.PhoneNumber);
            command.Parameters.AddWithValue("@Address", employeeDetails.Address);
            command.Parameters.AddWithValue("@Department", employeeDetails.Department);
            command.Parameters.AddWithValue("@Basic_Pay", employeeDetails.Basic_Pay);
            command.Parameters.AddWithValue("@Deductions", employeeDetails.Deductions);
            command.Parameters.AddWithValue("@Taxable_Pay", employeeDetails.Taxable_Pay);
            command.Parameters.AddWithValue("@Income_Tax", employeeDetails.Income_Tax);
            command.Parameters.AddWithValue("@Net_Pay", employeeDetails.Net_Pay);
            this.sqlConnection.Open();
            /// It used to executing queries that does not return any data.
            var result = command.ExecuteNonQuery();
            this.sqlConnection.Close();
        }

        /// <summary>
        /// UC11 Using Threads
        /// Adds the employee payroll using thread.
        /// </summary>
        /// <param name="employeePayrollList">The employee payroll list.</param>
        public void AddEmployeePayrollUsingThread(List<EmployeeModel> employeePayrollList)
        {
            employeePayrollList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.Name);
                    //Console.WriteLine("Current thread Id: " + Thread.CurrentThread.ManagedThreadId);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee Added:  " + employeeData.Name);
                });
                thread.Start();
            });
        }

        /// <summary>
        /// UC11 Using threads
        /// Adds the employee payroll in to database using thread.
        /// </summary>
        /// <param name="employeePayrollList">The employee payroll list.</param>
        public void AddEmployeePayrollInToDataBaseUsingThread(List<EmployeeModel> employeePayrollList)
        {
            employeePayrollList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.Name);
                    //Console.WriteLine("Current thread Id: " + Thread.CurrentThread.ManagedThreadId);
                    this.AddEmployeeInToDataBase(employeeData);
                    Console.WriteLine("Employee Added:  " + employeeData.Name);
                });
                thread.Start();
            });
        }

    }
}
