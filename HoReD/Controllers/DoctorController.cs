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
    public class DoctorController : ApiController
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetDoctorByID")]
        public Doctor Get(int id)
        {
            
            return _service.GetDoctorById(id);
        }

        [HttpGet]
        [ActionName("GetDoctors")]
        public List<DoctorInfo> GetDoctors()
        {
            
            return _service.GetDoctors();
        }
    }
}
