using EmployeesAPI.Model;

namespace EmployeesAPI.Services
{
    //This is a generic interface
    public interface IRepository<T>
    {
        public List<T> GetAllItemsAsync();
        public Task<T> GetItemByIdAsync(long id);
        public Task CreateItemAsync(T item);
        public Task SaveItemChangesAsync();
        public Task RemoveItemAsync(T item);
        public bool ItemExists(long id);
        object Select(Func<object, EmployeeDTO> p);
    }
}
