using EmployeesAPI.Model;

namespace EmployeesAPI.Services
{
    //This is a generic interface
    public interface IRepository<T>
    {
        public List<EmployeeDTO> GetAllItems();
        public Task<Employee> GetItemByIdAsync(int id);
        public List<EmployeeDTO> GetItemByPredicateAsync(Predicate<Employee> predicate);
        public Task CreateItemAsync(T item);
        public Task RemoveItemAsync(T item);
        public bool ItemExists(int id);
        public Task SaveItemChangesAsync();
        object Select(Func<object, Employee> p);
    }
}
