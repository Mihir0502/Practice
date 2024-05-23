
namespace WebApplication1.Repos
{
    public interface IUserRepo
    {
        public Task<IEnumerable<User>> GetUser();
        public Task<User> GetUsers(int Id);
        public Task<User> AddUser(User user);
    }
}
