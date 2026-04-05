using Shop_Chernyshkov_Final.Data.Models;
using System.Collections.Generic;

namespace Shop_Chernyshkov_Final.Data.ViewModell
{
    public class VMUpdateItem
    {
        public Items Item { get; set; }
        public IEnumerable<Categorys> Categories { get; set; }
    }
}