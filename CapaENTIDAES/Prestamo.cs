using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaENTIDAES
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public DateTime Fecha_Inicio_Prestamo { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
        public int IdUsuario { get; set; }
    }
}
