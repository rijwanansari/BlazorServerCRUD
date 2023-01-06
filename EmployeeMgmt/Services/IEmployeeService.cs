using EmployeeMgmt.Domain;

namespace EmployeeMgmt.Services
{
    public interface IEmployeeService
    {
        Employee InsertUpdate(Employee employee);
        List<Employee> GetAll();
        bool Delete(int Id);
    }
}
