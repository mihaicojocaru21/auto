namespace Auto.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        
        public Client()
        {
            RegistrationDate = DateTime.Now;
        }
        
        public Client(string name, string surname, string phone, string email)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            RegistrationDate = DateTime.Now;
        }
        
        public string FullName => $"{Name} {Surname}";
        
        public string GetContactInfo()
        {
            return $"{FullName} | Tel: {Phone} | Email: {Email}";
        }
    }
}