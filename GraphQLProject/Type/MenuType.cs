using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type;

public class MenuType : ObjectGraphType<Menu>
{
    public MenuType()
    {
        Field(menu => menu.Id);
        Field(menu => menu.Name);
        Field(menu => menu.Price);
        Field(menu => menu.Description);
    }
}