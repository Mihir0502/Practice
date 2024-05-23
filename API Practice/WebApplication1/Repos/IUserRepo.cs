
namespace WebApplication1.Repos
{
    public interface IUserRepo
    {
        public Task<IEnumerable<User>> GetAllUser();
    }
}
