using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly DapperContext _dapparcontext;
        public UserRepo(DapperContext dapparcontext)
        {
            _dapparcontext = dapparcontext;
        }

        async Task<IEnumerable<User>> IUserRepo.GetAllUser()
        {
            string query = "SELECT Fname, Lname FROM Users_Data";
            using (var connection = _dapparcontext.CreateConnection()) {
                //IEnumerable<User> users =  connection.Query<User>(query).ToList();
                var data11 = await connection.QueryAsync<User>(query);
                return data11;
            }
        }
    }
}
