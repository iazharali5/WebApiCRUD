using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Employee> emp_list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.GetAsync("ApiCRUD");
            response.Wait();
            var test = response.Result;

            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emp_list = display.Result;
            }
          
            return View(emp_list);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.PostAsJsonAsync<Employee>("ApiCRUD",emp);
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        public ActionResult Details(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.GetAsync("ApiCRUD?id="+ id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);

        }
       public ActionResult Edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.GetAsync("ApiCRUD?id=" + id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.PutAsJsonAsync<Employee>("ApiCRUD", e);
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");

        }

        public ActionResult Delete(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.GetAsync("ApiCRUD?id=" + id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44310/api/ApiCRUD");
            var response = client.DeleteAsync("ApiCRUD/" +id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");

        }




    }
}