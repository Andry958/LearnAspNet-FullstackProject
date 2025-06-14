namespace Backend.Model.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        // Замість List<Product>
        public List<UserProduct> UserProducts { get; set; } = new List<UserProduct>();

        public decimal Balance { get; set; }
    }
}
