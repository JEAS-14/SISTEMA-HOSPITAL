using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoRegistroPaciente
    {
        public int CodigoPaciente;
        public string NombrePaciente;
        public string HospitalRegistrado;
        public string DireccionHospital;
        public string ServicioRegistrado;
        public string Seguro;
        public string CamaUCI;
        public NodoRegistroPaciente sgte;
        public NodoRegistroPaciente(int codigoPaciente, string nombrePaciente, string hospitalRegistro, string direccionHospital, string servicioRegistrado, string seguro,string camaUCI) {
            CodigoPaciente = codigoPaciente;
            this.NombrePaciente= nombrePaciente;
            this.HospitalRegistrado = hospitalRegistro;
            this.DireccionHospital = direccionHospital;
            this.ServicioRegistrado = servicioRegistrado;
            this.Seguro = seguro;
            this.CamaUCI = camaUCI;
            sgte = null;
        }
    }
}
