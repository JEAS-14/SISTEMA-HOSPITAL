using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reporte
    {
        public void MostrarPacienteNoInternadoUCI(NodoRegistroPaciente registropaciente,ListaCircularRegistoPaciente a)
        {
            Console.Clear();
            Console.WriteLine("Pacientes No Internados en UCI");
            Console.WriteLine();
            while (registropaciente.sgte!=a.lista) 
            { 
            if(registropaciente.CamaUCI=="No Internado")
                {
                    Console.WriteLine("Codigo Paciente : "+registropaciente.CodigoPaciente);
                    Console.WriteLine("Nombre Paciente : "+registropaciente.NombrePaciente);
                    Console.WriteLine("Hospital : "+registropaciente.HospitalRegistrado);
                    Console.WriteLine("Direccion : "+registropaciente.DireccionHospital);
                    Console.WriteLine("Servicio : "+registropaciente.ServicioRegistrado);
                    Console.WriteLine("Seguro: " + registropaciente.Seguro); 
                    Console.WriteLine("Estado : "+registropaciente.CamaUCI);
                    Console.WriteLine("**********************************************");
                }
                registropaciente = registropaciente.sgte;
            }
            if (registropaciente.CamaUCI == "No Internado") 
            { 
                Console.WriteLine("Codigo Paciente : " + registropaciente.CodigoPaciente);
            Console.WriteLine("Nombre Paciente : " + registropaciente.NombrePaciente);
            Console.WriteLine("Hospital : " + registropaciente.HospitalRegistrado);
            Console.WriteLine("Direccion : " + registropaciente.DireccionHospital);
            Console.WriteLine("Servicio : " + registropaciente.ServicioRegistrado);
            Console.WriteLine("Seguro: " + registropaciente.Seguro);
            Console.WriteLine("Estado : " + registropaciente.CamaUCI);
            Console.WriteLine("**********************************************");
            }
            Console.ReadKey();
        }
        public void MostrarPacientesInternadosUCI(NodoRegistroPaciente registropaciente,ListaCircularRegistoPaciente a)
        {
            Console.Clear();
            Console.WriteLine("Pacientes Internado");
            Console.WriteLine();
            bool encontrado=false;
            while (registropaciente.sgte != a.lista)
            {
                if (registropaciente.CamaUCI == "Internado")
                {
                    Console.WriteLine("Codigo Paciente : " + registropaciente.CodigoPaciente);
                    Console.WriteLine("Nombre Paciente : " + registropaciente.NombrePaciente);
                    Console.WriteLine("Hospital : " + registropaciente.HospitalRegistrado);
                    Console.WriteLine("Direccion : " + registropaciente.DireccionHospital);
                    Console.WriteLine("Servicio : " + registropaciente.ServicioRegistrado);
                    Console.WriteLine("Seguro : "+registropaciente.Seguro);
                    Console.WriteLine("Estado : " + registropaciente.CamaUCI);
                    Console.WriteLine("");
                    encontrado = true;
                }
                registropaciente = registropaciente.sgte;
            }
            if (registropaciente.CamaUCI == "Internado")
            {
                Console.WriteLine("Codigo Paciente : " + registropaciente.CodigoPaciente);
                Console.WriteLine("Nombre Paciente : " + registropaciente.NombrePaciente);
                Console.WriteLine("Hospital : " + registropaciente.HospitalRegistrado);
                Console.WriteLine("Direccion : " + registropaciente.DireccionHospital);
                Console.WriteLine("Servicio : " + registropaciente.ServicioRegistrado);
                Console.WriteLine("Seguro : " + registropaciente.Seguro);
                Console.WriteLine("Estado : " + registropaciente.CamaUCI);
                Console.WriteLine("");
                encontrado = true;
            }
            if (encontrado== false) 
            {
                Console.WriteLine("No hay Pacientes Internados en UCI");
            }
            Console.ReadKey();
        }
        public void MostrarPacientesHospitales(NodoHospital hospital,NodoRegistroPaciente registropaciente,ListaCircularRegistoPaciente a)
        {
            Console.Clear();
            
            while (hospital != null)
            {

                NodoRegistroPaciente t = registropaciente;
                Console.WriteLine(hospital.NomHospital);
                Console.WriteLine("************************************************");
                Console.WriteLine();
                while (t.sgte!= a.lista)
                {
                     if (hospital.NomHospital == t.HospitalRegistrado)
                    {
                        Console.WriteLine("Codigo Paciente : " + t.CodigoPaciente);
                        Console.WriteLine("Nombre Paciente : " + t.NombrePaciente);
                        Console.WriteLine("Servicio : " + t.ServicioRegistrado);
                        Console.WriteLine("Seguro : " + t.Seguro);
                        Console.WriteLine("Estado : " + t.CamaUCI);
                        Console.WriteLine("************************************************");
                        Console.WriteLine();

                    }
                    
                    t = t.sgte;

                }
                if (hospital.NomHospital == t.HospitalRegistrado)
                {
                    Console.WriteLine("Codigo Paciente : " + t.CodigoPaciente);
                    Console.WriteLine("Nombre Paciente : " + t.NombrePaciente);
                    Console.WriteLine("Servicio : " + t.ServicioRegistrado);
                    Console.WriteLine("Seguro : " + t.Seguro);
                    Console.WriteLine("Estado : " + t.CamaUCI);
                    Console.WriteLine("************************************************");
                    Console.WriteLine();

                }
                hospital = hospital.sgte;
            }
            Console.ReadKey();
        }
    }
}
