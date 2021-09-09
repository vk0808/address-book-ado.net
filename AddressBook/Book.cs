﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    public class Book
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(LocalDb)\localDb;Initial Catalog=address_book;Integrated Security=True");
        }
        SqlConnection BookConnection = ConnectionSetup();


        public string[] UpdatePersonCityState(PersonUpdateModel personUpdateModel)
        {
            BookConnection = ConnectionSetup();
            string[] cityState = new string[2];
            try
            {
                using (BookConnection)
                {
                    string id = "13";

                    string query = @"SELECT * FROM address WHERE BookID =" + Convert.ToInt32(id);
                    PersonModel displayModel = new PersonModel();
                    
                    SqlCommand command = new SqlCommand("spUpdatePersonCityState", BookConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookID", personUpdateModel.BookID);
                    command.Parameters.AddWithValue("@City", personUpdateModel.City);
                    command.Parameters.AddWithValue("@State", personUpdateModel.State);
                    
                    BookConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.BookID = Convert.ToInt32(dr["BookID"]);
                            displayModel.City = dr["City"].ToString();
                            displayModel.State = dr["State"].ToString();
                            cityState[0] = dr["City"].ToString();
                            cityState[1] = dr["State"].ToString();

                            Console.WriteLine(displayModel.BookID + " " + displayModel.City + " " + displayModel.State + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                BookConnection.Close();
            }
            return cityState;
        }
    }
}
