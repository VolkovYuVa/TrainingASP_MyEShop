namespace YuriyShop.WebApi.src.Common
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public Product(long id, string name, string description, string category, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }
        public override string ToString()
        {
            return $"ID:{Id}\nName:{Name}\nDescription:{Description}\nCategory:{Category}\nPrice:{Price}";
        }

    }
}
