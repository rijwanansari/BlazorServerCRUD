using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmt.Domain
{
    public class EmployeeQualification
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public Qualification Name { get; set; }
        public int EmployeeId { get; set; } 
        public decimal Marks { get; set; } 
        public Employee Employee { get; set; }  
    }
    public enum Qualification
    {
        SEE,
        HighSchol,
        Diploma,
        Bachelor,
        Master,
        PhD
    }
}
