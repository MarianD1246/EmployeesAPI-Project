﻿using EmployeesAPI.Model;
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
    public List<Employee> GetAllItems()
    {
        return _context.Employees.ToList();
    }


    public async Task<Employee>? GetItemByIdAsync(int id)
    {

        return await _context.Employees.FindAsync(id);
    }

    public List<Employee> GetItemByPredicateAsync(Predicate<Employee> predicate)
    {
        return _context.Employees.ToList().FindAll(predicate);
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