namespace WebApiLearning.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public Users User { get; set; }
        public Books Book { get; set; }
    }

    public class OrdersDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }

}
