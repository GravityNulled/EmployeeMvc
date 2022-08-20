namespace Employee.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Depertment { get; set; } = null!;
    }
}
