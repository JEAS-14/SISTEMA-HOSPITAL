using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoHospital
    {
        public string NomHospital;
        public string DrcHospital;
        public string PubOPriv;
        public NodoHospital sgte;
        public NodoHospital(string NomHospital,string DrcHospital,string PubOPriv) { 
        this.DrcHospital = DrcHospital;
            this.NomHospital = NomHospital;
            this.PubOPriv = PubOPriv;
            sgte = null;
        }

    }
}
