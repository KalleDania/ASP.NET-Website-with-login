using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eksempel_1.Controllers
{
    //[Route("employee")]
    [Route("company/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        //[Route("")]
        //[Route("[action]")]
        public string Index()
        {
            return "Hello, from employee!";
        }

        //http://localhost:64821/Employee/name og "Kasper" printes.
        //[Route("name")]
        //[Route("[action]")]
        public ContentResult Name()
        {
            return Content("Kasper");
        }

        //[Route("country")]
        //[Route("[action]")]
        public string Country()
        {
            return "Denmark";
        }
    }
}
