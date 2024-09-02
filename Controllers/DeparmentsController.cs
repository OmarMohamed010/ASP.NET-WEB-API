using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentsController : ControllerBase
    {
        Companycontext dbcontext = new Companycontext();

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(dbcontext.departments.ToList());
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public ActionResult GetById(int id)
        {
            var department = dbcontext.departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            dbcontext.Add(department);
            dbcontext.SaveChanges();

            return CreatedAtAction("GetById",
                new { id = department.Id },
                new { message = "Successfully Created" });
        }

        [HttpPut]
        public ActionResult Edit(int id, Department departefromuser)
        {
            if (id != departefromuser.Id)
            {
                return BadRequest();
            }
            var departFromDb = dbcontext.departments.Find(id);
            if (departFromDb == null)
            {
                return NotFound();
            }
            departFromDb.Name = departefromuser.Name;
            departFromDb.Location = departefromuser.Location;

            dbcontext.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var departfromdb = dbcontext.departments.Find(id);
            if (departfromdb == null)
            {
                return NotFound();
            }
            dbcontext.Remove(departfromdb);
            dbcontext.SaveChanges();
            return NoContent();
        }
    }
}
