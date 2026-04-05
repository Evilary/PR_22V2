namespace Shop_Chernyshkov_Final.Data.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Img { get; set; }
        public int Price { get; set; }

        public Categorys Category { get; set; }


        public Items(Items Item) {
            this.Id = Item.Id;
            this.Name = Item.Name;  
            this.Description = Item.Description;
            this.Img = Item.Img;
            this.Price = Item.Price;
            this.Category = Item.Category;
            
        }
        public Items() { }
    }
}
