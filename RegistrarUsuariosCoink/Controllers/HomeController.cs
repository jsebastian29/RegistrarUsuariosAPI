using RegistrarUsuariosCoink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RegistrarUsuariosCoink.Controllers
{
    public class HomeController : Controller
    {   
        public ActionResult Index()
        {
            var lstUsuario = CallWebApi().Result;
            return View(lstUsuario);
        }

        static async Task<List<ListUsuarioViewModel>> CallWebApi()
        {
            List<ListUsuarioViewModel> listUsuarioViewModel = new List<ListUsuarioViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51145/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                HttpResponseMessage response = await client.GetAsync("api/Usuario").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    listUsuarioViewModel = await response.Content.ReadAsAsync<List<ListUsuarioViewModel>>();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }

            return listUsuarioViewModel;
        }

        public ActionResult Create()
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            ViewBag.AllCountries = new List<SelectListItem>();
            ViewBag.AllDepartments = new List<SelectListItem>();
            ViewBag.AllCities = new List<SelectListItem>();

            return View(usuarioViewModel);
        }
    }
}
