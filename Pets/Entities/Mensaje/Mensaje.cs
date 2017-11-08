using System;
using System.Collections.Generic;

namespace Entities
{
    [System.Runtime.Serialization.DataContractAttribute]
    public class Mensaje
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        public Stack<string> Pila;
        public Mensaje(Mensaje mensajeAnterior) { }
        public Mensaje(string texto, Exception ex){ }
        public Mensaje(string texto, CodigosMensaje codigo){ }
        public Mensaje(string texto, Mensaje mensajeAnterior){ }
        public Mensaje(string texto, CodigosMensaje codigo, Mensaje mensajeAnterior){ }
        public Mensaje(string texto, CodigosMensaje codigo, Exception ex){ }

        [System.Runtime.Serialization.DataMemberAttribute]
        public int Codigo { get; set; }
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Texto { get; set; }

        public enum CodigosMensaje
        {
            ErrorDesconocido = 0,
            ErrorConexionBD = 1,
            ErrorTransaccion = 2,
            PrimaryKeyDuplicada = 50,
            InsercionDeNull = 51,
            ErrorOverflowInt32 = 52,
            ErrorGeneralUsuarios = 100,
            ErrorObtenerUsuariosConRoles = 101,
            ErrorObtenerUsuariosSinRoles = 102,
            ErrorModificarUsuario = 103,
            ErrorObtenerUsuario = 104,
            ErrorValidarUsuario = 105,
            ErrorCambiarPassword = 106,
            ErrorCrearUsuario = 107,
            ErrorEliminarUsuario = 108,
            ErrorGeneralTemas = 150,
            ErrorObtenerTemas = 151,
            ErrorObtenerNombreTema = 152,
            ErrorGeneralIdiomas = 160,
            ErrorObtenerCodigoIdioma = 161,
            ErrorObtenerIdiomas = 162,
            ErrorGeneralRoles = 170,
            ErrorObtenerRoles = 171,
            ErrorObtenerRolesUsuario = 172,
            ErrorObtenerUsuariosRol = 173,
            ErrorObtenerNombresRoles = 174,
            ErrorObtenerNombresRolesUsuario = 175,
            ErrorGeneralNoticias = 200,
            ErrorObtenerNoticias = 201,
            ErrorModificarNoticia = 202,
            ErrorInsertarNoticia = 203,
            ErrorEliminarNoticia = 204,
            ErrorObtenerNoticia = 205,
            NoticiasFiltroVacio = 206,
            NoticiasOrdenacionVacia = 207,
            NoticiasRangoFilas = 208,
            NoticiaVacia = 209,
            NoHayResultados = 210,
            NoticiaNoEncontrada = 211,
            ErrorObtenerContenidoNoticia = 280,
            ContenidoErrorDesconocido = 300,
            ErrorObtenerContenidos = 301,
            ErrorObtenerContenido = 302,
            ErrorEliminarContenido = 303,
            ContenidoVacio = 304,
            ContenidoNoEncontrado = 305,
            IdiomaErrorDesconocido = 400,
            BorrarIdioma = 401,
            IdiomaVacio = 402,
            IdiomaYaExiste = 403,
            ParámetroErrorDesconocido = 500,
            ParametroVacio = 501,
            ValorErrorDesconocido = 600,
            ValorVacio = 601,
            SeccionErrorDesconocido = 700,
            GarantiaErrorDesconocido = 800,
            CoberturaErrorDesconocido = 900,
            TipoProductoErrorDesconocido = 1000,
            CompaniaErrorDesconocido = 1100,
            FormaPagoErrorDesconocido = 1200,
            TipoDatoErrorDesconocido = 1300,
            FormaCobroErrorDesconocido = 1400,
            AmbitoErrorDesconocido = 1500,
            EstadoPresupuestoErrorDesconocido = 1600,
            EstadoSeguroErrorDesconocido = 1700,
            MotivoErrorDesconocido = 1800,
            RiesgoFamiliaErrorDesconocido = 1900,
            RiesgoGrupoFamiliaErrorDesconocido = 2000,
            GrupoPortalErrorDesconocido = 2100,
            RiesgosErrorDesconocido = 2200,
            PerfilElinperErrorDesconocido = 2300,
            PerfilElinperFuncionalidadErrorDesconocido = 2400,
            PerfilUsuarioErrorDesconocido = 2500,
            AreaErrorDesconocido = 2600,
            PortalErrorDesconocido = 2700,
            ProductoErrorDesconocido = 2800,
            GarantiaProductoErrorDesconocido = 2900,
            ScriptProductoErrorDesconocido = 3100,
            CoberturaProductoErrorDesconocido = 3200,
            SeccionProductoErrorDesconocido = 3300,
            AmbitoYaExistente = 3352,
            CentroCosteErrorDesconocido = 3400,
            PolizaPortalErrorDesconocido = 3500,
            SeccionMenuYaExiste = 3501,
            SeccionMenuErrorDesconocido = 3502,
            ContadorErrorDesconocido = 4000,
            ErrorObtenerContador = 4001,
            ErrorEliminarContador = 4002,
            ContadorVacio = 4003,
            ContadorNoEncontrado = 4004,
            MaestrosGeneralErrorDesconocido = 5000,
            MaestrosDetalleErrorDesconocido = 5001,
            FlujoErrorDesconocido = 6002,
            FlujosPasosErrorDesconocido = 6003,
            FlujosPasosElemtoGarErrorDesconocido = 6004,
            FlujosPasosElemtoSecErrorDesconocido = 6005
        }
    }
}
