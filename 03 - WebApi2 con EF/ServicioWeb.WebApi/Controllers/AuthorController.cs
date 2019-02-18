// Agrego el using de Datos para utilizar Authors.
using ServicioWeb.Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioWeb.WebApi.Controllers
{
    public class AuthorController : ApiController
    {
        // Creo una conexión
        LibreriaConection DB = new LibreriaConection(); 
        
        // Metodo Get, devuelve un objeto de tipo enumerable para que sea genérico. En este caso una lista.
        // Así ya funcióna. Ejecutando y utilizando el Postman puedo hacer un request y probarlo.

        // GET api/Author/
        [HttpGet] // Decorador, por defecto es Get, pero hay que ponerlo igual como buena práctica.
        public IEnumerable<Authors> Get ()
        {
            var listado = DB.Authors.ToList();
            return listado;
        }

        // GET api/Author/id
        //[HttpPost] // Puedo ponerle post, put o delete, funciona igual, pero es una mala práctica.
        [HttpGet]
        public Authors Get(int id)
        {
            var autor = DB.Authors.FirstOrDefault(x => x.Id == id); // linq
            return autor;
        }

        // POST api/Author/autor
        [HttpPost]
        public void Add(Authors author)
        {
            DB.Authors.Add(author);
        }

    }
}
