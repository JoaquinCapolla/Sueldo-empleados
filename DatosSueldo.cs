using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sueldo_empleados
{
    class DatosSueldo
    {
        int codigo;
        int horasmes;
        string mes;

        public int Codigo { get => codigo; set => codigo = value; }
        public int Horasmes { get => horasmes; set => horasmes = value; }
        public string Mes { get => mes; set => mes = value; }
    }
}
