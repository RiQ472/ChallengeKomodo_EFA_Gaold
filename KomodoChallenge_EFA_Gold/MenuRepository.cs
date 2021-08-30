using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoChallenge_EFA_Gold
{
    public class MenuRepository
    {                         //List Of Menu Repository
        private List<MenuItems> _listOfMR = new List<MenuItems>();
        public bool AddItemsToRepo(MenuItems MenuItems)
        {
            //Create
            int startingCount = _listOfMR.Count;
            _listOfMR.Add(MenuItems);
            bool mealAdded = (_listOfMR.Count > startingCount) ? true : false;
            return mealAdded;
        }
        public List<MenuItems> GetAllMenuItems()
        {
            return _listOfMR;
        }
        //Read
        public MenuItems GetMenuItemsByNum(int mNum)
        {
            foreach (MenuItems itemNumber in _listOfMR)
            {
                if (itemNumber.MenuNum == mNum)
                {
                    return itemNumber;
                }
            }
            return null;
        }
        //Update
        public void UpdateMenuItems(int menuItemNum, MenuItems newMenuItem)
        {
            foreach (MenuItems itemNumber in _listOfMR)
            {
                if (itemNumber.MenuNum == menuItemNum)
                {
                    itemNumber.MenuNum = newMenuItem.MenuNum;
                    itemNumber.Ingredients = newMenuItem.Ingredients;
                    itemNumber.Price = newMenuItem.Price;
                    itemNumber.Qauntity = newMenuItem.Qauntity;
                    itemNumber.Description = newMenuItem.Description;
                    itemNumber.ItemName = newMenuItem.ItemName;
                }
            }
        }
        //Delete
        public void DeleteMenuItems(int menuItemNum)
        {
            _listOfMR.Remove(GetMenuItemsByNum(menuItemNum));
        }

        internal bool DeleteMenuItems(string v)
        {
            throw new NotImplementedException();
        }
    }
}
  
