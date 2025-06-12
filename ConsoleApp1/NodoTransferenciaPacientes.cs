using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoTransferenciaPacientes
    {
        public string paciente;
        public string hospital;
        public string hospitaltransferido;
        public NodoTransferenciaPacientes sgte;
        public NodoTransferenciaPacientes(string paciente,string hospital,string hospitaltranferido)
        {
          this.paciente = paciente;
            this.hospital = hospital;
            this.hospitaltransferido = hospitaltranferido;
            sgte = null;
        }
    }
}
