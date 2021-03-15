using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using ( var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://apiservice.mol.gov.tw/OdService/download/A17000000J-030240-88Z");
                var welcome = Welcome.FromJson(jsonString);
                ViewData["Welcome"] = welcome;
            }
            
        }
    }
}
