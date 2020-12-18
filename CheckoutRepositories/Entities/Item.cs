namespace CheckoutRepositories.Entities
{
    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Offer Offer { get; set; }
    }
}
