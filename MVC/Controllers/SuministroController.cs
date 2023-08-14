using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SuministroController : Controller
    {
        // GET: Suministro
        public ActionResult Index()
        {
            IEnumerable<mvcSuministroModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Suministros").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcSuministroModel>>().Result;
            return View(empList);
        }

        // GET: Suministro
        public ActionResult SuministrosBajoMinimo()
        {
            IEnumerable<mvcSuministroModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Suministros/BajoMinima").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcSuministroModel>>().Result;
            return View(empList);
        }

        public ActionResult Add(int id = 0)
        {
            if (id == 0)
                return View(new mvcSuministroModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Suministros/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcSuministroModel>().Result);
            }
        }
        // POST: Suministro
        [HttpPost]
        public ActionResult Addt(mvcSuministroModel sum)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Suministros/", sum).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return View(new mvcSuministroModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Suministros/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcSuministroModel>().Result);
            }
        }
        // POST: Suministro
        [HttpPost]
        public ActionResult Edit(mvcSuministroModel sum)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Suministros/" + sum.Codigo, sum).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            return RedirectToAction("Index");
        }

        public ActionResult Retirar(int id)
        {
            mvcRetiroModel modeloRetiro = new mvcRetiroModel();

            modeloRetiro.CodigoProducto = id;
            modeloRetiro.FechaEntrega = DateTime.Now;
            return View(modeloRetiro);
        }
        // POST: Retiros
        [HttpPost]
        public ActionResult Retirar(mvcRetiroModel re)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Retiros/", re).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            return RedirectToAction("Index");
        }
    }
}