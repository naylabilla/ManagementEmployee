using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "SESA ID")]
        public string SesaId { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        
        // Navigation properties
        public Gender? Gender { get; set; }
        public Department? Department { get; set; }
    }
}