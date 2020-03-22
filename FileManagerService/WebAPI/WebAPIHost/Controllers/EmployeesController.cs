using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIHost.Data;
using WebAPIHost.Models;

namespace WebAPIHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEnumerable<Employee> Get() => TestData.Employees;
    }
}