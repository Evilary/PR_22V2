using System.Collections.Generic;
using Shop_Chernyshkov_Final.Data.Interfaces;
using Shop_Chernyshkov_Final.Data.Models;

namespace Shop_Chernyshkov_Final.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                return new List<Categorys>()
                {
                    new Categorys()
                    {
                        Id = 1,
                        Name = "Ноутбуки",
                        Description = "Описание"
                    },
                    new Categorys()
                    {
                        Id = 2,
                        Name = "Микроволновые печи",
                        Description = "Описание"
                    }
                };
            }
        }
    }
}
