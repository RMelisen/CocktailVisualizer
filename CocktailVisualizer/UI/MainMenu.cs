using Spectre.Console;
using CocktailVisualizer.UI.Commons;
using CocktailVisualizer.Services.APIClients;
using CocktailVisualizer.Commons.Classes;

namespace CocktailVisualizer.UI
{
    internal class MainMenu
    {
        private static List<Category> CategoryList = TheCocktailDbAPIClient.GetAllDrinkCategories();
        private static bool shouldContinue = true;

        internal static void WelcomeUser()
        {
            CategoryList.Add(new Category { strCategory = "Quit" });
            AnsiConsole.MarkupLine($"[{UIStyle.NEUTRAL_INDICATOR_COLOR} Bold]Welcome to CocktailVisualizer ![/]\n");
        }

        internal static void ShowMainMenu()
        {
            Category categoryToView;
            int drinkToViewId = 0;
            while (shouldContinue)
            {
                categoryToView = ShowDrinksCategoriesMenu();

                if (categoryToView != null)
                {
                    AnsiConsole.Clear();
                    drinkToViewId = ShowDrinksMenu(categoryToView);

                    if(drinkToViewId != 0)
                    {
                        AnsiConsole.Clear();
                        ShowDrinkDetails(drinkToViewId);
                    }
                }
                AnsiConsole.Clear();
            }
            AnsiConsole.MarkupLine($"See you soon !");
        }

        private static Category? ShowDrinksCategoriesMenu()
        {
            Category categoryToView;

            categoryToView = AnsiConsole.Prompt(new SelectionPrompt<Category>().Title($"Which category do you want to [{UIStyle.NEUTRAL_INDICATOR_COLOR}]view[/] ?").AddChoices(CategoryList));

            if (categoryToView.strCategory == "Quit")
            {
                categoryToView = null;
                shouldContinue = false;
            }

            return categoryToView;
        }

        private static int ShowDrinksMenu(Category categoryToView)
        {
            List<Drink> drinkList = TheCocktailDbAPIClient.GetAllDrinksByCategory(categoryToView.strCategory);

            Table drinksTable = new Table();
            drinksTable.Border(TableBorder.Rounded);

            drinksTable.AddColumn($"[{UIStyle.NEUTRAL_INDICATOR_COLOR}]Drink ID[/]");
            drinksTable.AddColumn($"[{UIStyle.NEUTRAL_INDICATOR_COLOR}]Name[/]");

            // Populate rows
            foreach (Drink drink in drinkList)
            {
                drinksTable.AddRow(drink.idDrink, drink.strDrink);
            }

            AnsiConsole.MarkupLine($"[{UIStyle.NEUTRAL_INDICATOR_COLOR} Bold]{categoryToView.ToString()} Drinks:[/]");
            AnsiConsole.Write(drinksTable);

            int drinkToViewId = AnsiConsole.Ask<int>($"\nSelect the id from the drink you want to [{UIStyle.NEUTRAL_INDICATOR_COLOR}]view[/] (0 to quit) : ");
            
            return drinkToViewId;
        }

        private static void ShowDrinkDetails(int drinkToViewId)
        {
            List<Drink> drinkList = TheCocktailDbAPIClient.GetDrinkDetails(drinkToViewId);

            if (drinkList != null && drinkList.Count > 0)
            {
                drinkList.First().ShowDrink();
            }
        }
    }
}
