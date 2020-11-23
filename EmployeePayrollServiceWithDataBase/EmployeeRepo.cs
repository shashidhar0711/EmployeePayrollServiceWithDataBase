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
        SqlConnection connection = new SqlConnection(connectionString);
    }
}
