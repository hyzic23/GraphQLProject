using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class MenuRepository : IMenuRepository
{
    private GraphQLDbContext _dbContext;

    public MenuRepository(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    // private static List<Menu> MenuList = new List<Menu>()
    // {
    //     new Menu() {Id = 1, Name = "Class Burger", Description = "A juicy burger with lettuce and cheese", Price = 8.99},
    //     new Menu() {Id = 2, Name = "Margherita Pizza", Description = "Tomato, mozzarella, and basil Pizza", Price = 10.50},
    //     new Menu() {Id = 3, Name = "Grilled Chicken Salad", Description = "Fresh garden salad with grilled chicken", Price = 7.95},
    //     new Menu() {Id = 4, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 12.75},
    //     new Menu() {Id = 5, Name = "Chocolate Browie Sundae", Description = "Warm chocolate brownie with ice cream and fudge Pizza", Price = 6.99},
    //     new Menu() {Id = 6, Name = "Pizza", Description = "Delicious Pizza", Price = 10.50}
    // };
    
    public List<Menu> GetAllMenus()
    {
        return _dbContext.Menus.ToList();
    }

    public Menu GetMenuById(int id)
    {
        return _dbContext.Menus.Find(id);
    }

    public Menu AddMenu(Menu menu)
    {
        _dbContext.Menus.Add(menu);
        _dbContext.SaveChanges();
        return menu;
    }

    public Menu UpdateMenu(int id, Menu menu)
    {
        var menuResult = _dbContext.Menus.Find(id);
        menuResult.Name = menu.Name;
        menuResult.Description = menu.Description;
        menuResult.Price = menu.Price;
        _dbContext.Menus.Update(menuResult);
        _dbContext.SaveChanges();
        return menuResult;
    }

    public void DeleteMenu(int id)
    {
        var menuToDelete = _dbContext.Menus.Find(id);
        _dbContext.Menus.Remove(menuToDelete);
        _dbContext.SaveChanges();
    }
}