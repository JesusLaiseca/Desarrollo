using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Bll
{
    /// <summary>
    /// Patrón Simple Factory
    /// </summary>
    public class Factoria
    {
        /// <summary>
        /// Crea un controlador del tipo indicado, inicializando los parámetros de usuario, funcionalidad, etc.
        /// </summary>
        /// <param name="tipoControlador"></param>
        /// <returns></returns>
        public static BaseControlador CrearControlador(Type tipoControlador, BaseControlador controladorPrimario)
        {
            //Se invoca al contstructor del controlador
            ConstructorInfo ctor = tipoControlador.GetConstructor(Type.EmptyTypes);
            BaseControlador controlador = (BaseControlador)ctor.Invoke(new Object[0]);

            //controlador.usuarioId = controladorPrimario.usuarioId;
            //controlador.usuarioTarificadorId = controladorPrimario.usuarioTarificadorId;
            //controlador.funcionalidad = controladorPrimario.funcionalidad;
            //controlador.tipoContenido = controladorPrimario.tipoContenido;

            controlador.Init();

            //Devuelve una instancia del controlador
            return controlador;
        }

    }
}
