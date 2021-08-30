using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Komodo_Cafe
{
    public class ProgramUI
    {
        public void Run()
        {
            Menu();
            SeedMenuRepository();
        }
        public MenuRepository _repo = new MenuRepository();

        public int itemname { get; private set; }
        public int description { get; private set; }
        public double menuNum { get; private set; }

        private void Menu()
        {
            KomodoTitle();
            Console.ReadLine();
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\tWelcome to Komodo Cafe!, Select a menu option:\n" +
                "1. (Menu)List of all items\n" +
                //Should contain the CRUD for the manager
                "2. Add to menu\n" +
                "3. Update menu item\n" +
                "4. Delete item from menu\n" +
                "5. Exit"
                );

                //User input
                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        //Costumer input/Order
                        case 1:
                            Console.Clear();
                            FullMenuList();
                            break;

                        case 2:
                            Console.Clear();
                            AddToMenu();
                            break;
                        case 3:
                            Console.Clear();
                            UpdateMenuList();
                            break;
                        case 4:
                            DeletMenuItem();
                            break;
                        case 5:
                            Console.Clear();
                            KomodoTitle();
                            Console.WriteLine("\n\n\tExiting Komodo Claims...");
                            Thread.Sleep(1000); // sleep 1s
                            keepRunning = false;
                            break;
                            break;
                        default:
                            Console.WriteLine("Invalid menu option");
                            break;

                    }
                }
            }
        }
        private void FullMenuList()
        {
            KomodoTitle();
            bool fullMenu = true;
            while (fullMenu)
            {
                Console.Clear();
                Console.WriteLine("\n\tWould you like to view all the items on the the menu,\n" +
                    "[y]es to continuen\n" +
                    "[b]ack to return to menu");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    Console.Clear();
                    List<MenuItems> allMenuItems = _repo.GetAllMenuItems();
                    foreach (MenuItems MenuItems in allMenuItems)
                    {
                        Console.WriteLine($"Meal Number: {MenuItems.MenuNum}" +
                            $"\nMeal Name {MenuItems.ItemName}" + $"\n{MenuItems.Description}" + $"\n Ingredien" +
                            $"{MenuItems.Ingredients}");

                    }
                }
                else if (input == "b")
                {
                    Console.Clear();
                     Menu();
                }
                else
                    Console.WriteLine("unidentified selection");
            }
        }
        private void AddToMenu()
        {
            List<MenuItems> fullMenu = _repo.GetAllMenuItems();
            MenuItems newMenuitem = new MenuItems();
            Console.Clear();
            Console.WriteLine("\n\n\tEnter the meal number for the new meal.");
            Console.Write($"\n\tExisting Meal numbes");
            foreach (MenuItems menuItems in fullMenu)
            {
                Console.WriteLine($"#{menuItems.MenuNum}");
            }
            Console.WriteLine();
            newMenuitem.MenuNum = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"\n\n\tEnter a name for meal order number {newMenuitem.MenuNum}.");
            newMenuitem.ItemName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"\n\n\tLeaving a space between each, add the ingredients of {newMenuitem.ItemName}.");
            string ingredients = Console.ReadLine();
            newMenuitem.Ingredients = ingredients.Split(' ').ToList();

            Console.Clear();
            Console.WriteLine($"\n\n\tEnter a price for {newMenuitem.ItemName}.");
            newMenuitem.Price = Convert.ToDouble(Console.ReadLine());

            bool menuListUpdate = _repo.AddItemsToRepo(newMenuitem);
            if (menuListUpdate)
            {
                Console.Clear();
                Console.WriteLine("\n\n\tNew Item added to Menu List.");
                Console.WriteLine($"\n\t#{newMenuitem.MenuNum} {newMenuitem.ItemName} for ${newMenuitem.Price}\n\nDescription: {newMenuitem.Description}");
                Console.Write($"{ingredients}");
                foreach (string ingredient in newMenuitem.Ingredients)
                {
                    Console.Write($"{ingredients}");
                }
            }
            else
            {
                Console.WriteLine("Item could not be added");
            }

        }

        private void UpdateMenuList()
        {

        }

        private void DeletMenuItem()
        {
            Console.Clear();
            FullMenuList();
            Console.WriteLine("\n\n\tEnter The menu Item number you wish to remove.");
            bool menuItemDelete = _repo.DeleteMenuItems(Console.ReadLine());
            if (menuItemDelete)
            {
                Console.WriteLine("\n\n\tItem Removed");
            }
            else
            {
                Console.WriteLine("Unable to Remove unlisted Item");
            }

        }

        public void SeedMenuRepository()
        {

            MenuItems itemOne = new MenuItems(1, "Waffle",
                " A dish made from leavened dough that is cooked between two plates that are patterned to give a characteristic size, shape, and surface impression.",
                new List<string> { "flour", "butter", "brown sugar", "yeast", "milk", "and eggs." },
                10.99);

            MenuItems itemTwo = new MenuItems(2, "Coffee",
                "a complex blend of different flavours, which together produce a range of sensory experiences",
                new List<string> { "caffeine", "tannin", "fixed oil", "carbohydrates", "and protien" },
                2.99);

            MenuItems itemThree = new MenuItems(3, "Smoothie",
                "A products typically using raw fruits and vegetables, including dietary fibers",
                new List<string> { "fruit", "Veggies", "and your choice of yogurt" },
                2.99);

            MenuItems itemFour = new MenuItems(4, "Burger",
               "An all beef patty, ketchup, cheese, pickle, onion, and bun",
                new List<string> { "beef patty", "cheese", "onion", "pickle", "bun", "ketchup" },
                 12.99);

            _repo.AddItemsToRepo(itemOne);
            _repo.AddItemsToRepo(itemTwo);
            _repo.AddItemsToRepo(itemThree);
            _repo.AddItemsToRepo(itemFour);

        }

        public void KomodoTitle()
        {
            string title = @"
                 __    __                                     __                  ______            ______          
            |  \  /  \                                   |  \                /      \          /      \         
            | $$ /  $$______  ______ ____   ______   ____| $$ ______        |  $$$$$$\ ______ |  $$$$$$\______  
            | $$/  $$/      \|      \    \ /      \ /      $$/      \       | $$   \$$|      \| $$_  \$/      \ 
            | $$  $$|  $$$$$$| $$$$$$\$$$$|  $$$$$$|  $$$$$$|  $$$$$$\      | $$       \$$$$$$| $$ \  |  $$$$$$\
            | $$$$$\| $$  | $| $$ | $$ | $| $$  | $| $$  | $| $$  | $$      | $$   __ /      $| $$$$  | $$    $$
            | $$ \$$| $$__/ $| $$ | $$ | $| $$__/ $| $$__| $| $$__/ $$      | $$__/  |  $$$$$$| $$    | $$$$$$$$
            | $$  \$$\$$    $| $$ | $$ | $$\$$    $$\$$    $$\$$    $$       \$$    $$\$$    $| $$     \$$     \
             \$$   \$$\$$$$$$ \$$  \$$  \$$ \$$$$$$  \$$$$$$$ \$$$$$$         \$$$$$$  \$$$$$$$\$$      \$$$$$$$";
            Console.WriteLine(title);
        }
    }
}
