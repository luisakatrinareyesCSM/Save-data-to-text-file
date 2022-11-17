using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace LuisaKatrina.SaveJsonFile.Pages
{
    public class FormModel : PageModel
    {
       
            public BibleDetails? Details { get; set; }
            public void OnGet()
            {

            }
            public class BibleDetails
            {
                public string? Book { get; set; }
                public string? BibleSelection { get; set; }
                public string? Chapter { get; set; }
                public string? Verse { get; set; }
            }
            public void OnPost()
            {
                var client = new RestClient("https://bible-api.com/");

                var request = new RestRequest("", Method.Get);

                RestResponse response = client.Execute(request);

                var content = response.Content;

                var details = JsonConvert.DeserializeObject<BibleDetails>(content);
            }
        }
    }
