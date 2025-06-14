using Azure.Core;
using Backend.Model;
using Backend.Method;
namespace Backend.Model.WorkWhitServer
{
    public class WorkWithServer
    {
        private readonly ProductDb _workWithServer;
        public WorkWithServer(ProductDb workWithServer)
        {
            _workWithServer = workWithServer;
        }
        public ProductDb GetWorkWithServer()
        {
            return _workWithServer;
        }
        public List<Product> GetProducts()
        {
            var products = _workWithServer.Products.ToList();
            return products;
        }
        public void Delete(int id)
        {
            var product = _workWithServer.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                throw new Exception("Product not found");

            _workWithServer.Products.Remove(product); // Correct way to remove
            _workWithServer.SaveChanges();
        }
        public void Update(int id, string name, int price)
        {
            var product = _workWithServer.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                throw new Exception("Product not found");

            product.Name = name;
            product.Price = price;

            _workWithServer.SaveChanges();
        }
        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _workWithServer.Products.Add(product);
            _workWithServer.SaveChanges();
        }
        public List<Product> Filtr(string value)
        {
            switch (value)
            {
                case "Ordinary": return _workWithServer.Products.ToList();
                case "Alphabetically": return _workWithServer.Products.ToList().OrderBy(x => x.Name).ToList();
                case "PriceUp": return _workWithServer.Products.ToList().OrderBy(x => x.Price).ToList();
                case "PriceDown": return _workWithServer.Products.ToList().OrderByDescending(x => x.Price).ToList();
                default: return _workWithServer.Products.ToList();
            }
        }
        public void CreateNewItems()
        {
            CreateNewTwentyItems createNewItems = new CreateNewTwentyItems(this);
            createNewItems.AddProduct();
        }
    }
}
