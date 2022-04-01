using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPerson.Models;


namespace WebPerson.Pages
{
    public class PersonModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine("Post");
        }
    }
}
