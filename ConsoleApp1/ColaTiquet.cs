using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ColaTiquet
    {
        NodoCola cola;
        public ColaTiquet()
        {
            cola = null;
        }
        public void queue(Personas pers)
        {
            NodoCola q = new NodoCola(pers);
            q.sgte = cola;
            cola = q;
        }
        public Personas dequeue()
        {
            NodoCola t = cola;
            NodoCola ant = null;
            if (cola == null)
            {
                Console.WriteLine("Cola vacia");
                return null;
            }
            else
            {
                while (t.sgte != null)
                {
                    ant = t;
                    t = t.sgte;
                }
                if (cola.sgte == null)
                {
                    cola = null;
                }
                else
                {
                    ant.sgte = null;
                }
                return t.pers;
            }
        }
        public void mostrarCola()
        {
            NodoCola t = cola;
            if (cola == null)
            {
                Console.WriteLine("Cola vacia");
            }
            else
            {
                Console.Write(" Cola ");
                while (t != null)
                {
                    Console.Write(" -> " + (t.pers.Nombre));
                    t = t.sgte;
                }
            }
            Console.WriteLine();
        }
    }
}
