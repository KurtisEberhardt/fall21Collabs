namespace fall21Collabs.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AccountProjectViewModel : Project
    {
        public int accountProjectId { get; set; }
    }
}