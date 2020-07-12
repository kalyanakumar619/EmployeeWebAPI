using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIForEmployee.Models;
//using JSONP;
//using Microsoft.AspNet.WebApi.Cors;

namespace WebAPIForEmployee.Controllers
{
    [RoutePrefix("Api/Employee")]
    //[EnableCors(origins: "http://localhost:5901/DemoApp/WebForm1.aspx", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        private EmployeeMasterEntities db = new EmployeeMasterEntities();

        // GET: api/Employees
        [HttpGet]
        [Route("GetEmployees")]
        public IQueryable<Employee> GetEmployee()
        {
            return db.Employee;
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5  /{id}
        [HttpPut]
        [Route("UpdateEmployee")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmpID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(employee);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [HttpPost]
        [Route("CreateEmployee")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            //if (employee != null && !employee.EmpID.HasValue)
            //    employee.EmpID = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employee);
            db.SaveChanges();

            return Ok(employee);
            //return CreatedAtRoute("DefaultApi", new { id = employee.EmpID }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)///*Employee*/(int id)
        {
            //var id = 1;
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.EmpID == id) > 0;
        }
    }
}