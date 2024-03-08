
using System;

public class Employee
{
    private int Id;
    private string Name;
    private string DepartmentName;
    public event EventHandler<string> MethodCalled;

    public Employee(int id, string name, string departmentName)
    {
        Id = id;
        Name = name;
        DepartmentName = departmentName;
    }

    public int GetId()
    {
        OnMethodCalled(nameof(GetId));
        return Id;
    }

    public string GetName()
    {
        OnMethodCalled(nameof(GetName));
        return Name;
    }

    public string GetDepartmentName()
    {
        OnMethodCalled(nameof(GetDepartmentName));
        return DepartmentName;
    }

    public void UpdateId(int id)
    {
        Id = id;
        OnMethodCalled(nameof(UpdateId));
    }

    public void UpdateName(string name)
    {
        Name = name;
        OnMethodCalled(nameof(UpdateName));
    }

    public void UpdateDepartmentName(string departmentName)
    {
        DepartmentName = departmentName;
        OnMethodCalled(nameof(UpdateDepartmentName));
    }

    private void OnMethodCalled(string methodName)
    {
        MethodCalled?.Invoke(this, methodName);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Employee details:");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Department Name: ");
        string departmentName = Console.ReadLine();

        Employee employee = new Employee(id, name, departmentName);
        employee.MethodCalled += (sender, methodName) =>
        {
            Console.WriteLine($"{sender.GetType().Name}.{methodName}() method called");
        };

        Console.WriteLine($"Id: {employee.GetId()}");
        Console.WriteLine($"Name: {employee.GetName()}");
        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
        Console.WriteLine("\nEnter new details for the employee:");

        Console.Write("New Id: ");
        employee.UpdateId(int.Parse(Console.ReadLine()));

        Console.Write("New Name: ");
        employee.UpdateName(Console.ReadLine());

        Console.Write("New Department Name: ");
        employee.UpdateDepartmentName(Console.ReadLine());
        Console.WriteLine("\nAfter update:");
        Console.WriteLine($"Id: {employee.GetId()}");
        Console.WriteLine($"Name: {employee.GetName()}");
        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
    }
}




