using AdventureData.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureData
{
    public class DataAccessLayer
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _getAllCars = "DBA_GetAllCars";

        public DataAccessLayer(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = this._configuration.GetConnectionString("Default");
        }

        public List<Car> GetAllCars(int budget)
        {
            var cars = new List<Car>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(_getAllCars, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@budget", budget));

                    con.Open();


                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        cars.Add(new Car
                        {
                            Make = rdr.GetString("MAKE"),
                            Model = rdr.GetString("MODEL"),
                            Year = rdr.GetInt32("YEAR_OF_RELEASE"),
                            Price = rdr.GetInt32("PRICE")

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cars;
        }

        public List<Phone> GetAllPhones(int budget)
        {
            var phones = new List<Phone>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM [Phones] WHERE Price <= {budget}", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        phones.Add(new Phone
                        {
                            Make = rdr.GetString("Make"),
                            Model = rdr.GetString("Model"),
                            Year = rdr.GetInt32("YEAR_OF_RELEASE"),
                            Price = rdr.GetInt32("Price")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return phones;
        }
        public List<Sport> GetAllSports(int time)
        {
            var sports = new List<Sport>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM [Sports] WHERE Duration <= {time}", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        sports.Add(new Sport
                        {
                            Name = rdr.GetString("Name"),
                            PlayerNum = rdr.GetInt32("PlayerNum"),
                            Duration = rdr.GetInt32("Duration")

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sports;
        }

        //// function to get list of all the earnings
        //public List<Earning> GetAllEarnings()
        //{
        //    var earnings = new List<Earning>();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(_connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("SELECT * FROM [Earnings]", con);
        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                earnings.Add(new Earning
        //                {
        //                    Name = rdr.GetString("Name"),
        //                    Amount = rdr.GetInt32("Amount"),
        //                    Year = rdr.GetInt32("Year")

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return earnings;
        //}

        //new function which takes a string and returns the first and last character as another string
        //public string GetFirstAndLast(string input)
        //{
        //    string output = "";
        //    output += input[0];
        //    output += input[input.Length - 1];
        //    return output;
        //}

    }
}
