using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class MenuMutation : ObjectGraphType
{
    public MenuMutation(IMenuRepository menuRepository)
    {
        //Mutation for CreateMenu
        Field<MenuType>("CreateMenu")
            .Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu"}))
            .Resolve(context => menuRepository.AddMenu(context.GetArgument<Menu>("menu")));
        
        //Mutation for UpdateMenu
        Field<MenuType>("UpdateMenu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"},
                       new QueryArgument<MenuInputType> { Name = "menu"}))
            .Resolve(context => menuRepository.UpdateMenu(context.GetArgument<int>("menuId"), 
                context.GetArgument<Menu>("menu")));
        
        //Mutation for DeleteMenu
        Field<StringGraphType>("DeleteMenu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"}))
            .Resolve(context => {menuRepository.DeleteMenu(context.GetArgument<int>("menuId")); 
                return "The menu against this Id" + context.GetArgument<int>("menuId") + "has been deleted";});
    }
}