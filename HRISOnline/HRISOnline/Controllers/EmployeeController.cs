using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRISOnline.Controllers
{
    public class EmployeeController : Controller
    {
        private string _baseAddressApi = ConfigurationManager.AppSettings["ApiBaseAddress"].ToString();
        private string _requestEmployeeUri = "Employee";
        // GET: Employee
        public async Task<ActionResult> EmployeeMaintenance()
        { 
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            using (var client = new HttpClient())
            { 
                client.BaseAddress = new Uri(_baseAddressApi);
                var result = await client.GetAsync(_requestEmployeeUri);
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   return Json( await result.Content.ReadAsStringAsync());
                }
                else
                {
                    return Content("Invalid");
                }
            }
        }
    }
}