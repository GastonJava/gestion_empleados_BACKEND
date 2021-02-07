using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using SPAngular.Models;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;


namespace SPAngular.Controllers
{
  
   
   [ApiController]
   [Route("[controller]")]

    public class EmployeeServerController : ControllerBase
    {

        //Inyeccion de dependencias
        private readonly EmployeeContext _empdetails;

        public EmployeeServerController(EmployeeContext employeeContext) {
            _empdetails = employeeContext;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Employee> Get() {
            var data = _empdetails.Employee.ToList();
            return data;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Employee>> Get(int id) {
            var empleados = _empdetails.Employee.FirstOrDefault(a => a.Empid == id);
            return Ok(empleados);
        }


        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Employee obj) {
            var data = _empdetails.Employee.Add(obj);
            _empdetails.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] Employee obj) {
            var data = _empdetails.Employee.Update(obj);
            _empdetails.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) {
            var data = _empdetails.Employee.Where(a => a.Empid == id).FirstOrDefault();
            _empdetails.Employee.Remove(data);
            _empdetails.SaveChanges();
            return Ok();
        }
    }
}
