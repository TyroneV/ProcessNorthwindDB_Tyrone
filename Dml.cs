using System;
using System.Data;
using System.Data.SqlClient;


namespace ProcessNorthwindDB_Tyrone
{
    class Dml
    {
        public void UpdateRows(SqlConnection sqlConnection)
        {
            try
            {
                // Sql Update Statement
                string updateSql = "UPDATE Employees " +
                "SET FirstName = @FirstName " +
                "WHERE LastName = @LastName";
                SqlCommand UpdateCmd = new SqlCommand(updateSql, sqlConnection);
                // 2. Map Parameters
                UpdateCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 10, "FirstName");
                UpdateCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 20, "LastName");
                UpdateCmd.Parameters["@FirstName"].Value = "Annabelle";
                UpdateCmd.Parameters["@LastName"].Value = "Jahlberg";
                UpdateCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
        public void DeleteRows(SqlConnection sqlConnection)
        {
            try
            {
                //Create Command objects
                SqlCommand scalarCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", sqlConnection);
                // Execute Scalar Query
                Console.WriteLine("Before Delete, Number of Employees = {0}", scalarCommand.ExecuteScalar());
                // Set up and execute DELETE Command
                //Create Command object
                SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
                nonqueryCommand.CommandText = "DELETE FROM Employees WHERE " + "LastName='Jahlberg' OR " +
                "Lastname='Saxon' OR " +
                "LastName='Gonzales'";
                Console.WriteLine("Executing {0}", nonqueryCommand.CommandText);
                Console.WriteLine("Number of rows affected : {0}", nonqueryCommand.ExecuteNonQuery());
                // Execute Scalar Query
                Console.WriteLine("After Delete, Number of Employee = {0}", scalarCommand.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
        public void SelectRows(SqlConnection sqlConnection)
        {
            try
            {
                // Sql Select Query
                string sql = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                string strEmployeeID = "EmployeeID";
                string strFirstName = "FirstName";
                string strLastName = "LastName";
                Console.WriteLine("{0} | {1} | {2}", strEmployeeID.PadRight(10), strFirstName.PadRight(10), strLastName);
                Console.WriteLine("==========================================");
                while (dr.Read())
                {
                    //reading from the datareader
                    Console.WriteLine("{0} | {1} | {2}",
                    dr["EmployeeID"].ToString().PadRight(10),
                    dr["FirstName"].ToString().PadRight(10),
                    dr["LastName"]);
                }
                dr.Close();
                Console.WriteLine("==========================================");
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " +
                ex.ToString());
            }
        }
        public void InsertRows(SqlConnection sqlConnection)
        {
            //Insert Rows processing
            //Create Command object
            SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
            try
            {
                // Create INSERT statement with named parameters
                nonqueryCommand.CommandText = "INSERT INTO Employees (FirstName, LastName) " +
                "VALUES (@FirstName, @LastName)";
                // Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 10);
                nonqueryCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 20);
                // Prepare command for repeated execution
                nonqueryCommand.Prepare();
                // Data to be inserted
                string[] firstNames = { "Maxine", "Carey", "Jose" };
                string[] lastNames = { "Jahlberg", "Saxon", "Gonzales" };
                for (int i = 0; i <= 2; i++)
                {
                    nonqueryCommand.Parameters["@FirstName"].Value = firstNames[i];
                    nonqueryCommand.Parameters["@LastName"].Value = lastNames[i];
                    Console.WriteLine("Executing {0}", nonqueryCommand.CommandText);
                    Console.WriteLine("Number of rows affected : {0}", nonqueryCommand.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                // Not used now but you might want some clean up processing in future work
            }
        }
    }
}
