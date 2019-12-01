using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Students
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var respons = await client.GetAsync("https://localhost:44389/api/students");
            var result = await respons.Content.ReadAsAsync<List<Shared.Vm.Student>>();
            return View(result);
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var client = new HttpClient();
            var respons = await client.GetAsync("https://localhost:44389/api/students/"+id);
            var result = await respons.Content.ReadAsAsync<Shared.Vm.Student>();
            return View(result);
        }

        // GET: Students/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Shared.Vm.Student collection)
        {
            try
            {
                var client = new HttpClient();
                var respons = await client.PostAsJsonAsync<Shared.Vm.Student>("https://localhost:44389/api/students", collection);
                if(respons.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Not Success","Not Success");
            }
            catch
            {
                ModelState.AddModelError("Not Success", "Not Success");
            }
            return View();
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}