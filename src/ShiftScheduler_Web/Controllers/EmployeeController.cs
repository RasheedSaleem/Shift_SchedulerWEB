using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShiftScheduler_Web.Helper;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShiftScheduler_Web.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeAPI _employeeApi = new EmployeeAPI();
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<EmployeeScheduleModel> lstEmpSch = new List<EmployeeScheduleModel>();
            HttpClient client = _employeeApi.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/EmployeeSchedule");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                lstEmpSch = JsonConvert.DeserializeObject<List<EmployeeScheduleModel>>(result);
            }
            return View(lstEmpSch);
        }
    }
}
