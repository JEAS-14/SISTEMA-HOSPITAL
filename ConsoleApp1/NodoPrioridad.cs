using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoPrioridad
    {
        public string personas;
        public int prioridad;
        public NodoPrioridad sgte;
        public NodoPrioridad(string persona, int prioridad)
        {
            this.personas = persona;
            this.prioridad = prioridad;
            sgte = null;
        }
    }
}
