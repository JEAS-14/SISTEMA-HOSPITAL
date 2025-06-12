using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListaDobleServicios
    {
        public NodoServicios lista;
        public ListaDobleServicios()
        {
            lista = null;
        }
        public void InsertarServicio(string servicios, int numHabitaciones,string necesidadDeCamasUCI,int camasUCI)
        {
            NodoServicios q = new NodoServicios(servicios, numHabitaciones, necesidadDeCamasUCI, camasUCI);
            if (lista == null)
            {
                q.Servicios = servicios;
                q.NumHabitaciones = numHabitaciones;
                q.NecesidadDeCamasUCI=necesidadDeCamasUCI;
                lista = q;
            }
            else
            {
                q.Servicios = servicios;
                q.NumHabitaciones = numHabitaciones;
                q.NecesidadDeCamasUCI = necesidadDeCamasUCI;
                q.CamasUCI = camasUCI;
                q.sgte = lista;
                lista.ant = q;
                lista = q;
            }
        }
        public void MostrarServicios()
        {
            NodoServicios t = lista;
            Console.WriteLine("-------------------------");
            Console.WriteLine("|\tServicios\t|");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|\t" + "{0}{1}{2}{3}{4}", "Servicios".PadRight(15, ' '), "|".PadRight(2, ' '), "Numeros de Habitaciones".PadRight(30, ' '), "|".PadRight(2, ' '), "Numero de Camas" + "\t|");
            Console.WriteLine("---------------------------------------------------------------------------------");
            while (t!=null)
            {
                Console.WriteLine("|\t"+ "{0}{1}{2}{3}{4}", t.Servicios.PadRight(15,' '), "|".PadRight(2, ' '), t.NumHabitaciones.ToString().PadRight(30,' '), "|".PadRight(2, ' '), t.CamasUCI+"\t\t\t|");
                Console.WriteLine("---------------------------------------------------------------------------------");
                t = t.sgte;
            }
        }
        public void EliminarServicio()
        {
            bool encontrado = false;
            NodoServicios ant = lista;
            int codigo = 1, num;
            NodoServicios t = lista;
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|\t" + "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Servicios" + "\t\t|");
            Console.WriteLine("-----------------------------------------");
            while (t != null)
            {
                Console.WriteLine("|\t"+ "{0}{1}{2}{3}", codigo++.ToString().PadRight(10, ' '), "|".PadRight(2, ' '), t.Servicios.PadRight(20,' '),"|".PadRight(2,' '));
                Console.WriteLine("-----------------------------------------");
                t = t.sgte;
            }
            Console.WriteLine("Ingrese el codigo del servicio : ");
            num = int.Parse(Console.ReadLine());
            codigo = 1;
            t = lista;
            while (t != null)
            {
                if (num == codigo)
                {
                    if (t == lista)
                    {
                        lista = lista.sgte;
                    }
                    else
                    {
                        ant.sgte = t.sgte;
                    }
                    encontrado = true;
                    break;
                }
                codigo++;
                ant = t;
                t = t.sgte;
            }
            if (encontrado)
            {
                Console.Clear();
                Console.WriteLine(t.Servicios + " eliminado");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Codigo incorrecto");
                Console.ReadKey();
            }
        }
        public void ModificarServicio()
        {
            bool encontrado = false;
            int codigo = 1, num, opc;
            NodoServicios t = lista;
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|\t" + "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Servicios" + "\t\t|");
            Console.WriteLine("-----------------------------------------");
            while (t != null)
            {
                Console.WriteLine("|\t" + "{0}{1}{2}{3}", codigo++.ToString().PadRight(10, ' '), "|".PadRight(2, ' '), t.Servicios.PadRight(20, ' '), "|".PadRight(2, ' '));
                Console.WriteLine("-----------------------------------------");
                t = t.sgte;
            }
            Console.WriteLine("Ingrese el codigo del Paciente : ");
            num = int.Parse(Console.ReadLine());
            codigo = 1;
            t = lista;
            while (t != null)
            {
                if (num == codigo)
                {
                    encontrado = true;
                    do
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("{0}", t.Servicios);
                            Console.WriteLine("1. Actualizar Servicio");
                            Console.WriteLine("2. Actualizar Numero de Habitaciones");
                            Console.WriteLine("3. Actualizar la Necesidad de Camas USI");
                            Console.WriteLine("4. Actualizar la cantidad de Camas USI");
                            Console.WriteLine("5. Regresar");
                            Console.WriteLine("Ingrese su opcion : ");
                            opc = int.Parse(Console.ReadLine());
                        } while (opc < 0 || opc >= 6);
                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Ingrese el Nuevo Servicio");
                                t.Servicios = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Ingrese la Nueva Cantidad de Habitaciones");
                                t.NumHabitaciones = int.Parse(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("Ingrese la necesidad de Camas US (SI/NO)");
                                t.NecesidadDeCamasUCI=Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Ingrese la Nueva cantida de Camas USI");
                                t.CamasUCI=int.Parse(Console.ReadLine());
                                break; 
                            case 5:
                                break;
                        }
                    } while (opc != 5);
                }
                codigo++;
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
    }
}
