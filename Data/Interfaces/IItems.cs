using System.Collections;
using Shop_Chernyshkov_Final.Data.Models;
using Shop_Chernyshkov_Final.Data.Models;
using System.Collections.Generic;

namespace Shop_Chernyshkov_Final.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }

        public int Add(Items item);
        void UpdateItem(Items item);

        Items GetItemById(int id);
        void Delete(int id);
    }
    
}
