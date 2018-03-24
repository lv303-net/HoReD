using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace HoReD_Entts.Services
{
    public class DbContext : IDbContext
    {
        private readonly SqlConnection _myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString);

        public DbContext()
        {
                _myConnection.Open();
        }

        //Execute query, which return one string, where values separated by char
        public string ExecuteSqlQuery(string cmd, char separatedChar)
        {
            var command = new SqlCommand(cmd, _myConnection);
            var reader = command.ExecuteReader();

            var result = new StringBuilder();

            if (reader.Read())
            {
                foreach (var value in reader)
                {
                    result.Append(value);
                    result.Append(separatedChar);
                }
            }

            return result.ToString();
        }

        public void Dispose()
        {
            _myConnection?.Dispose();
        }
    }
}
