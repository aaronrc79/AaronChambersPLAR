// Name: Aaron Chambers
// Date: 2020-18-20
// Description:
//      This file is mainly a helper file that has methods to allow us to easily
//      enter the data into the database and to read.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PLAR_P2.Models;
using System.IO;
using System.Diagnostics;

namespace PLAR_P2.Classes
{
    public class DBL
    {

        #region "Connection String"

        /// <summary>
        /// Return connection string
        /// </summary>
        /// <returns>Connection string</returns>
        private static string GetConnectionString()
        {
            var ROOT_PROJECTS_DIR = Directory.GetCurrentDirectory() +  "\\A_ChambersPLAR.mdf";
            Debug.WriteLine(ROOT_PROJECTS_DIR);
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\aarsh\Documents\A_ChambersPLAR.mdf; Integrated Security = True; Connect Timeout = 30
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + ROOT_PROJECTS_DIR + ";Integrated Security=True;Connect Timeout=30";
            //return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aarsh\\Documents\\A_ChambersPLAR.mdf;Integrated Security=True;Connect Timeout=30";
            //return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\A_ChambersPLAR.mdf;Integrated Security=True;Connect Timeout=30";
        }

        #endregion

        #region "Methods"
        /// <summary>
        /// Gets the list of vehicles from the database and returns it as a VehicleDBO object
        /// </summary>
        /// <returns>List of VehicleFBO objects</returns>
        internal static List<VehicleDBO> GetVehicleList()
        {
            // Declare the SQL connection, SQL command, and SQL adapter
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("SELECT * FROM [tblVehicles]", dbConnection);

            //Declare an empty list of VehicleDBO objects
            List<VehicleDBO> allVehicles = new List<VehicleDBO>();

            //Used ID in the table
            var count = 1;
            // Try to connect to the database, and use the adapter to fill the table
            try
            {
                //Open the connection
                dbConnection.Open();

                //Use reader as the sql excecute reader command 
                using (var reader = command.ExecuteReader())
                {
                    //While there are still rows to be read
                    while (reader.Read())
                    {
                        //Create a new VehicleDBO object
                        var tVehicle = new VehicleDBO();
                        //Set the id to the count
                        tVehicle.id = count.ToString();
                        //Assign the variables
                        tVehicle.manufacturer = (string)reader.GetValue(1);
                        tVehicle.model = (string)reader.GetValue(2);
                        tVehicle.productYear = (string)reader.GetValue(3);
                        try
                        {
                        //Try to see if theres a value in the mileage colum of the current row
                            tVehicle.mileage = (string)reader.GetValue(4);
                        }
                        catch
                        {
                            //If there's no mileage it's a boat and set it to null
                            tVehicle.mileage = null;
                        }
                        
                        tVehicle.isCar = (bool)reader.GetValue(5);
                        //Add the vehicle to our list
                        allVehicles.Add(tVehicle);
                        //Update the count
                        count = count + 1;
                    }
                }


            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show("A database error has been encountered: " + Environment.NewLine + ex.Message, "Database Error");
            }
            finally
            {
                //Close the conneciton
                dbConnection.Close();
            }

            // Return the populated DataTable
            return allVehicles;
        }

        
        /// <summary>
        /// Inserts the car into the database
        /// </summary>
        /// <param name="insertVehicle">The car object to be inserted</param>
        /// <returns></returns>
        public static bool InsertCar(Car insertVehicle)
        {

            //Create the connection
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());

            // Create new SQL command and assign it paramaters
            SqlCommand command = new SqlCommand("INSERT INTO tblVehicles VALUES(@manufacturer, @model, @productYear, @mileage, @isCar)", dbConnection);
            command.Parameters.AddWithValue("@manufacturer", insertVehicle.Manufacturer);
            command.Parameters.AddWithValue("@model", insertVehicle.Model);
            command.Parameters.AddWithValue("@productYear", insertVehicle.ProductYear);
            command.Parameters.AddWithValue("@mileage", insertVehicle.Mileage);
            command.Parameters.AddWithValue("@isCar", true);
            //Open the connection
            dbConnection.Open();
            //Set the return value that indicates if the insert was successsful.
            bool returnValue = false;
           

            // Try to insert the new record, return result
            try
            {
                returnValue = (command.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //Close the connection
                dbConnection.Close();

            }
            // Return the true if this worked, false if it failed
            return returnValue;
        }
        /// <summary>
        /// Inserts the boat object into the database
        /// </summary>
        /// <param name="insertVehicle">The boat object to be inserted</param>
        /// <returns>bool: if the insert was successful</returns>
        public static bool InsertBoat(Boat insertVehicle)
        {
            //Create the connection
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());

            // Create new SQL command and assign it paramaters
            SqlCommand command = new SqlCommand("INSERT INTO tblVehicles VALUES(@manufacturer, @model, @productYear, @mileage, @isCar)", dbConnection);
            command.Parameters.AddWithValue("@manufacturer", insertVehicle.Manufacturer);
            command.Parameters.AddWithValue("@model", insertVehicle.Model);
            command.Parameters.AddWithValue("@productYear", insertVehicle.ProductYear);
            command.Parameters.AddWithValue("@mileage", DBNull.Value);

            command.Parameters.AddWithValue("@isCar", false);

            //Open the conneciton 
            dbConnection.Open();
            // Create return value
            bool returnValue = false;

            // Try to insert the new record, return result
            try
            {
                returnValue = (command.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //Close the conneciton
                dbConnection.Close();

            }
            // Return the true if this worked, false if it failed
            return returnValue;
        }


    }
    #endregion
}

