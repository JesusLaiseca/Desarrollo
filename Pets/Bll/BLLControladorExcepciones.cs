using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.ServiceModel;
using System.Transactions;
using System.Diagnostics;

namespace Bll
{
    public class BLLControladorExcepciones<Tipo> :BaseControlador
    {
        public Tipo Controla(Mensaje.CodigosMensaje codigoInicio, Func<Tipo> acciones)
        {
            Mensaje sinMensaje = null;
            return this.RealizaAccionesYControlaExcepciones(codigoInicio, out sinMensaje, acciones);
        }

        public Tipo Controla(out Mensaje mensaje, Func<Tipo> acciones)
        {
            Mensaje.CodigosMensaje codigoInicio = Mensaje.CodigosMensaje.ErrorDesconocido;

            return this.RealizaAccionesYControlaExcepciones(codigoInicio, out mensaje, acciones);
        }

        public Tipo Controla(Func<Tipo> acciones)
        {
            Mensaje sinMensaje = null;
            Mensaje.CodigosMensaje codigoInicio = Mensaje.CodigosMensaje.ErrorDesconocido;

            return this.RealizaAccionesYControlaExcepciones(codigoInicio, out sinMensaje, acciones);
        }



        private Tipo RealizaAccionesYControlaExcepciones(Mensaje.CodigosMensaje codigoInicio, out Mensaje mensaje, Func<Tipo> acciones)
        {
            Tipo resultado = default(Tipo);
            mensaje = null;
            try
            {
                resultado = acciones();
            }
            catch (FaultException<Mensaje> ex)
            {
                Trace.TraceData(TraceEventType.Error, Cod_Error,       string.Concat("(", DateTime.Now, ") ", ex.Detail.Texto),      ex);
                mensaje = new Mensaje(ex.Detail);
                throw;
            }
            catch (TransactionAbortedException ex)
            {
                Trace.TraceData(TraceEventType.Error, Cod_Error,   string.Concat("(", DateTime.Now, ") ", "Error en la transacción: {0}")        , ex);
                throw new FaultException<Mensaje>(new Mensaje("Error en la transacción", Mensaje.CodigosMensaje.ErrorTransaccion, ex));
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //Se controla cuando se viola la primary key
                if (ex.Number.Equals(2627) || ex.Number.Equals(2601))
                {
                    Trace.TraceData(TraceEventType.Error, Cod_Error,  string.Concat("(", DateTime.Now, ") ", "Violación de la Primary Key: {0}")             , ex);
                    Mensaje men = new Mensaje("Violación de la Primary Key", codigoInicio, ex);
                    men.Codigo += Convert.ToInt32(Mensaje.CodigosMensaje.PrimaryKeyDuplicada);
                    throw new FaultException<Mensaje>(men);
                }
                else
                {
                    throw;
                }
            }
            return resultado;
        }        
    }
}
