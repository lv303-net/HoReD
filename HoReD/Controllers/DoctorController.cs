using HoReD_Entts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HoReD.Controllers
{
    /// <summary>
    /// Controller that represents information about Doctors
    /// </summary>
    public class DoctorController : ApiController
    {
        /// <summary>
        /// Gets the Doctor from table Doctors
        /// </summary>
        /// <param name="id">an integer number,id from table Doctors/// </param>
        /// <returns>An instance of the class Doctor with id=id</returns>
        [HttpGet]
        [ActionName("GetDoctorByID")]
        public Doctor Get(int id)
        {
            Doctor doctor = null;
            try
            {
                using (var myConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString))
                {
                    using (var sqlCmd = new SqlCommand("Select * from Doctors where IDDoctors=" + id + "", myConnection))
                    {
                        myConnection.Open();
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                                doctor = new Doctor
                                {
                                    Id = Convert.ToInt32(reader.GetValue(0)),
                                    IdProfession = Convert.ToInt32(reader.GetValue(1)),
                                    StartHour = TimeSpan.Parse(reader.GetValue(2).ToString()),
                                    EndHour = TimeSpan.Parse(reader.GetValue(3).ToString()),
                                    EmployingDate = Convert.ToDateTime(reader.GetValue(4)),
                                    Image = reader.GetValue(5).ToString()
                                };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return doctor;
        }

        /// <summary>
        /// Gets full infiormation about Doctors in database
        /// </summary>
        /// <returns>List of instances of the class DoctorInfo</returns>
        /// <example>http://localhost:*****/api/Doctor/</example>
        [HttpGet]
        [ActionName("GetDoctors")]
        public List<DoctorInfo> GetDoctors()
        {
            var list = new List<DoctorInfo>();
            try
            {
                using (var myConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString))
                {
                    using (var sqlCmd = new SqlCommand("GETINFOABOUTDOCTORS", myConnection))
                    {
                        myConnection.Open();
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var doctor = new DoctorInfo
                                    {
                                        Id = Convert.ToInt32(reader.GetValue(0)),
                                        FirstName = reader.GetValue(1).ToString(),
                                        LastName = reader.GetValue(2).ToString(),
                                        ProfessionName = reader.GetValue(3).ToString(),
                                        StartHour = TimeSpan.Parse(reader.GetValue(4).ToString()),
                                        EndHour = TimeSpan.Parse(reader.GetValue(5).ToString()),
                                        EmployingDate = Convert.ToDateTime(reader.GetValue(6)),
                                        Image = reader.GetValue(7).ToString()
                                    };
                                    list.Add(doctor);
                                }
                            }
                            else
                            {
                                return list;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return list;
        }
    }
}
