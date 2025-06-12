using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ColaPrioridad
    {
        public NodoPrioridad colaprio;
        public ColaPrioridad()
        {
            colaprio = null;
        }
        public void queuePrioridad(string personas, int prio)
        {
            NodoPrioridad q = new NodoPrioridad(personas, prio);
            NodoPrioridad t = colaprio;
            NodoPrioridad ant = null;

            if (colaprio == null)
            {
                colaprio = q;
            }
            else
            {
                while (t != null)
                {
                    if (prio <= t.prioridad && t == colaprio) // primero y unico
                    {
                        q.sgte = colaprio;
                        colaprio = q;
                        return;
                    }
                    else if (prio<=t.prioridad) // intermedio                    
                    {
                        ant.sgte = q;
                        q.sgte = t;
                        return;
                    }
                    else if (t.sgte == null && t.prioridad < prio) // final
                    {
                        t.sgte = q;
                        return;
                    }
                    ant = t;
                    t = t.sgte;
                }
            }
        }
        public void mostrar()
        {
            string atencion;
            NodoPrioridad q = colaprio;
            Console.Write("Inicio de la cola");
            while (q != null)
            {
                Console.Write(" -> ");
                if (q.prioridad == 1)
                {

                    atencion = "Atencion General";
                    Console.Write("("+q.personas+" , "+atencion+")");
                }
                if(q.prioridad == 2)
                {
                    atencion = "Atencion Preferencial";
                    Console.Write("(" + q.personas + " , " + atencion + ")");
                }
                if(q.prioridad == 3)
                {
                    atencion = "Urgencia";
                    Console.Write("(" + q.personas + " , " + atencion + ")");
                }
                q = q.sgte;
            }
            Console.ReadKey();
        }
        public void dequeuePrioridad()
        {
            NodoPrioridad t = colaprio;
            NodoPrioridad ant = null;
            if (colaprio == null)
            {
                Console.WriteLine("La cola esta vacia ... ");
            }
            else
            {
                if (colaprio.sgte == null)
                {
                    colaprio = null;
                }
                else
                {
                    while (t.sgte != null)
                    {
                        ant = t;
                        t = t.sgte;
                    }
                    ant.sgte = null;
                }
            }
        }
    }
}
