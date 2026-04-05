using System.Collections.Generic;
using Shop_Chernyshkov_Final.Data.Interfaces;
using Shop_Chernyshkov_Final.Data.Models;
using System.Linq;


namespace Shop_Chernyshkov_Final.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys _category = new MockCategorys();
        public IEnumerable<Items> AllItems
        {
            get
            {
                return new List<Items>()
                {
                    new Items()
                    {
                        Id = 0,
                        Name = "MACHENIKE S15C",
                        Description = "Machenike S15: Повысьте производительность и точность работы. Machenike S15 сочетает в себе передовые технологии и продуманный дизайн, создавая высокопроизводительный ноутбук, отвечающий требованиям как геймеров, так и профессионалов. Благодаря мощному процессору, быстрому хранению данных, великолепному дисплею и эффективному охлаждению, S15 спроектирован таким образом, чтобы обеспечить исключительную производительность и надежность в элегантном и практичном корпусе. Купить ноутбук Machenike S15 можно в наших фирменных магазинах indexIQ с доставкой по городу или же с возможностью забрать свой заказ самостоятельно.",
                        Img = "https://avatars.mds.yandex.net/i?id=ba754c4cfa1415244fea9f232ed4775a_sr-12728186-images-thumbs&n=13",
                        Price = 60990,
                        Category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items()
                    {
                        Id = 0,
                        Name = "DEXP MB-70",
                        Description = "Микроволновая печь DEXP MB-70 – идеальное сочетание стиля, удобства и функциональности для вашей кухни. Элегантный черный корпус придаст любому интерьеру современный вид, а навесная дверца с удобной кнопкой открытия делает эксплуатацию максимально простой и комфортной.",
                        Img = "https://astmarket.com/upload/iblock/3c0/5kki35hh3w8fgvqwhxhc8motdnr74rpo/bb5818ca_212c_11f1_931e_a8952f9223f0.jpg",
                        Price = 3229,
                        Category = _category.AllCategorys.Where(x => x.Id == 2).First()
                    }
                    
                };
            }
        }

        public int Add(Items item)
        {
            throw new System.NotImplementedException();
        }

        public Items GetItemById(int id)
        {
            return AllItems.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateItem(Items item)
        {
            throw new System.NotImplementedException();
        }
        public void Delete(int id)
        {
            
        }
    }
}
