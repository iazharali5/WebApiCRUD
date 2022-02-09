using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    public class ApiCRUDController : ApiController
    {
        web_api_crud_dbEntities db =new web_api_crud_dbEntities();
    
        [HttpGet]
        public IHttpActionResult GetEmpoyee()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult InsertEmpoyee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult DetailsEmpoyeeById(int id)
        {
            var emp = db.Employees.Where(model =>model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmpoyeeById(Employee e)
        {
            var emp = db.Employees.Where(model => model.id == e.id).FirstOrDefault();

            if(emp!= null)
            {
                emp.id = e.id;
                emp.name = e.name;
                emp.age = e.age;
                emp.designation = e.designation;
                emp.salary = e.salary;
                emp.gender = e.gender;
                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }

            return Ok();
        }
       [HttpDelete]
        public IHttpActionResult DeleteEmpoyeeById(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }







    }
}
