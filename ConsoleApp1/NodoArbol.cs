using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NodoArbol
    {
        public ProductoFarmacia Producto;
        public NodoArbol izq;
        public NodoArbol der;
        public NodoArbol( ProductoFarmacia Proudcto)
        {
            this.Producto = Proudcto;
            this.izq = null;
            this.der = null;
        }
    }
}
