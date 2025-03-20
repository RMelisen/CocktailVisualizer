using Newtonsoft.Json;
using RestSharp;
using CocktailVisualizer.Commons.Classes;

namespace CocktailVisualizer.Services.APIClients
{
    internal class TheCocktailDbAPIClient
    {
        private static readonly HttpClient httpClient = new HttpClient();

        internal static void GetAllCocktailCategories()
        {
            try
            {
                RestClient client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
                RestRequest request = new RestRequest("list.php?c=list");
                var response = client.ExecuteAsync(request);

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string rawResponse = response.Result.Content;
                    var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse); // The Cocktail API returns a single object (with a property named "drinks") containing a list of Category items

                    List<Category> returnedList = serialize.CategoriesList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
