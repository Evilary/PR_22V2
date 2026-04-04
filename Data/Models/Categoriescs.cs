using System.Collections.Generic;

namespace Shop_Chernyshkov_Final.Data.Models
{
    public class Categoriescs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Items> Items { get; set; }
    }
}
