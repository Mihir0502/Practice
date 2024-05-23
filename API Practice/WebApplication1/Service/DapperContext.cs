using Microsoft.Data.SqlClient;
using WebApplication1.Service;
using Microsoft.Data.SqlClient;
using System.Data;
namespace WebApplication1.Service

{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Data Source=172.16.18.15;Initial Catalog=EmployeeManagement;MultipleActiveResultSets=True;Uid=hbits-mihir;password=lwC655E00lZh");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
