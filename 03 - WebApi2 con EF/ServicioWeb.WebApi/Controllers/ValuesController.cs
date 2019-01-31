using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

/*
 * Rest es una arquitectura basada en HTTP. Un servicio web que utiliza esta arquitectura es llamado servicio Rest Full.
 * Al basarse en el protocolo HTTP, Rest utiliza los verbos Get, Post, etc. 
 * Recursos son cualquier objeto que lleguemos a utilizar, datos, tablas.
 * C -> Post, R -> Get, U -> Put, D -> Delete (Analogía con CRUD)
 * El api expone una funcionalidad. El controlador es el punto de entrada.
 * 
 * 
 * Creo uno proyecto aparte para los modelos, sería como una capa. Permite reutilizar código. No hay que olvidarse agregar 
 * la referencia al proyecto.
*/

namespace ServicioWeb.WebApi.Controllers
{

    // Los controladores de WebApi heredan de ApiController. Con heredar de Api controller alcanza para ser una WebApi
    // 
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
