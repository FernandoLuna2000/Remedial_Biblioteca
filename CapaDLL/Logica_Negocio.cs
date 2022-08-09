using CapaDAL;
using CapaENTIDAES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDLL
{
    public class Logica_Negocio
    {
        private Acceso_Datos AC = null;

        private CRUD OPC = null;
        public Logica_Negocio(string connection)
        {
            AC = new Acceso_Datos(connection);
            OPC = new CRUD(connection);
        }

        //<--------------------------------------------------------------------------------------------Listas Mostrar-------------------------------------------------------------------------------------------->
        public List<Usuarios> L_Usuarios(ref string mensaje, ref string mensajeC)
        {
            return OPC.ListaUsuarios(ref mensaje, ref mensajeC);
        }
    }
}
