namespace APIApp
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int id);
    }
}
