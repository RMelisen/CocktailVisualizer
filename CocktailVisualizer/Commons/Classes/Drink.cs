using CocktailVisualizer.UI.Commons;
using Newtonsoft.Json;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CocktailVisualizer.Commons.Classes
{
    internal class Drink
    {
        public string strDrink;
        public string strDrinkThumb;
        public string idDrink;
        public string strIngredient1;
        public string strIngredient2;
        public string strIngredient3;
        public string strIngredient4;
        public string strIngredient5;
        public string strIngredient6;
        public string strInstructions;

        internal void ShowDrink()
        {
            AnsiConsole.MarkupLine($"[{UIStyle.NEUTRAL_INDICATOR_COLOR} Bold]{strDrink}:[/]");
            AnsiConsole.MarkupLine($"\n[{UIStyle.NEUTRAL_INDICATOR_COLOR}]Ingredients :[/]");

            if (!String.IsNullOrEmpty(strIngredient1))
                AnsiConsole.MarkupLine($"   - {strIngredient1}");
            if (!String.IsNullOrEmpty(strIngredient2))
                AnsiConsole.MarkupLine($"   - {strIngredient2}");
            if (!String.IsNullOrEmpty(strIngredient3))
                AnsiConsole.MarkupLine($"   - {strIngredient3}");
            if (!String.IsNullOrEmpty(strIngredient4))
                AnsiConsole.MarkupLine($"   - {strIngredient4}");
            if (!String.IsNullOrEmpty(strIngredient5))
                AnsiConsole.MarkupLine($"   - {strIngredient5}");
            if (!String.IsNullOrEmpty(strIngredient6))
                AnsiConsole.MarkupLine($"   - {strIngredient6}");

            AnsiConsole.MarkupLine($"\n[{UIStyle.NEUTRAL_INDICATOR_COLOR}]Instructions :[/]");
            AnsiConsole.MarkupLine($"{strInstructions}");

            AnsiConsole.MarkupLine($"\nPress any key to [{UIStyle.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
        }
    }

    internal class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinkList { get; set; }
    }
}
