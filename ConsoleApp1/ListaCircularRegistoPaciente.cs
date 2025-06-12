using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListaCircularRegistoPaciente
    {
        public NodoRegistroPaciente lista;
        public ListaCircularRegistoPaciente()
        {
            lista = null;
        }
        public void RegistrarPaciente(NodoHospital hospital,NodoServicios servicios,NodoPacientes paciente)
        {
            NodoHospital hospital1 = hospital; 
            NodoServicios servicios1 = servicios;
            NodoPacientes pacientes = paciente;
            int codigohos = 1;
            int codigoser = 1;
            bool encontrar=false;
            bool c=false;
            Console.WriteLine("-------------------------");
            Console.WriteLine("|\tPacientes\t|");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|\t"+ "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Nombre Paciente" +"\t\t|");
            Console.WriteLine("-------------------------------------------------");
            while (paciente != null)
            {
                if(paciente.Estado=="Sin Registrar") 
                { 

                    Console.WriteLine("|\t"+ "{0}{1}{2}{3}", paciente.CodigoDePaciente.ToString().PadRight(10,' '), "|".PadRight(2, ' '), paciente.NombrePaciente.PadRight(28,' '),"|".PadRight(40,' '));
                    Console.WriteLine("-------------------------------------------------");
                    
                    c = true;
                }
                paciente = paciente.sgte;
            }
            if (c == false)
            {
                Console.WriteLine("Todos los pacientes fueron Registrados");
            }

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
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("|\tServicios\t|");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|\t"+ "{0}{1}{2}", "Codigo".PadRight(10,' '), "|".PadRight(2, ' '), "Servicio" + "\t\t|");
            Console.WriteLine("-----------------------------------------");
            while (servicios != null)
            {
                Console.WriteLine("|\t"+ "{0}{1}{2}{3}", codigoser++.ToString().PadRight(10,' '), "|".PadRight(2, ' '), servicios.Servicios.PadRight(20,' '),"|".PadRight(25,' '));
                Console.WriteLine("-----------------------------------------");
                servicios =servicios.sgte;
            }
            Console.WriteLine();
            Console.WriteLine("Ingrese el Codigo del Paciente");
            int codigoPac=int.Parse(Console.ReadLine());
            while(pacientes!=null)
            {
                if (pacientes.CodigoDePaciente == codigoPac)
                {
                    pacientes.Estado = "Registrado";
                    encontrar = true;
                    break; 
                }
                pacientes = pacientes.sgte;
            }
            if (encontrar == false)
            {
                Console.WriteLine("Codigo de Paciente incorrecto");
                return;
            }
            Console.WriteLine("Ingrese el Codigo de Hospital : ");
            int CodHospital=int.Parse(Console.ReadLine());
            codigohos = 1;
            codigoPac = 1;
            while(hospital1!=null)
            {
                if (CodHospital == codigohos)
                {
                    break;
                }
                codigohos++;
                hospital1 = hospital1.sgte;
            }
            Console.WriteLine("Ingrese el Codigo del servicio : ");
            int CodServicio=int.Parse(Console.ReadLine());
            codigoser = 1;
            while (servicios1 != null)
            {
                if(CodServicio == codigoser)
                {
                    break;
                }
                codigoser++;
                servicios1 = servicios1.sgte;
            }
            int CodigoPaciente=pacientes.CodigoDePaciente;
            string NombrePaciente=pacientes.NombrePaciente;
            string HospitalRegistrado=hospital1.NomHospital;
            string DireccionHospital=hospital1.DrcHospital;
            string ServicioRegistrado=servicios1.Servicios;
            string seguro = pacientes.Seguro;
            string camaUCI = pacientes.CamaUCI;
            NodoRegistroPaciente q = new NodoRegistroPaciente(CodigoPaciente, NombrePaciente, HospitalRegistrado, DireccionHospital, ServicioRegistrado, seguro, camaUCI);
            NodoRegistroPaciente t = lista;
            if (lista == null)
            {
                lista = q;
                q.sgte = q;
            }
            else
            {
                while(t.sgte!=lista) {
                    t = t.sgte;
                }
                t.sgte = q;
                q.sgte= lista;
                lista = q;
            }
            Console.WriteLine("Paciente Registrado correctamente");

        } 
    }
}
