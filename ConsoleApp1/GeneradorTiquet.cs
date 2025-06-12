using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GeneradorTiquet
    {
        public void Inicializar(ColaPrioridad prioridad)
        {
            ColaTiquet cola = new ColaTiquet();
            string[] nombres = { "María", "Laura", "Ana", "Isabel", "Carmen", "Paula", "Sofía", "Patricia", "Gabriela", "Lucía", "Juan", "Carlos", "Alejandro", "José", "Francisco", "Luis", "Antonio", "Roberto", "Manuel", "Javier" };
            string[] apellidos = { "García", "Rodríguez", "Martínez", "López", "González", "Pérez", "Sánchez", "Ramírez", "Torres", "Flores", "Díaz", "Jiménez", "Ruiz", "Moreno", "Herrera", "Castro", "Silva", "Vargas", "Ortiz", "Mendoza" };
            Random r = new Random();
            int dni, idxNom, idxApe, ope, cate, monto,x;
            int cont = 0;
            while (cont < 20)
            {
                ope = r.Next(0, 2);
                Console.Clear();
                if (ope == 0)
                {
                    cont++;
                    dni = r.Next(10000000, 100000000);
                    idxNom = r.Next(0, 20);
                    idxApe = r.Next(0, 20);
                    cate = r.Next(1, 4);
                    if (cate == 1)
                    {
                        monto = 100;
                    }
                    else if (cate == 2)
                    {
                        monto = 150;
                    }
                    else
                    {
                        monto = 200;
                    }
                    Personas p = new Personas(nombres[idxNom], apellidos[idxApe], dni, "Medicina General", cate, monto);
                    x=r.Next(1,4);

                    prioridad.queuePrioridad(nombres[idxNom], x);

                    Console.WriteLine("Nuevo Cliente");
                    p.MostrarPersonas();
                    cola.queue(p);
                    Console.WriteLine();
                    cola.mostrarCola();
                }
                else
                {
                    Personas pAux = cola.dequeue();
                    if (pAux != null)
                    {
                        cont++;
                        Console.WriteLine("Se vendio una Entrada");
                        pAux.MostrarPersonas();
                        Console.WriteLine();
                        cola.mostrarCola();
                    }
                    else
                    {
                        Console.WriteLine("No hay clientes en la cola");
                    }
                }
                Console.WriteLine("Numero de operaciones : " + cont);
                Console.ReadKey();
            }
        }
    }
}
