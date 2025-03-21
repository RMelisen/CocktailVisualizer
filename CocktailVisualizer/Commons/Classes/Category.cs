using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailVisualizer.Commons.Classes
{
    internal class Category
    {
        public string strCategory {  get; set; }

        public override string ToString()
        {
            // Convert the category to Title Case (Each word starts with Upper Case)
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(strCategory.ToLower()); ;
        }
    }

    internal class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
