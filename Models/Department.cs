namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Location { get; set; }
        public ICollection<Employee>? employees { get; set; }
    }
}
