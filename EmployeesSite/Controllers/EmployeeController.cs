using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmployeesSite.Models;
using Newtonsoft.Json;

namespace EmployeesSite.Controllers
{
    public class EmployeeController : Controller
    {
        private static HttpClient _httpClient;
        public EmployeeController()
        {

        }
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            List < EmployeeEntry > model = null;
            Task.Run(() =>
            {
                _httpClient = new HttpClient();

                var url = "http://localhost:10273/";
                _httpClient.BaseAddress = new Uri(url);
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                model = GetEmployeesAsync().Result;
            }).Wait();

            return View(model);
        }

        [NonAction]
        private async Task<List<EmployeeEntry>> GetEmployeesAsync()
        {
            var path = "api/employees";
            List<EmployeeEntry> employees = null;
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<List<EmployeeEntry>>();
            }

            return employees;   
        }
    }
}