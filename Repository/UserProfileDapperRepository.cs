using MongoDB.Driver;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;

namespace SimpleBot.Repository
{

    public class UserProfileDapperRepository : IUserProfileRepository
    {
        IDbConnection _connection;
        
        public UserProfileDapperRepository()
        {
            _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\logonrmlocal\Source\Repos\net13-bot-aspnet\App_Data\DatabaseProfile.mdf;Integrated Security=True");
        }

        public UserProfile GetProfile(string id)
        {
            string sql = "SELECT * FROM Profile WHERE Id = @id;";
            return _connection.Query<UserProfile>(sql,
                                                new { Id = id  }
                                                ).FirstOrDefault();
        }

        public void SetProfile(string id, UserProfile profile)
        {
            string sql = "UPDATE Profile SET Visitas = @Visitas WHERE Id = @id;";
            _connection.Query(sql,
                            new {
                                Id = id,
                                Visitas = profile.Visitas}
                            ).FirstOrDefault();
        }
    }
}