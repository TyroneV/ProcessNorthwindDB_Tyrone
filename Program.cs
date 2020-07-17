using System;
using System.Configuration;
using System.Data.SqlClient;


namespace ProcessNorthwindDB_Tyrone
{
    class Program
    {
        private static string dataSource = 
            ConfigurationManager.AppSettings.Get("DataSource");
        private static string fileName = 
            ConfigurationManager.AppSettings.Get("AttachDbFilename");
        private static string integratedSecurity = 
            ConfigurationManager.AppSettings.Get("IntegratedSecurity");

        private static SqlConnection sqlConnection = new
            SqlConnection($"Data Source={dataSource};" +
            $"AttachDbFilename={fileName};" +
            $"Integrated Security={integratedSecurity}");

        private static void OpenConnection()
        {
            try
            {
                // Open Connection
                sqlConnection.Open();
                Console.WriteLine("Connection Opened");
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        static void Main(string[] args)
        {
            OpenConnection();
            Dml dml = new Dml();

            //Display Original Data Rows
            Console.WriteLine("\n");
            Console.WriteLine("Display Rows Before Insertion:");
            dml.SelectRows(sqlConnection);
            Console.WriteLine("\n");
            Console.WriteLine("Insert Row operation:***");
            dml.InsertRows(sqlConnection);
            //Display Rows Before Insertion
            Console.WriteLine("\n");
            Console.WriteLine("Display Rows After Insertion:");
            dml.SelectRows(sqlConnection);
            //Update Rows
            Console.WriteLine("\n");
            Console.WriteLine("Perform Update***");
            dml.UpdateRows(sqlConnection);
            //Display Rows Before Insertion
            Console.WriteLine("\n");
            Console.WriteLine("Display Rows After Update:");
            dml.SelectRows(sqlConnection);
            //Clean up with delete of all inserted rows
            Console.WriteLine("\n");
            Console.WriteLine("Clean Up By Deleting Inserted Rows***");
            dml.DeleteRows(sqlConnection);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
