using EmployeesAPI.Model;

namespace EmployeesAPI.Services
{
    //This is a generic interface
    public interface IRepository<T>
    {
        public List<T> GetAllItems();
        public Task<T> GetItemByIdAsync(int id);
        public Task CreateItemAsync(T item);
        public Task RemoveItemAsync(T item);
        public bool ItemExists(int id);
        object Select(Func<object, Employee> p);
    }
}
