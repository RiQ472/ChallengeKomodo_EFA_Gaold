using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoChallenge_EFA_Gold
{
    public class MenuItems
    {
        private object menuNum;
        private object itemname;
        private object description;
        private object ingredients;
        private object price;

        public int MenuNum { get; set; }
        public int Qauntity { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public double Price { get; set; }
        public string Description { get; set; }
        public string ItemName { get; set; }
        public MenuItems() { }
        public MenuItems(double price, int mNum, int quantity, string itemname, string description, List<string> ingredients)
        {
            MenuNum = mNum;
            Qauntity = quantity;
            Price = price;
            Ingredients = ingredients;
            Description = description;
            ItemName = itemname;
        }

        public MenuItems(object menuNum, object itemname, object description, object ingredients, object price)
        {
            this.menuNum = menuNum;
            this.itemname = itemname;
            this.description = description;
            this.ingredients = ingredients;
            this.price = price;
        }
    }
}
