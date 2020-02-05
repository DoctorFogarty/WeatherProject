using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using WeatherWeb.Models;
using System.Configuration;

namespace WeatherWeb.DAL
{
    public class WeatherWebDB
    {
        public bool ValidateZipCode(int ZipCode)
        {

            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("dbo.ValidateZipCode", conn);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@ZipCode", ZipCode);
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        result = true;
                    }

                    conn.Close();

                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("SQL Exception Thrown!" + e.Message);
            }

            return result;
        }

        public CityWeatherData GetWeatherData(int ZipCode) {

            CityWeatherData result = new CityWeatherData();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("dbo.GetWeatherDataByZipCode", conn);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@ZipCode", ZipCode);
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            result = new CityWeatherData
                            {
                                City = dr["City"].ToString(),
                                State = dr["State"].ToString(),
                                WeatherType = dr["WeatherType"].ToString(),
                                Temperature = Convert.ToInt32(dr["Temperature"]),
                                Humidity = Convert.ToInt32(dr["Humidity"]),
                                DewPoint = Convert.ToInt32(dr["DewPoint"]),
                                Pressure = Convert.ToDouble(dr["Pressure"]),
                                WindSpeed = Convert.ToInt32(dr["WindSpeed"]),
                                WindDirection = dr["WindDirection"].ToString(),
                                IMG_URL = dr["IMG_URL"].ToString()
                            };
                        }
                    }

                    conn.Close();
                                        
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("SQL Exception Thrown!" + e.Message);
            }

            return result;
        }
    }
}