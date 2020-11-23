// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//      This file is mainly a helper file that has methods to allow us to easily
//      enter the data into the database and to read.
//



using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
namespace PLAR_P1
{

    class DBL
    {

        #region "Connection String"

        /// <summary>
        /// Return connection string
        /// </summary>
        /// <returns>Connection string</returns>
        private static string GetConnectionString()
        {
            //Get the path of the MDF file in our project.
            var ROOT_PROJECTS_DIR = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace("\\bin", "\\A_ChambersPLAR.mdf"));
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + ROOT_PROJECTS_DIR + ";Integrated Security=True;Connect Timeout=30";
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Function that returns all vehicles in the database as a DataTable for display
        /// </summary>
        /// <returns>a DataTable containing all vehicles in the database</returns>
        internal static DataTable GetVehicleList()
        {
            // Declare the SQL connection, SQL command, and SQL adapter
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("SELECT * FROM [tblVehicles]", dbConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Declare a DataTable object that will hold the return value
            DataTable vehicleTable = new DataTable();

            // Try to connect to the database, and use the adapter to fill the table
            try
            {
                dbConnection.Open();
                adapter.Fill(vehicleTable);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("A database error has been encountered: " + Environment.NewLine + ex.Message, "Database Error");
            }
            finally
            {
                adapter.Dispose();
                dbConnection.Close();
            }

            // Return the populated DataTable
            return vehicleTable;
        }

        /// <summary>
        /// Function to add a new car to the vehicle database
        /// </summary>
        /// <param name="insertVehicle">a car object</param>
        /// <returns>true if successful</returns>
        public static bool InsertCar(Car insertVehicle)
        {


            SqlConnection dbConnection = new SqlConnection(GetConnectionString());

            // Create new SQL command and assign it paramaters
            SqlCommand command = new SqlCommand("INSERT INTO tblVehicles VALUES(@manufacturer, @model, @productYear, @mileage, @isCar)", dbConnection);
            command.Parameters.AddWithValue("@manufacturer", insertVehicle.Manufacturer);
            command.Parameters.AddWithValue("@model", insertVehicle.Model);
            command.Parameters.AddWithValue("@productYear", insertVehicle.ProductYear);
            command.Parameters.AddWithValue("@mileage", insertVehicle.Mileage);
            command.Parameters.AddWithValue("@isCar", true);

            dbConnection.Open();
           
            bool returnValue = false;

            // Try to insert the new record, return result
            try
            {
                returnValue = (command.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("A database error has been encountered: " + Environment.NewLine + ex.Message, "Database Error");
            }
            finally
            {
                dbConnection.Close();

            }
            // Return the true if this worked, false if it failed
            return returnValue;
        }

        /// <summary>
        /// Function to add a new car to the vehicle database
        /// </summary>
        /// <param name="insertVehicle">a boat object</param>
        /// <returns>true if successful</returns>
        public static bool InsertBoat(Boat insertVehicle)
        {
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());

            // Create new SQL command and assign it paramaters
            SqlCommand command = new SqlCommand("INSERT INTO tblVehicles VALUES(@manufacturer, @model, @productYear, @mileage, @isCar)", dbConnection);
            command.Parameters.AddWithValue("@manufacturer", insertVehicle.Manufacturer);
            command.Parameters.AddWithValue("@model", insertVehicle.Model);
            command.Parameters.AddWithValue("@productYear", insertVehicle.ProductYear);
            command.Parameters.AddWithValue("@mileage", DBNull.Value);
            command.Parameters.AddWithValue("@isCar", false);

            //Start the database connection.
            dbConnection.Open();
           

            bool returnValue = false;
            // Try to insert the new record, return result
            try
            {
                returnValue = (command.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("A database error has been encountered: " + Environment.NewLine + ex.Message, "Database Error");
            }
            finally
            {
                dbConnection.Close();

            }
            // Return the true if this worked, false if it failed
            return returnValue;
        }


    }
    #endregion
}
