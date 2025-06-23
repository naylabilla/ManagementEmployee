namespace EmployeeManagementSystem.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        // Navigation property
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}