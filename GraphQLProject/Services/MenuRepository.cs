using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class MenuRepository : IMenuRepository
{
    private static List<Menu> MenuList = new List<Menu>()
    {
        new Menu() {Id = 1, Name = "Class Burger", Description = "A juicy burger with lettuce and cheese", Price = 8.99},
        new Menu() {Id = 2, Name = "Margherita Pizza", Description = "Tomato, mozzarella, and basil Pizza", Price = 10.50},
        new Menu() {Id = 3, Name = "Grilled Chicken Salad", Description = "Fresh garden salad with grilled chicken", Price = 7.95},
        new Menu() {Id = 4, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 12.75},
        new Menu() {Id = 5, Name = "Chocolate Browie Sundae", Description = "Warm chocolate brownie with ice cream and fudge Pizza", Price = 6.99},
        new Menu() {Id = 6, Name = "Pizza", Description = "Delicious Pizza", Price = 10.50}
    };
    
    public List<Menu> GetAllMenus()
    {
        return MenuList;
    }

    public Menu GetMenuById(int id)
    {
        return MenuList.Find(x => x.Id == id);
    }

    public Menu AddMenu(Menu menu)
    {
        MenuList.Add(menu);
        return menu;
    }

    public Menu UpdateMenu(int id, Menu menu)
    {
        MenuList[id] = menu;
        return menu;
    }

    public void DeleteMenu(int id)
    {
        MenuList.RemoveAt(id);
    }
}