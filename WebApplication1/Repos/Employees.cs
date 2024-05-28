using Dapper;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Repos
{
    public class Employees
    {
       public void GetEmp()
        {
            string connectionString = "Data Source=172.16.18.15;Initial Catalog=EmployeeManagement;MultipleActiveResultSets=True;Uid=hbits-mihir;password=lwC655E00lZh"; //"DataSource=172.16.18.15;InitialCatlog=EmployeeManagement;Integrated Security=True;MultipleActiveResultSets=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Fname, Lname FROM User_data";
                IEnumerable<User> users = connection.Query<User>(query).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Fname: {user.Fname}, Lname: {user.Lname}");
                    Console.ReadKey();
                }
                foreach (var user in users)
                {
                    string qurey1 = "insert into User_data values (@Fname, @Lname)";
                    connection.Execute(qurey1, new { Fname = user.Fname, Lname = user.Lname });
                }
            }

        }
    }
}
