using System;

namespace HoReD_Entts.Services
{
    public interface IDbContext : IDisposable
    {
        string ExecuteSqlQuery(string cmd, char separatedChar);
    }
}
