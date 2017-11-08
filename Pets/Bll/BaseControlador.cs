using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Entities;
using System.IO;
using System.Xml.Serialization;
using System.Transactions;

namespace Bll
{
    public class BaseControlador
    {
        private const int ERROR_TRACE = 6000;
        private static TraceSource _oTrace = null;
        public Guid usuarioId { get; set; }
        //public Funcionalidad.Cdgs funcionalidad { get; set; }
        public int usuarioTarificadorId { get; set; }
        //public TipoContenido.Cdgs tipoContenido { get; set; }
        public static string idiomaPorDefecto { get { return "es"; } }
        virtual public void Init()
        {
            //Virtual
        }

        //Se impide que se pueda crear una instancia de un Controlador sin hacer uso de FactoriaBaseControlador
        //Se han dado muchos casos en los que luego se quiere consultar cualquiera de las propiedades de BaseControlador y no están inicializadas.
        //public BaseControlador()
        //{
        //}

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

    }
}
