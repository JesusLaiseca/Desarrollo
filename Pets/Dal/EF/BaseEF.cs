using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dal.EF.Modelo;
using System.Linq.Expressions;
using System.Data.Entity;
using Entities;
using System.IO;
using System.Xml.Serialization;


namespace Dal.EF
{
    public class BaseEF
    {

        private const int ERROR_TRACE = 7100;
        private static TraceSource _oTrace = null;
        private static string _nombreAplicacion = "Pet";
        protected Contexto Context = null;

        public static TraceSource Trace
        {
            get
            {
                if (_oTrace == null)
                    _oTrace = new TraceSource(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                return _oTrace;
            }
        }

        public static int Cod_Error
        {
            get
            {
                return ERROR_TRACE;
            }
        }

        public static string NombreAplicacion
        {
            get
            {
                return _nombreAplicacion;
            }
        }

        /// <summary>
        /// Obtine la excepcion mas baja
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception TratarExcepcion(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            Trace.TraceEvent(TraceEventType.Error, Cod_Error, string.Concat("Se ha producido un error en ", DateTime.Now, " en la capa de BBDD"), ex.Message, ex.Source);
            
            return ex;
        }

        

        public static DateTime ObtenerFechaServidor()
        {
            try
            {
                DateTime dbDate = new DateTime();
                using (Contexto ctx = new Contexto())
                {
                    var dQuery = ctx.Database.SqlQuery<DateTime>("SELECT getdate() ");
                    dbDate = dQuery.AsEnumerable().First();
                }
                return dbDate;
            }
            catch (Exception ex)
            {
                throw TratarExcepcion(ex);
            }
        }

    }
}
