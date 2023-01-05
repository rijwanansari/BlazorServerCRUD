using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmt.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Decimal Salary { get; set; }
        [Required]
        [MaxLength(20)]
        public Gender Gender { get; set; }
        [Required]
        [MaxLength(150)]
        public string EntryBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public ICollection<EmployeeQualification> EmployeeQualifications { get; set; }  
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
