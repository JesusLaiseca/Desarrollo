using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Transactions;
using Dal;
using Dal.EF.Consultas.VeterinariosDA;

namespace Bll
{
    public class VeterinarioBL : BaseControlador
    {
        public List<Veterinario> ObtenerTodosVeterinarios()
        {
            List<Veterinario> respuesta = (new BLLControladorExcepciones<List<Veterinario>>()).Controla(() =>
            {
                List<Veterinario> listaVeterinario = null;
                using (TransactionScope ts = new TransactionScope())
                {
                    listaVeterinario = new List<Veterinario>();
                    listaVeterinario = VeterinariosConsultas.ObtenerVeterinarios();

                    ts.Complete();
                }
                return listaVeterinario;
            });
            return respuesta;
        }



        public List<Veterinario> ObtenerVeterinarioPorID(int ID)
        {
            List<Veterinario> respuesta = (new BLLControladorExcepciones<List<Veterinario>>()).Controla(() =>
            {
                List<Veterinario> listaVeterinario = null;
                using (TransactionScope ts = new TransactionScope())
                {
                    listaVeterinario = new List<Veterinario>();
                    listaVeterinario = VeterinariosConsultas.ObtenerVeterinariosPorId(ID);

                    ts.Complete();
                }
                return listaVeterinario;
            });
            return respuesta;
        }


        public void InsertarVeterinario(Veterinario value)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                VeterinariosConsultas.InsertarVeterinario(value);
                ts.Complete();
            }
        }


        public bool ModificarVeterinario(int id, Veterinario value)
        {
            bool respuesta = (new BLLControladorExcepciones<bool>()).Controla(Mensaje.CodigosMensaje.PortalErrorDesconocido, () =>
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    VeterinariosConsultas.ModificarVeterinario(id, value);
                    ts.Complete();
                }

                return true;
            });
            return respuesta;
        }


        public bool EliminarVeterinario(int ID)
        {
            bool respuesta = (new BLLControladorExcepciones<bool>()).Controla(() =>
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (ID > 0)
                    {
                        VeterinariosConsultas.EliminarVeterinario(ID);
                    }
                    ts.Complete();
                }
                return true;
            });
            return respuesta;
        }

    }
}

