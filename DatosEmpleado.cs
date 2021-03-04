using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sueldo_empleados
{
    class DatosEmpleado
    {
        int codigo;
        string nombre;
        float sueldo_hora;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Sueldo_hora { get => sueldo_hora; set => sueldo_hora = value; }
    }
}
