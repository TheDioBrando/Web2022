namespace WebApiLearning.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Orders> Orders { get; set; }
    }

    public class UsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
