// Check MS SQL database connection

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
    		try
            {
                using (SqlConnection conn = new SqlConnection("Server=SMSK01WE32U\\DBMITSPPS01;Database=Inventory;Trusted_Connection=True;"))
                {
                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            Console.Write("You have been successfully connected to the database!");
                        }
                        else
                        {
                            Console.Write("Connection failed.");
                        }
                    }
                    catch (SqlException) { }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error:" + ex);
            }
            finally { }
			Console.ReadLine();
        }
    }
}