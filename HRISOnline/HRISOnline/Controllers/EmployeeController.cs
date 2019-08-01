using HRISOnline.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
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
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddressApi);
                    var result = await client.GetAsync(_requestEmployeeUri);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var x = await result.Content.ReadAsAsync<IEnumerable<Employee>>();
                        return Json(x,JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Content("Invalid");
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