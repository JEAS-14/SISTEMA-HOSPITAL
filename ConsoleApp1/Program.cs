using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void GenerarServicio(ListaDobleServicios servicios)
        {
            servicios.InsertarServicio("Cardiología", 24, "SI", 2);
            servicios.InsertarServicio("Caumatología", 20, "SI", 3);
            servicios.InsertarServicio("Optometria", 25, "NO", 0);
            servicios.InsertarServicio("Cirujia", 21, "SI", 3);
            servicios.InsertarServicio("Obstetricia", 23, "SI", 2);
            servicios.InsertarServicio("Podologia", 26, "NO", 0);
        }
        public static void GenerarHospital(ListaHospital hospital)
        {
            hospital.InsertarHospital("Hospital San Juan de Lurigancho", "Av. Canto Grande – Paradero 11 – San Juan de Lurigancho", "Publico");
            hospital.InsertarHospital("Clínica Ricardo Palma", "Av. Javier Prado Este No. 1066, San Isidro", "Privado");
            hospital.InsertarHospital("Clínica Cayetano Heredia", "Av. Honorio Delgado No. 370 Urb. Ingeniería, S.M.P.", "Privado");
            hospital.InsertarHospital("Hospital Nacional Dos de Mayo", "Parque Historia de la Medicina Altura Cdra. 13 Av. Grau", "Publico");
            hospital.InsertarHospital("Clínica Internacional", "Av. El Polo No. 789 Urb. El Derby Monterrico, Surco", "Privado");
            hospital.InsertarHospital("Hospital Nacional Arzobispo Loayza", "Av. Alfonso Ugarte 848 – Cercado de Lima", "Publica");
        }
        public static void GenerarPacientes(PilaPaciente paciente)
        {
            paciente.Push(73219847, "Sofía González López", "ESSALUD");
            paciente.Push(74356201, "Martín Pérez Rodríguez", "ESSALUD");
            paciente.Push(75893426, "Valentina Torres Fernández", "SIS");
            paciente.Push(71234567, "Daniel Martínez García", "ESSALUD");
            paciente.Push(78901234, "Laura Rodríguez Sánchez", "SIS");
            paciente.Push(77654321, "Carlos Pérez García", "SIS");
            paciente.Push(70123456, "Ana López Martínez", "ESSALUD");
            paciente.Push(76789012, "Diego Sánchez Pérez", "SIS");
            paciente.Push(74567890, "María Fernández González", "ESSALUD");
            paciente.Push(72468953, "Javier García Torres", "ESSALUD");
        }
        public static void GenerarProductos(Arbol Producto)
        {
            ProductoFarmacia[] q = new ProductoFarmacia[4];
            q[0] = new ProductoFarmacia(3241, "Panadol", 80, 2.5, "Pastilla");
            q[1] = new ProductoFarmacia(2707, "Condones", 45, 5, "Preservativo");
            q[2] = new ProductoFarmacia(1491, "Azpirina", 50, 2.5, "Pastilla");
            q[3] = new ProductoFarmacia(1911, "Alcohol 100ml", 20, 3.8, "Acohol");
            for (int i = 0; i < 4; i++)
            {
                Producto.InsertarProducto(q[i]);
            }
            
        }
        

        static void Main(string[] args)
        {
            int opc = 0;
            ColaPrioridad colaprio = new ColaPrioridad();
            PilaPaciente listaPaciente=new PilaPaciente();
            ListaHospital listaHospital=new ListaHospital();
            ListaDobleServicios listaServicios=new ListaDobleServicios();
            ListaCircularRegistoPaciente listaRegistoPaciente=new ListaCircularRegistoPaciente();
            ListaTransferenciaPaciente listatransferencia = new ListaTransferenciaPaciente();
            Arbol Producto = new Arbol();
            GenerarPacientes(listaPaciente);
            GenerarServicio(listaServicios);
            GenerarHospital(listaHospital);
            GenerarProductos(Producto);
            Reporte reporte = new Reporte();
            
            do
            {
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tGestion de Hospital");
                    Console.WriteLine("\t*******************");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("1. Gestión de Hospitales");
                    Console.WriteLine("2. Gestión de Servicios");
                    Console.WriteLine("3. Gestión de UCI"); 
                    Console.WriteLine("4. Gestión de Paciente");
                    Console.WriteLine("5. Registro de Paciente");
                    Console.WriteLine("6. Cola de tiquet");
                    Console.WriteLine("7. Prioridad Ingreso");
                    Console.WriteLine("8. Transferencia");
                    Console.WriteLine("9. Reporte");
                    Console.WriteLine("10. Farmacia");
                    Console.WriteLine("11. Salir");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Escoga su opcion : ");
                    opc = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Blue;

                } while (opc < 0 || opc > 11);
                switch (opc)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\tHospital");
                            Console.WriteLine("\t********");
                            Console.WriteLine("1. Agregar");
                            Console.WriteLine("2. Eliminar");
                            Console.WriteLine("3. Actualizar");
                            Console.WriteLine("4. Mostrar");
                            Console.WriteLine("5. Regresar");
                            do
                            {
                                Console.Write("Ingrese su opcion : ");
                                opc = int.Parse(Console.ReadLine());
                            } while (opc < 0 && opc >= 5);
                            switch (opc)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\tAgregar Hospital");
                                    Console.WriteLine("\t****************");
                                    Console.Write("Ingrese el Nombre del Hospital : ");
                                    string NomHospital = Console.ReadLine();
                                    Console.Write("Ingrese la Direccion del Hospital : ");
                                    string DrcHospital = Console.ReadLine();
                                    Console.Write("Ingrese si el Hospital es Publica o Privada : ");
                                    string PubOPriv = Console.ReadLine();
                                    listaHospital.InsertarHospital(NomHospital, DrcHospital, PubOPriv);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\tEliminar Hospital");
                                    Console.WriteLine("\t*****************");
                                    listaHospital.EliminarHospital();

                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\tActualizar Hospital");
                                    Console.WriteLine("\t*******************");
                                    listaHospital.ModificarHospital();
                                    break;
                                case 4:
                                    Console.Clear();
                                    listaHospital.MostrarHospital();
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    break;

                            }
                        } while (opc != 5);
                        break;
                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\tServicios");
                            Console.WriteLine("\t**********");
                            Console.WriteLine("1. Agregar");
                            Console.WriteLine("2. Eliminar");
                            Console.WriteLine("3. Actualizar");
                            Console.WriteLine("4. Mostrar");
                            Console.WriteLine("5. Regresar");
                            do
                            {
                                Console.Write("Ingrese su opcion : ");
                                opc = int.Parse(Console.ReadLine());
                            } while (opc < 0 && opc >= 5);
                            switch (opc)
                            {
                                case 1:
                                    int camasUCI;
                                    Console.Clear();
                                    Console.WriteLine("\tAgregar Servicio");
                                    Console.WriteLine("\t****************");
                                    Console.Write("Ingrese el Nombre del Servicio : ");
                                    string NomServicio = Console.ReadLine();
                                    Console.Write("Ingrese el Numero de Habitaciones : ");
                                    int NumHab = int.Parse(Console.ReadLine());
                                    Console.Write("Es necesario las camas USI para este servicio (SI/NO): ");
                                    string x=Console.ReadLine();
                                    if (x == "SI")
                                    {
                                        Console.WriteLine("Ingrese la cantidad de camas USI");
                                        camasUCI = int.Parse(Console.ReadLine());
                                    }
                                    else
                                        camasUCI = 0;
                                    listaServicios.InsertarServicio(NomServicio, NumHab,x,camasUCI);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\tEliminar Servicio");
                                    Console.WriteLine("\t*****************");
                                    listaServicios.EliminarServicio();

                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\tActualizar Servicio");
                                    Console.WriteLine("\t*******************");
                                    listaServicios.ModificarServicio();
                                    break;
                                case 4:
                                    Console.Clear();
                                    listaServicios.MostrarServicios();
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    break;

                            }
                        } while (opc != 5);
                        break;
                    case 3:
                        do
                        {
                            NodoServicios servicios1 = listaServicios.lista;
                            NodoRegistroPaciente registroPaciente2 = listaRegistoPaciente.lista;
                            Console.Clear();
                            Console.WriteLine("\tGestion de UCI");
                            Console.WriteLine("\t**************");
                            Console.WriteLine("1. Internar Paciente en UCI");
                            Console.WriteLine("2. Retirar Paciente de UCI");
                            Console.WriteLine("3. Regresar");
                            do
                            {
                                Console.Write("Ingrese su opcion : ");
                                opc = int.Parse(Console.ReadLine());
                            } while (opc < 0 && opc >= 3);

                            switch (opc)
                            {

                                case 1: listaPaciente.InternarPacienteUSI(servicios1, registroPaciente2,listaRegistoPaciente); break;
                                case 2: listaPaciente.RetirarPacienteUCI(servicios1, registroPaciente2,listaRegistoPaciente); break;
                                case 3: break;
                            }
                        } while (opc != 3);
                        break;
                    case 4:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\tPacientes");
                            Console.WriteLine("\t**********");
                            Console.WriteLine("1. Agregar");
                            Console.WriteLine("2. Eliminar");
                            Console.WriteLine("3. Actualizar");
                            Console.WriteLine("4. Mostrar");
                            Console.WriteLine("5. Regresar");
                            do
                            {
                                Console.Write("Ingrese su opcion : ");
                                opc = int.Parse(Console.ReadLine());
                            } while (opc < 0 && opc >= 5);
                            switch (opc)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\tAgregar Paciente");
                                    Console.WriteLine("\t****************");
                                    Console.Write("Ingrese el DNI : ");
                                    int dni = int.Parse(Console.ReadLine());
                                    Console.Write("Ingrese el Nombre del Paciente : ");
                                    string NomPaciente = Console.ReadLine();
                                    Console.Write("Ingrese que seguro posee el Paciente (ESSALUD/SIS):");
                                    string seguro = Console.ReadLine();
                                    listaPaciente.Push(dni, NomPaciente, seguro);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\tEliminar Paciente");
                                    Console.WriteLine("\t******************");
                                    listaPaciente.Pop(listaPaciente);

                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\tActualizar Paciente");
                                    Console.WriteLine("\t*******************");
                                    listaPaciente.ModificarPaciente();
                                    break;
                                case 4:
                                    Console.Clear();
                                    listaPaciente.MuestraPila();
                                    Console.ReadKey();
                                    break;
                                case 5:
                                         break;

                            }
                        } while (opc != 5);
                        break;
                    case 5:
                        NodoHospital hospital = listaHospital.lista;
                        NodoPacientes pacientes = listaPaciente.pila;
                        NodoServicios servicios = listaServicios.lista;
                        Console.Clear();
                        listaRegistoPaciente.RegistrarPaciente(hospital, servicios, pacientes);
                        break;
                    case 6:
                        GeneradorTiquet generar=new GeneradorTiquet();
                        generar.Inicializar(colaprio);
                        break;
                    case 7:
                        Console.Clear();
                        colaprio.mostrar();
                        break;
                    case 8:
                        Console.Clear(); ;
                        Console.WriteLine("Transferencia");
                        Console.WriteLine("1. Realizar una transferencia");
                        Console.WriteLine("2. Mostrar las transferencias realizadas");
                        Console.Write("Ingrese su opcion : ");
                        opc = int.Parse(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                NodoHospital hospital2 = listaHospital.lista;
                                NodoRegistroPaciente registroPaciente = listaRegistoPaciente.lista;
                                Console.Clear();

                                listatransferencia.MostrarPacientesaTransferir(registroPaciente, listaRegistoPaciente, hospital2);
                                Console.ReadKey();
                                break;
                            case 2:
                                PilaTramferencia pilatrans = new PilaTramferencia();
                                pilatrans.Agregar(listatransferencia);
                                pilatrans.Mostrar();
                                break;
                            default:
                                break;

                        }
                        break;
                    case 9:
                        do
                        {
                            NodoHospital hospital1 = listaHospital.lista;
                            NodoRegistroPaciente registroPaciente1 = listaRegistoPaciente.lista;
                            Console.Clear();
                            Console.WriteLine("\tReportes");
                            Console.WriteLine("\t********");
                            Console.WriteLine("1. Reporte Pacientes Internado");
                            Console.WriteLine("2. Reporte Pacientes no Internados");
                            Console.WriteLine("3. Reporte de Pacientes por hospitales");
                            Console.WriteLine("4. Regresar");
                            do
                            {
                                Console.Write("Ingrese su opcion : ");
                                opc = int.Parse(Console.ReadLine());
                            } while (opc < 0 && opc >= 3);
                            switch (opc)
                            {
                                case 1: reporte.MostrarPacientesInternadosUCI(registroPaciente1, listaRegistoPaciente); break;
                                case 2: reporte.MostrarPacienteNoInternadoUCI(registroPaciente1, listaRegistoPaciente); break;
                                case 3:
                                    NodoRegistroPaciente registroPacientes = listaRegistoPaciente.lista;
                                    reporte.MostrarPacientesHospitales(hospital1, registroPacientes, listaRegistoPaciente); break;
                                case 4: break;
                            }
                        } while (opc != 4);
                        break;
                    case 10:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\tFarmacia");
                            Console.WriteLine("\t**********");
                            Console.WriteLine("1. Agregar Producto");
                            Console.WriteLine("2. Eliminar Producto");
                            Console.WriteLine("3. Buscar Productos");
                            Console.WriteLine("4. Mostrar Productos");
                            Console.WriteLine("5. Regresar");
                            Console.Write("Ingrese su opcion : ");
                            opc = int.Parse(Console.ReadLine());
                            switch(opc)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("Agregar Codigo de 4 Digitos : ");
                                    int c = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.Write("Agregar Nombre del Producto : ");
                                    string n = Console.ReadLine();
                                    Console.WriteLine();
                                    Console.Write("Ingrese Cantidad del Prodcuto : ");
                                    int cant = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.Write("Ingrese el Precio del Producto : ");
                                    double p = double.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.Write("Ingrese la Categoria : ");
                                    string cat = Console.ReadLine();
                                    Console.WriteLine();
                                    ProductoFarmacia NUEVO = new ProductoFarmacia(c, n, cant, p, cat);
                                    Producto.InsertarProducto(NUEVO);
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\tEliminacion de Producto");
                                        Console.WriteLine("1. Eliminar un Producto");
                                        Console.WriteLine("2. Eliminar Todos los Productos");
                                        Console.WriteLine("3. Regresar");
                                        Console.Write("Ingrese su opcion : ");
                                        opc = int.Parse(Console.ReadLine());
                                        switch (opc)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Producto.mostrarProductos();
                                                Console.WriteLine();
                                                Console.Write("Ingrese el Codigo del Producto : ");
                                                cant = int.Parse(Console.ReadLine());
                                                Producto.EliminarB(cant);
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Producto.Vaciar();
                                                Console.WriteLine("Se elimino todos los Productos");
                                                Console.ReadKey();
                                                break;
                                        }
                                    } while (opc!=3);
                                    break;
                                case 3:
                                    Console.Clear();
                                    Producto.mostrarProductos();
                                    Console.WriteLine();
                                    Console.Write("Ingrese el Codigo del Producto : ");
                                    int buscar = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    Producto.buscarProd(buscar);
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Producto.mostrarProdArb(Producto.arbol, 0);
                                    Console.ReadKey();
                                    break;
                            }
                        } while (opc !=5);
                        break;
                }
            } while (opc!=10 );
            
            Console.ReadKey();

        }
    }
}
