using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoPacientes
    {
        public int CodigoDni;
        public string NombrePaciente;
        public int CodigoDePaciente;
        public string Seguro;
        public string CamaUCI;
        public string Estado;
        public NodoPacientes sgte;

        public NodoPacientes(int codigoDni, string nombrePaciente,string seguro)
        {
          
            this.CodigoDePaciente =1000;
            this.CodigoDni = codigoDni;
            this.NombrePaciente = nombrePaciente;
            this.Seguro = seguro;
            Estado = "Sin Registrar";
            CamaUCI = "No Internado";
            sgte = null;
            
        }
    }
}
