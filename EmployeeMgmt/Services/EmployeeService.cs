using EmployeeMgmt.DAL;
using EmployeeMgmt.Domain;

namespace EmployeeMgmt.Services
{
    public class EmployeeService
    {
		private readonly ApplicationDBContext _context;
		public EmployeeService(ApplicationDBContext context)
		{
			_context= context;
		}
        public Employee InsertUpdate(Employee employee)
        {
			try
			{
				if(employee.Id== 0) { 
					_context.Add(employee);
					
				}
				else
				{
					var employeeUpdate = _context.Employees.Find(employee.Id);
					if(employeeUpdate != null)
					{
                        employeeUpdate.Name= employee.Name;	
						employeeUpdate.Salary= employee.Salary;
						employeeUpdate.DateOfBirth = employee.DateOfBirth;
						employeeUpdate.Gender= employee.Gender;
                    }

				}
                _context.SaveChanges();
				return employee;

            }
			catch (Exception ex)
			{

				throw;
			}
        }
		public List<Employee> GetAll()
		{
			try
			{
				var employees = _context.Employees.ToList();
				return employees;
			}
			catch ( Exception ex)
			{

				throw;
			}
		}
    }
}
