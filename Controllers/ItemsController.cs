using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Chernyshkov_Final.Data.Interfaces;
using Shop_Chernyshkov_Final.Data.Models;
using Shop_Chernyshkov_Final.Data.ViewModell;

namespace Shop_Chernyshkov_Final.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;

        private VMItems VMItems = new VMItems();

        private readonly IHostingEnvironment hostingEnvironment;

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostingEnvironment hostingEnvironment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Category = IAllCategorys.AllCategorys;
            VMItems.SelectCategory = id;

            return View(VMItems);
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> categorys = IAllCategorys.AllCategorys;
            return View(categorys);
        }
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if(files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categorys() { Id = idCategory };    

            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);

        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            Items item = IAllItems.GetItemById(id);
            ViewBag.Item = item;
            IEnumerable<Categorys> categorys = IAllCategorys.AllCategorys;
            return View(categorys);
        }

        [HttpPost]
        public RedirectResult Update(int id, string name, string description, IFormFile files, float price, int idCategory)
        {
            
            Items oldItem = IAllItems.GetItemById(id);
            if (oldItem == null) return Redirect("/Items/List");

            string fileName = oldItem.Img; 

            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
                fileName = files.FileName;
            }

            Items updatedItem = new Items();
            updatedItem.Id = id;
            updatedItem.Name = name;
            updatedItem.Description = description;
            updatedItem.Img = fileName;
            updatedItem.Price = Convert.ToInt32(price);
            updatedItem.Category = new Categorys() { Id = idCategory };

            IAllItems.UpdateItem(updatedItem);

            return Redirect("/Items/List?id=" + idCategory);
        }

        [HttpGet]
        public RedirectResult Delete(int id, int categoryId = 0)
        {
            IAllItems.Delete(id);
            return Redirect("/Items/List?id=" + categoryId);
        }

        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != -1) 
            {
                Startup.ItemsBaskets.Add(new ItemsBasket(1, IAllItems.AllItems.First(x => x.Id == idItem)));
            }
            return Json(Startup.ItemsBaskets);
        }

        public ActionResult BasketCount(int idItem = -1, int count = -1)
        {
            if (idItem != -1)
            {
                if (count == 0)
                {
                    Startup.ItemsBaskets.Remove(Startup.ItemsBaskets.Find(x => x.Id == idItem));

                }
                else Startup.ItemsBaskets.Find(x => x.Id == idItem).Count = count;
            }
            return Json(Startup.ItemsBaskets);
        }
    }


}
