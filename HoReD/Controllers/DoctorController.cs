using HoReD_Entts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HoReD_Entts.Services;

namespace HoReD.Controllers
{
    /// <summary>
    /// Controller that represents information about Doctors
    /// </summary>
    public class DoctorController : ApiController
    {
        [HttpGet]
        [ActionName("GetDoctorByID")]
        public Doctor Get(int id)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("Select * from Doctors where IDDoctors=" + id + "", myConnection);
            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            Doctor doctor = null;
            while (reader.Read())
            {
                doctor = new Doctor();
                doctor.Id = Convert.ToInt32(reader.GetValue(0));
                doctor.IdProfession = Convert.ToInt32(reader.GetValue(1));
                doctor.StartHour = TimeSpan.Parse(reader.GetValue(2).ToString());
                doctor.EndHour = TimeSpan.Parse(reader.GetValue(3).ToString());
                doctor.EmployingDate = Convert.ToDateTime(reader.GetValue(4));
                doctor.Image = reader.GetValue(5).ToString();
            }
            myConnection.Close();
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
            List<DoctorInfo> list = new List<DoctorInfo>();
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("GETINFOABOUTDOCTORS", myConnection);
            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DoctorInfo doctor = new DoctorInfo();
                    doctor.Id = Convert.ToInt32(reader.GetValue(0));
                    doctor.FirstName = reader.GetValue(1).ToString();
                    doctor.LastName = reader.GetValue(2).ToString();
                    doctor.ProfessionName = reader.GetValue(3).ToString();
                    doctor.StartHour = TimeSpan.Parse(reader.GetValue(4).ToString());
                    doctor.EndHour = TimeSpan.Parse(reader.GetValue(5).ToString());
                    doctor.EmployingDate = Convert.ToDateTime(reader.GetValue(6));
                    doctor.Image = reader.GetValue(7).ToString();
                    list.Add(doctor);
                }
            }

            myConnection.Close();
            return list;
        }
    }
}
