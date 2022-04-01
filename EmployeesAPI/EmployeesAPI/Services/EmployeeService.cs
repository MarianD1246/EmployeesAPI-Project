using EmployeesAPI.Model;
using System.Linq;

namespace EmployeesAPI.Services;

public class EmployeeService : IRepository<Employee>
{
    private readonly NorthwindContext _context;

    public EmployeeService()
    {
        _context = new NorthwindContext();
    }

    public EmployeeService(NorthwindContext context)
    {
        _context = context;
    }

    public async Task CreateItemAsync(Employee item)
    {
        _context.Employees.Add(item);
        await SaveItemChangesAsync();
    }

    //Why can't this method be async
    public List<EmployeeDTO> GetAllItems()
    {
        List<EmployeeDTO> listOfDTO = new();
        List<Employee> rawEmployees = _context.Employees.ToList();
        foreach(Employee emp in rawEmployees)
        {
            listOfDTO.Add(Utilities.EmployeeToDTO(emp));
        }
        return listOfDTO;
    }


    public async Task<Employee>? GetItemByIdAsync(int id)
    {

        return await _context.Employees.FindAsync(id);
    }

    public List<EmployeeDTO> GetItemByPredicateAsync(Predicate<Employee> predicate)
    {
        List<EmployeeDTO> listOfDTO = new();
        List<Employee> rawEmployees = _context.Employees.ToList().FindAll(predicate);
        foreach (Employee emp in rawEmployees)
        {
            listOfDTO.Add(Utilities.EmployeeToDTO(emp));
        }
        return listOfDTO;
    }

    //Make async?
    public bool ItemExists(int id)
    {
        return _context.Employees.Any(e => e.EmployeeId == id);
    }

    public async Task RemoveItemAsync(Employee item)
    {
        _context.Employees.Remove(item);
        await SaveItemChangesAsync();
    }

    public async Task SaveItemChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public object Select(Func<object, Employee> p)
    {
        throw new NotImplementedException();
    }
}