namespace Auto.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public bool IsActive { get; set; }
        
        public Employee()
        {
            EmploymentDate = DateTime.Now;
            IsActive = true;
        }
        
        public Employee(string name, string surname, string position, decimal salary)
        {
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
            EmploymentDate = DateTime.Now;
            IsActive = true;
        }
        
        public string FullName => $"{Name} {Surname}";
    }
}