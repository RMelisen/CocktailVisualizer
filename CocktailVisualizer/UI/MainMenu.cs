using Spectre.Console;
using CocktailVisualizer.UI.Commons;
using CocktailVisualizer.Services.APIClients;

namespace CocktailVisualizer.UI
{
    internal class MainMenu
    {
        internal static void WelcomeUser()
        {
            AnsiConsole.MarkupLine($"[{UIStyle.NEUTRAL_INDICATOR_COLOR} Bold]Welcome to CocktailVisualizer ![/]\n");
        }

        internal static void ShowMainMenu()
        {
            // Show Drinks Category Menu
            ShowDrinksCategoryMenu();

            // Prompt choose a category

            // Than choose a drink in the category and show info
        }

        private static async void ShowDrinksCategoryMenu()
        {
            try
            {
                TheCocktailDbAPIClient.GetAllCocktailCategories();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }            
        }
    }
}
