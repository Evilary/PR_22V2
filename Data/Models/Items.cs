namespace Shop_Chernyshkov_Final.Data.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Img { get; set; }
        public int Price { get; set; }

        public Categorys Categorys { get; set; }
    }
}
