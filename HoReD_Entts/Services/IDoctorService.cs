using System.Collections.Generic;

namespace HoReD_Entts.Services
{
    public interface IDoctorService
    {
        Doctor GetDoctorById(int id);
        List<DoctorInfo> GetDoctors();
    }
}
