using System;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class PilaPaciente
    {
        public int Num = 1;
        public NodoPacientes pila;
        public PilaPaciente()
        {
            pila=null;
        }
        //Metodo para insertar pacientes
        public void Push(int codigoDNI, string NomPaciente, string seguro)
        {
            NodoPacientes q = new NodoPacientes(codigoDNI,NomPaciente,seguro);
            q.CodigoDePaciente = q.CodigoDePaciente + Num++; ;
            q.CodigoDni = codigoDNI;
            q.NombrePaciente= NomPaciente;
            q.Seguro = seguro;
            q.sgte = pila;
            pila = q;
        }
        public void MuestraPila()
        {
            NodoPacientes t=pila;
            Console.WriteLine("-------------------------");
            Console.WriteLine("|\tPacientes\t|");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("|\t"+ "{0}{1}{2}{3}{4}{5}{6}{7}{8}", "Codigo".PadRight(10,' '), "|".PadRight(2, ' '), "DNI".PadRight(10,' '), "|".PadRight(2, ' '), "Nombre del Paciente".PadRight(30,' '), "|".PadRight(2, ' '), "Seguro".PadRight(10,' '), "|".PadRight(2, ' '), "UCI" +"\t\t\t|");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            while (t != null)
            {
                Console.WriteLine("|\t"+ "{0}{1}{2}{3}{4}{5}{6}{7}{8}", t.CodigoDePaciente.ToString().PadRight(10,' '), "|".PadRight(2, ' '),t.CodigoDni.ToString().PadRight(10,' '), "|".PadRight(2, ' '),t.NombrePaciente.PadRight(30,' '), "|".PadRight(2, ' '),t.Seguro.PadRight(10,' '), "|".PadRight(2, ' '),t.CamaUCI+"\t|");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                t = t.sgte;
            }
        }
        public void Pop(PilaPaciente paciente)
        {
            bool a = false;
            int num;
            NodoPacientes t = pila;
            PilaPaciente aux = new PilaPaciente();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|\t" + "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Nombre Paciente" + "\t\t|");
            Console.WriteLine("-------------------------------------------------");
            while (t != null)
            {
                Console.WriteLine("|\t" + "{0}{1}{2}", t.CodigoDePaciente.ToString().PadRight(10, ' '), "|".PadRight(2, ' '), t.NombrePaciente.PadRight(20, ' ') + "\t|");
                Console.WriteLine("-------------------------------------------------");
                t = t.sgte;
            }
            Console.WriteLine("Ingrese el codigo del Paciente : ");
            num = int.Parse(Console.ReadLine());
            int x = 1010-num;
            Num = Num - x;
            t = pila;
            if (t.CodigoDePaciente - num == 0)
            {
                pila = pila.sgte;

            }
            for (int i = 0; i < x; i++)
            {
                if (t != null)
                {
                        aux.Push(t.CodigoDni, t.NombrePaciente, t.Seguro);
                        pila = pila.sgte;
                        t = t.sgte;
                        a = true;
                }
                else
                {
                    Console.WriteLine("No hay pacientes ");
                }
            }
            if (a) {
            pila = pila.sgte;
            NodoPacientes q = aux.pila;
            for (int i = 0; i < x; i++)
            {
                if (q != null)
                {
                    paciente.Push(q.CodigoDni,q.NombrePaciente,q.Seguro);
                    q.CodigoDePaciente= q.CodigoDePaciente - 1000;
                    q=q.sgte;
                }
            }
            }
            Console.ReadKey();
        }
        public void ModificarPaciente()
        {
            bool encontrado = false;
            int num, opc;
            NodoPacientes t = pila;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|\t" + "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Nombre Paciente" + "\t\t|");
            Console.WriteLine("-------------------------------------------------");
            while (t != null)
            {
                Console.WriteLine("|\t" + "{0}{1}{2}", t.CodigoDePaciente.ToString().PadRight(10, ' '), "|".PadRight(2, ' '), t.NombrePaciente.PadRight(20, ' ') + "\t|");
                Console.WriteLine("-------------------------------------------------");
                t = t.sgte;
            }
            Console.WriteLine("Ingrese el codigo del Paciente : ");
            num = int.Parse(Console.ReadLine());
            t = pila;
            while (t != null)
            {
                if (num == t.CodigoDePaciente)
                {
                    encontrado = true;
                    do
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("{0}", t.NombrePaciente);
                            Console.WriteLine("1. Actualizar Nombre del Paciente");
                            Console.WriteLine("2. Actualizar DNI del Paciente");
                            Console.WriteLine("3. Actualizar Seguro del Paciente");
                            Console.WriteLine("4. Actualizar el uso de la Cama UCI");
                            Console.WriteLine("5. Regresar");
                            Console.WriteLine("Ingrese su opcion : ");
                            opc = int.Parse(Console.ReadLine());
                        } while (opc < 0 || opc >= 5);
                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Ingrese el nuevo Nombre");
                                t.NombrePaciente = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Ingrese la nueva Direccion");
                                t.CodigoDni = int.Parse(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("Ingrese el nuevo Seguro");
                                t.Seguro = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Ingrese la acualizacion de la cama UCI");
                                t.CamaUCI = Console.ReadLine();
                                break;
                            case 5:
                                break;
                        }
                    } while (opc !=5);
                }
                t = t.sgte;
            }
            if (encontrado)
            {
                Console.WriteLine("Modificacion exitosa");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Codigo incorrecto");
                Console.ReadKey();
            }

        }
        public void InternarPacienteUSI(NodoServicios servicios, NodoRegistroPaciente regte,ListaCircularRegistoPaciente a)
        {
            Console.Clear();
            NodoServicios ser = servicios;
            NodoRegistroPaciente registro = regte;
            bool Encontrado = false;
            bool encontrado = false;
            Console.WriteLine("Internar Paciente en USI");
            Console.WriteLine("*************************");
            
            Console.WriteLine("Codigo ".PadRight(10, ' ') + "Nombre Paciente".PadRight(30, ' ')+"Servicio".PadRight(15,' ') + "Estado");
            
            while (registro.sgte != a.lista)
            {
                if(registro.CamaUCI == "No Internado")
                {
                    ser = servicios;
                    while (ser != null)
                    {
                        if (ser.NecesidadDeCamasUCI == "SI" && registro.ServicioRegistrado==ser.Servicios)
                        {
                            Console.WriteLine(registro.CodigoPaciente.ToString().PadRight(10, ' ') + registro.NombrePaciente.PadRight(30, ' ') + registro.ServicioRegistrado.PadRight(15,' ') + registro.CamaUCI );
                            encontrado=true;
                            break;
                        }
                        ser = ser.sgte;
                    }
                    
                }
                registro = registro.sgte;
            }
            ser = servicios;
            if (registro.CamaUCI == "No Internado")
            {
                ser = servicios;
                while (ser != null)
                {
                    if (ser.NecesidadDeCamasUCI == "SI" && registro.ServicioRegistrado == ser.Servicios)
                    {
                        Console.WriteLine(registro.CodigoPaciente.ToString().PadRight(10, ' ') + registro.NombrePaciente.PadRight(30, ' ') + registro.ServicioRegistrado.PadRight(15, ' ') + registro.CamaUCI);
                        encontrado = true;
                        break;
                    }
                    ser = ser.sgte;
                }

            }
            if (encontrado == true)
            {
                Console.WriteLine("Ingrese el Codigo del Paciente al que desea internar a UCI");
                int cod = int.Parse(Console.ReadLine());
                NodoRegistroPaciente regpac = regte;
                while (regpac.sgte != a.lista)
                {
                    if (cod == regpac.CodigoPaciente)
                    {
                        Encontrado = false;
                        ser = servicios;
                        while (ser != null)
                        {
                            if (regpac.ServicioRegistrado == ser.Servicios)
                            {
                                if (ser.CamasUCI != 0)
                                {
                                    Encontrado = true;
                                    int x = ser.CamasUCI - 1; ;
                                    ser.CamasUCI = x;
                                    break;
                                }
                                if (ser.CamasUCI == 0)
                                {
                                    Console.WriteLine("No hay camas UCI disponibles");
                                    Console.ReadKey();
                                }

                            }


                            else
                            {
                                Encontrado = false;
                            }
                            ser = ser.sgte;
                        }
                        if (Encontrado == true)
                        {
                            regpac.CamaUCI = "Internado";
                            Console.WriteLine("Paciente internado");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Codigo incorrecto");
                        }
                    }
                    regpac = regpac.sgte;
                }
                Encontrado = false;
                ser = servicios;
                while (ser != null)
                {
                    if (regpac.ServicioRegistrado == ser.Servicios)
                    {
                        if (ser.CamasUCI != 0)
                        {
                            Encontrado = true;
                            int x = ser.CamasUCI - 1; ;
                            ser.CamasUCI = x;
                            break;
                        }
                        if (ser.CamasUCI == 0)
                        {
                            Console.WriteLine("No hay camas UCI disponibles");
                            Console.ReadKey();
                        }

                    }


                    else
                    {
                        Encontrado = false;
                    }
                    ser = ser.sgte;
                }
                if (Encontrado == true)
                {
                    regpac.CamaUCI = "Internado";
                    Console.WriteLine("Paciente internado");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Codigo incorrecto");
                }
            }
            else
            {
                Console.WriteLine("No hay Pacientes registrado en los Hospitales");
                Console.ReadKey();
            }
        }
        public void RetirarPacienteUCI(NodoServicios servicios,NodoRegistroPaciente regte,ListaCircularRegistoPaciente a)
        {Console.Clear();
            NodoServicios ser = servicios;
            NodoRegistroPaciente registro = regte;
            bool encontrado = false;
            Console.WriteLine("Retirar Paciente de USI");
            Console.WriteLine("*************************");

            Console.WriteLine("Codigo ".PadRight(10, ' ') + "Nombre Paciente".PadRight(30, ' ') + "Servicio".PadRight(15, ' ') + "Estado");

            while (registro.sgte != a.lista) 
            {
                if (registro.CamaUCI == "Internado")
                    {
                    ser = servicios;
                    while (ser != null)
                    {
                        if (ser.NecesidadDeCamasUCI == "SI")
                        {
                            Console.WriteLine(registro.CodigoPaciente.ToString().PadRight(10, ' ') + registro.NombrePaciente.PadRight(30, ' ') + registro.ServicioRegistrado.PadRight(15, ' ') + registro.CamaUCI);
                            encontrado = true;
                            break;
                        }
                        ser = ser.sgte;
                    } 
                }
                registro = registro.sgte;
            }
            if (registro.CamaUCI == "Internado")
            {
                Console.WriteLine(registro.CodigoPaciente.ToString().PadRight(10, ' ') + registro.NombrePaciente.PadRight(30, ' ') + registro.ServicioRegistrado.PadRight(15, ' ') + registro.CamaUCI);
                encontrado = true;
            }
            if (encontrado == true)
            {
                Console.WriteLine("Ingrese el Codigo del Paciente al que desea retirar de UCI");
                int cod = int.Parse(Console.ReadLine());
                registro = regte;
                ser = servicios;

                while (registro.sgte != a.lista)
                {
                    if (cod == registro.CodigoPaciente)
                    {
                        bool Encontrado = false;
                        ser = servicios;
                        while (ser != null)
                        {


                            if (registro.ServicioRegistrado == ser.Servicios)
                            {
                                Encontrado = true;
                                int x = ser.CamasUCI+1 ;
                                ser.CamasUCI = x;
                                break;
                                
                            }


                            else
                            {
                                Encontrado = false;
                            }
                            ser = ser.sgte;
                        }
                        if (Encontrado == true)
                        {
                            registro.CamaUCI = "No Internado";
                            Console.WriteLine("Paciente retirado");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Codigo incorrecto");
                        }
                    }
                    registro = registro.sgte;
                }
                
                if (cod == registro.CodigoPaciente)
                {
                    bool Encontrado = false;
                    ser = servicios;
                    while (ser != null)
                    {
                        if (registro.ServicioRegistrado == ser.Servicios)
                        {
                            Encontrado = true;
                            int x = ser.CamasUCI + 1;
                            ser.CamasUCI = x;
                            break;

                        }


                        else
                        {
                            Encontrado = false;
                        }
                        ser = ser.sgte;
                    }
                    if (Encontrado == true)
                    {
                        registro.CamaUCI = "No Internado";
                        Console.WriteLine("Paciente retirado");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Codigo incorrecto");
                    }
                }


            }
            else
            {
                Console.WriteLine("No hay Pacientes registrado en los Hospitales");
                Console.ReadKey();
            }
        }
    }
}
