using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Dal.EF.Modelo;
using System.ServiceModel;
using System.Data.Objects.SqlClient;

namespace Dal.EF.Consultas.VeterinariosDA
{
    public class VeterinariosConsultas : BaseEF
    {

        public static List<Veterinario> ObtenerVeterinarios()
        {
            try
            {
                using (Contexto ctx = new Contexto())
                {
                    var Veterinarios = (from A in ctx.Veterinarios.Where(i => i.ID > 0) select A).ToList();

                    return Veterinarios;
                }
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }


        public static void InsertarVeterinario(Veterinario Veterinario)
        {
            try
            {
                #region Validaciones

                if (Veterinario == null)
                    throw new ArgumentException("El Veterinarios es correcto");

                #endregion validaciones

                using (Contexto ctx = new Contexto())
                {
                    ctx.Veterinarios.Add(Veterinario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }

        public static List<Veterinario> ObtenerVeterinariosPorId(int id)
        {
            try
            {
                using (Contexto ctx = new Contexto())
                {
                    var Veterinarios = (from A in ctx.Veterinarios.Where(i => i.ID == id) select A);

                    return Veterinarios.ToList();
                }
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }

        public static Veterinario ObtenerAsignacion(int Id)
        {
            try
            {
                using (Contexto ctx = new Contexto())
                {
                    var Veterinarios = (from A in ctx.Veterinarios.Where(i => i.ID == Id) select A);

                    if (Veterinarios.Count() == 1)
                        return Veterinarios.Single();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }


        public static void ModificarVeterinario(int Id, Veterinario Veterinario)
        {
            try
            {
                #region Validaciones

                if (Veterinario == null)
                    throw new ArgumentException("La Veterinario no es correcta");

                #endregion validaciones

                using (Contexto ctx = new Contexto())
                {
                    var Veterinarios = (from A in ctx.Veterinarios.Where(i => i.ID == Id) select A);

                    if (Veterinarios.Count() == 1)
                    {
                        ctx.Veterinarios.Remove(Veterinarios.Single());
                    }

                    ctx.Veterinarios.Add(Veterinario);
                    ctx.SaveChanges();


                }
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }


        public static void EliminarVeterinario(int Id)
        {
            try
            {
                #region Validaciones

                if (Id.Equals(0))
                    throw new ArgumentException("El Id no es correcta");

                #endregion validaciones

                using (Contexto ctx = new Contexto())
                {
                    var Veterinarios = (from A in ctx.Veterinarios.Where(i => i.ID == Id) select A);

                    if (Veterinarios.Count() == 1)
                    {

                        ctx.Veterinarios.Remove(Veterinarios.Single());
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }

    }
}
