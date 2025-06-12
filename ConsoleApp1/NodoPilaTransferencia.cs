using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoPilaTransferencia
    {
        public string nombrepaciente;
        public string nombrehospital;
        public string nombrehospitaltranferido;
        public NodoPilaTransferencia sgte;
        public NodoPilaTransferencia(string nombrepaciente, string nombrehospital, string nombrehospitaltranferido)
        {
            this.nombrepaciente = nombrepaciente;
            this.nombrehospital = nombrehospital;
            this.nombrehospitaltranferido = nombrehospitaltranferido;
            sgte = null;
        }
    }
}
