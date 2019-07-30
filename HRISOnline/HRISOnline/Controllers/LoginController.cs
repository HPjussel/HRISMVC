using HRISOnline.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRISOnline.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Employee emp)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseAddress"]);
                    var jsonData = JsonConvert.SerializeObject(emp);
                    var x = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                    var result = await client.PostAsync(ConfigurationManager.AppSettings["ApiBaseAddress"].ToString()+ConfigurationManager.AppSettings["ApiLogin"].ToString(), x);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Content("invalid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            } 
        }
         
    }
}