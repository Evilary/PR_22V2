
using System.Collections.Generic;
using Shop_Chernyshkov_Final.Data.Models;
namespace Shop_Chernyshkov_Final.Data.Interfaces
{
    public interface ICategorys
    {
        public IEnumerable<Categorys> AllCategorys { get; }
    }
}
