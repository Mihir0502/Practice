using Dapper;

namespace WebApplication1.Repos
{
    public class UserRepoBase
    {

        public async Task<User> AddUser(User user)
        {
            var query = "INSERT INTO tblEmployees VALUES (@Name, @Email, @DepartmentId, @Postion, @Salary, @HireDate, @IDProofTypeId)" +
                "SELECT CAST(SCOPE_IDENTITY() AS int)";
            var datainsert = new DynamicParameters();
            datainsert.Add("Name", user.Name.ToString());
            datainsert.Add("Email", user.Email.ToString());
            datainsert.Add("DepartmentId", user.DepartmentId);
            datainsert.Add("Postion", user.Position.ToString());
            datainsert.Add("Salary", user.Salary);
            datainsert.Add("HireDate", user.HireDate.ToShortDateString());
            datainsert.Add("IDProofTypeId", user.IDProofTypeId.ToString());

            using (var connection = _dapparcontext.CreateConnection())
            {
                var id = await connection.ExecuteAsync(query, datainsert);
            }
            var createduser = new User
            {
                Name = user.Name,
                Email = user.Email,
                DepartmentId = user.DepartmentId,
                Position = user.Position,
                Salary = user.Salary,
                HireDate = user.HireDate,
                IDProofTypeId = user.IDProofTypeId,
            };
        }
    }
}