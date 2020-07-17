using System;
using System.Data.SqlClient;


namespace ProcessNorthwindDB_Tyrone
{
    class Program
    {
        private static SqlConnection sqlConnection = new
            SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=c:\\databases\\northwnd.mdf;" +
            "Integrated Security=True");

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
            /*
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
            */
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
