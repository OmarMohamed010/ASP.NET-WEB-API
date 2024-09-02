using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] // route
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        Companycontext dbcontext=new Companycontext();

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(dbcontext.Employees.ToList());
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public ActionResult GetById(int id)
        {
            var employee = dbcontext.Employees.Find(id);
            if (employee == null) 
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            dbcontext.Add(employee);
            dbcontext.SaveChanges();

            return CreatedAtAction("GetById", 
                new { id = employee.Id },
                new { message = "Successfully Created" });
        }

        [HttpPut]
        public ActionResult Edit(int id,Employee employeefromuser)
        {
            if (id != employeefromuser.Id)
            {
                return BadRequest();
            }
            var empFromDb = dbcontext.Employees.Find(id);
            if (empFromDb == null)
            {
                return NotFound();
            }
            empFromDb.Name = employeefromuser.Name;
            empFromDb.Age = employeefromuser.Age;
            empFromDb.Salary = employeefromuser.Salary;

            dbcontext.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id) 
        {
            var empfromdb=dbcontext.Employees.Find(id);
            if(empfromdb == null)
            {
                return NotFound();
            }
            dbcontext.Remove(empfromdb);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}
