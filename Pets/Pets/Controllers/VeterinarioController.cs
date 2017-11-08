using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Bll;
using Dal.EF.Consultas.VeterinariosDA;


namespace Pets.Controllers
{
    public class VeterinarioController : ApiController
    {
        // GET api/values
        public IEnumerable<Veterinario> Get()
        {
            List<Veterinario> listaVeterinarios = null;
            VeterinarioBL controlador = (VeterinarioBL)Factoria.CrearControlador(typeof(VeterinarioBL), null);
            listaVeterinarios = controlador.ObtenerTodosVeterinarios();
            return listaVeterinarios.ToList();
        }

        // GET api/values/5
        public Veterinario Get(int id)
        {
            List<Veterinario> listaVeterinarios = null;

            VeterinarioBL controlador = (VeterinarioBL)Factoria.CrearControlador(typeof(VeterinarioBL), null);
            listaVeterinarios = controlador.ObtenerVeterinarioPorID(id);

            return listaVeterinarios.Count > 0 ? listaVeterinarios.Single() : null;

        }

        // POST api/values / add new
        public void Post([FromBody]Veterinario value)
        {
            VeterinarioBL controlador = (VeterinarioBL)Factoria.CrearControlador(typeof(VeterinarioBL), null);
            controlador.InsertarVeterinario(value);
        }

        // PUT api/values/5 update
        public void Put(int id, [FromBody]Veterinario value)
        {
            VeterinarioBL controlador = (VeterinarioBL)Factoria.CrearControlador(typeof(VeterinarioBL), null);
            controlador.ModificarVeterinario(id, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            VeterinarioBL controlador = (VeterinarioBL)Factoria.CrearControlador(typeof(VeterinarioBL), null);
            controlador.EliminarVeterinario(id);
        }
    }
}
