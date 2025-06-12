using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListaTransferenciaPaciente
    {
        public NodoTransferenciaPacientes transferencia;
        public ListaTransferenciaPaciente()
        {
            transferencia = null;
        }
        public void AgregarTranferencia(string paciente,string hospital,string hospitaltrans)
        {
            NodoTransferenciaPacientes r = new NodoTransferenciaPacientes(paciente,hospital,hospitaltrans);
            if (r == null)
            {
                r.paciente = paciente;
                r.hospital = hospital;
                r.hospitaltransferido = hospitaltrans;
                transferencia = r;
            }
            else
            {
                r.paciente = paciente;
                r.hospital = hospital;
                r.hospitaltransferido = hospitaltrans;
                r.sgte = transferencia;
                transferencia = r;
            }
        }
        public void MostrarPacientesaTransferir(NodoRegistroPaciente q,ListaCircularRegistoPaciente registopaciente ,NodoHospital hospital)
        {
            string nom=" ";
            NodoHospital hospital1 = hospital;
            int codigopaciente;
            int codigohos=1;
            int codigo;
            Console.WriteLine("Transferencia de paciente");
            Console.WriteLine("Codigo".PadRight(10,' ')+"Pacientes".PadRight(30,' ')+"Hospitales");
            while (q.sgte !=registopaciente.lista) {
                Console.WriteLine(q.CodigoPaciente.ToString().PadRight(10,' ')+q.NombrePaciente.PadRight(30,' ')+q.HospitalRegistrado);
                q=q.sgte;
            }
            Console.WriteLine(q.CodigoPaciente.ToString().PadRight(10, ' ') + q.NombrePaciente.PadRight(30, ' ') + q.HospitalRegistrado);
            Console.WriteLine("Ingrese el codigo del Paciente al que desea transferir");
            codigopaciente=int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("|\tHospitales\t|");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("|\t"+ "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Nombre Hospital" + "\t\t\t|");
            Console.WriteLine("---------------------------------------------------------");
            while (hospital!= null) {
                Console.WriteLine("|\t"+ "{0}{1}{2}{3}", codigohos++.ToString().PadRight(10,' '), "|".PadRight(2, ' '), hospital.NomHospital.PadRight(36,' '), "|".PadRight(40,' '));
                Console.WriteLine("---------------------------------------------------------");
                hospital =hospital.sgte;
            }
            Console.WriteLine("Ingrese el hospital al que desea tranferir");
            codigo = int.Parse(Console.ReadLine());
            codigohos=1;
            while (hospital1!= null) 
            {
                if (codigohos == codigo)
                {
                    break;
                }
                codigohos++;
                hospital1=hospital1.sgte;
            }
            while (q.sgte != registopaciente.lista)
            {
                if (codigopaciente == q.CodigoPaciente)
                {
                    nom = q.HospitalRegistrado;
                    q.HospitalRegistrado = hospital1.NomHospital;
                    q.DireccionHospital = hospital1.DrcHospital;
                    break;
                }
                q = q.sgte;
            }
            if (codigopaciente == q.CodigoPaciente)
            {
                nom = q.HospitalRegistrado;
                q.HospitalRegistrado = hospital1.NomHospital;
                q.DireccionHospital = hospital1.DrcHospital;
            }
            AgregarTranferencia(q.NombrePaciente,nom, q.HospitalRegistrado);
        }
    }
}
