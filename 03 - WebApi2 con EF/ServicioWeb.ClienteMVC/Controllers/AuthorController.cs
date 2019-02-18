using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using _03___ServicioWeb.ModelosCliente;
using Newtonsoft.Json;

namespace ServicioWeb.ClienteMVC.Controllers
{
    public class AuthorController : Controller
    {             
        // GET: Author
        public ActionResult Index() // Cick derecho en Index para agregar la vista.
        {
            List<Authors> listado = new List<Authors>(); // Objeto que retorna el método.
            HttpClient clienteHttp = new HttpClient(); // agregar el using
            clienteHttp.BaseAddress = new Uri("http://localhost:49782/"); 
            var request = clienteHttp.GetAsync("api/Author/").Result; // Guardo el resultado de la consulta.

            if(request.IsSuccessStatusCode) // Evaluo si la consulta fue exitosa.
            {
                var strJson = request.Content.ReadAsStringAsync().Result; // tomo el json en forma de str.
                // Agregar using. Deserializo el strJson y lo convierto en un objeto List<Authors>.
                listado = JsonConvert.DeserializeObject<List<Authors>>(strJson); 
            }

            return View(listado);
        }
    }
}