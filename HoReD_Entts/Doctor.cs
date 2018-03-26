using System;
using System.Collections.Generic;
using System.Text;

namespace HoReD_Entts
{
    public class Doctor
    {
        public int Id { get; set; }

        public int IdProfession { get; set; }

        public TimeSpan StartHour { get; set; }

        public TimeSpan EndHour { get; set; }

        public DateTime EmployingDate { get; set; }

        public string Image { get; set; }
    }
}
