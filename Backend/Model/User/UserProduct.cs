namespace Backend.Model.User
{
    public class UserProduct
    {
        public int Id { get; set; }

        // Зовнішній ключ до користувача
        public int UserId { get; set; }
        public User User { get; set; }

        // Зовнішній ключ до продукту
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Додаткова інформація (опціонально)
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; } = 1;
    }
}
