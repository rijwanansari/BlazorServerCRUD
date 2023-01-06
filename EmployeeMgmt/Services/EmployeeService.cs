using EmployeeMgmt.DAL;
using EmployeeMgmt.Domain;

namespace EmployeeMgmt.Services
{
    public class EmployeeService : IEmployeeService
    {
		private readonly ApplicationDBContext _context;
        private readonly ILogger<EmployeeService> logger;
        public EmployeeService(ApplicationDBContext context, ILogger<EmployeeService> logger)
		{
			_context= context;
			this.logger= logger;	
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
                logger?.LogError(ex.ToString());
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
                logger?.LogError(ex.ToString());
                throw;
			}
		}
		public bool Delete(int Id)
		{
			try
			{
				var employee = _context.Employees.Find(Id);
				if (employee != null)
					_context.Employees.Remove(employee);

				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
