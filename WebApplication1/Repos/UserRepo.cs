using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1.Repos
{
    public class UserRepo 
    {
        private readonly DapperContext _dapparcontext;
        public UserRepo(DapperContext dapparcontext)
        {
            _dapparcontext = dapparcontext;
        }

        public void AddUser(User user)
        {
            var query = "INSERT INTO tblEmployees VALUES (@Name, @Email, @DepartmentId, @Postion, @Salary, @HireDate, @IDProofTypeId)" +
               "SELECT CAST(SCOPE_IDENTITY() AS int)";
            using (var connection = _dapparcontext.CreateConnection())
            {
                connection.Execute(query, new {Name=user.Name, Email=user.Email, DepartmentId=user.DepartmentId, Postion=user.Position, Salary=user.Salary,
                HireDate=user.HireDate, IDProofTypeId=user.IDProofTypeId});
            }

            //var createduser = new User
            //{
            //    Name = user.Name,
            //    Email = user.Email,
            //    DepartmentId = user.DepartmentId,
            //    Position = user.Position,
            //    Salary = user.Salary,
            //    HireDate = user.HireDate,
            //    IDProofTypeId = user.IDProofTypeId,
            //};
            //return Task.FromResult(createduser);
            //connection.Execute(qurey1, new { Fname = user.Fname, Lname = user.Lname });
            //var datainsert = new DynamicParameters();
            //datainsert.Add("Name", user.Name.ToString());
            //datainsert.Add("Email", user.Email.ToString());
            //datainsert.Add("DepartmentId", user.DepartmentId);
            //datainsert.Add("Postion", user.Position.ToString());
            //datainsert.Add("Salary", user.Salary);
            //datainsert.Add("HireDate", user.HireDate.ToShortDateString());
            //datainsert.Add("IDProofTypeId", user.IDProofTypeId.ToString());
        }

        //async Task<IEnumerable<User>> IUserRepo.GetUser()
        //{
        //    string query = "SELECT Id, Name, Email, DepartmentId, Postion, Salary, HireDate, IDProofTypeId FROM tblEmployees";
        //    using (var connection = _dapparcontext.CreateConnection()) {
        //        //IEnumerable<User> users =  connection.Query<User>(query).ToList();
        //        var data11 = await connection.QueryAsync<User>(query);
        //        return data11.ToList();
        //    }
        //}

        // async Task<User> IUserRepo.GetUsers(int Id)
        //{
        //    var query = "SELECT * FROM tblEmployees WHERE Id =@Id";
        //    using (var connection = _dapparcontext.CreateConnection())
        //    {
        //        var data12 = await connection.QuerySingleOrDefaultAsync<User>(query, new { Id });
        //        return data12;
        //    }
        //}
    }
}
