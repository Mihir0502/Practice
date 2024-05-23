using System.Data;

namespace WebApplication1.Service
{
    public interface IDapper
    {
        public IDbConnection Connection();
    }
}
