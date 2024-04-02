namespace PetStore
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public virtual string DisplayName
        {
            get
            {
                return Name;
            }
        }

    }    
}
