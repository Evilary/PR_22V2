using Shop_Chernyshkov_Final.Data.Models;
using System.Collections.Generic;

namespace Shop_Chernyshkov_Final.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
            
        public IEnumerable<Categorys> Category { get; set; }
            
        public int SelectCategory = 0;

    }
}
