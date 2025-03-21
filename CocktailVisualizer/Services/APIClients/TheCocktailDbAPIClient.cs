using Newtonsoft.Json;
using RestSharp;
using CocktailVisualizer.Commons.Classes;
using System.Collections.Generic;
using System.Linq;

namespace CocktailVisualizer.Services.APIClients
{
    internal class TheCocktailDbAPIClient
    {
        private static readonly RestClient Client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");

        internal static List<Category> GetAllDrinkCategories()
        {
            List<Category> categoryList = new List<Category>();

            try
            {
                RestRequest request = new RestRequest("list.php?c=list");
                var response = Client.ExecuteAsync(request);

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Categories serialize = JsonConvert.DeserializeObject<Categories>(response.Result.Content); // The Cocktail API returns a single object (with a property named "drinks") containing a list of Category items

                    categoryList.AddRange(serialize.CategoriesList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An exception occured while retrieving the cocktail categories list : {e.Message}");
            }

            return categoryList;
        }

        internal static List<Drink> GetAllDrinksByCategory(string drinkCategory)
        {
            List<Drink> drinkList = new List<Drink>();

            try
            {
                RestRequest request = new RestRequest($"filter.php?c={drinkCategory}");
                var response = Client.ExecuteAsync(request);

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Drinks serialize = JsonConvert.DeserializeObject<Drinks>(response.Result.Content);

                    drinkList.AddRange(serialize.DrinkList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An exception occured while retrieving the cocktail categories list : {e.Message}");
            }

            return drinkList;
        }

        internal static List<Drink> GetDrinkDetails(int drinkId)
        {
            List<Drink> drinkList = new List<Drink>();
            try
            {
                RestRequest request = new RestRequest($"lookup.php?i={drinkId}");
                var response = Client.ExecuteAsync(request);

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Drinks serialize = JsonConvert.DeserializeObject<Drinks>(response.Result.Content);

                    drinkList = serialize.DrinkList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An exception occured while retrieving the cocktail categories list : {e.Message}");
            }

            return drinkList;
        }
    }
}
