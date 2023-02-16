using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace StudentDataExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DataExport;Integrated Security=True";             
            string query = "SELECT ExternalStudentID, FirstName, LastName, DateOfBirth, SSN, Address, City, State, Email, MaritalStatus FROM Student_Info";           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();                
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        using (StreamWriter writer = new StreamWriter("StudentData.txt"))
                        {
                            writer.WriteLine("ExternalStudentID,FirstName,LastName,DateOfBirth,SSN,Address,City,State,Email,MaritalStatus");    
                            while (reader.Read())
                            {
                                 writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                                 reader["ExternalStudentID"],
                                 reader["FirstName"],
                                 reader["LastName"],
                                 reader["DateOfBirth"],
                                 reader["SSN"],
                                 reader["Address"],
                                 reader["City"],
                                 reader["State"],
                                 reader["Email"],
                                 reader["MaritalStatus"]);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Export completed successfully");
            Console.ReadLine();
        }
    }
}