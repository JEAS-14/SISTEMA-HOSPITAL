using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoServicios
    {
        public string Servicios;
        public int NumHabitaciones;
        public string NecesidadDeCamasUCI;
        public int CamasUCI;
        public NodoServicios sgte;
        public NodoServicios ant;
        public NodoServicios(string servicios, int numHabitaciones, string necesidadDeCamasUCI,int camasUCI)
        {
            this.Servicios = servicios;
            this.NumHabitaciones = numHabitaciones;
            this.NecesidadDeCamasUCI = necesidadDeCamasUCI;
            this.CamasUCI= camasUCI;
            sgte = null;
            ant = null;
        }
    }
}
