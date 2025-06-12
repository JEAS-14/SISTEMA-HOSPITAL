using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Arbol
    {
        public NodoArbol arbol;
        public Arbol()
        {
            arbol = null;
        }
        public void InsertarProducto(ProductoFarmacia nuevo)
        {
            NodoArbol q = new NodoArbol(nuevo);
            NodoArbol t = arbol;
            int valorRaiz;
            if (arbol == null)
            {
                arbol = q;
            }else
            {
                while (t != null)
                {
                    valorRaiz = t.Producto.codigoProducto;
                    if (nuevo.codigoProducto < valorRaiz)
                    {
                        if (t.izq != null)
                        {
                            t = t.izq;
                        }
                        else
                        {
                            t.izq = q;
                            return;
                        }
                    }else
                    {
                        if (t.der != null)
                        {
                            t = t.der;
                        }
                        else
                        {
                            t.der = q;
                            return;

                        }
                    }
                }
            }
        }
        public void mostrarProd(NodoArbol arb)
        {
            if (arb!=null)
            {
                mostrarProd(arb.izq);
                Console.WriteLine($"Codigo : " + arb.Producto.codigoProducto.ToString().PadRight(5,' ')+"||" + " Producto : " + arb.Producto.nombreProducto.PadRight(15, ' ') + "||" + " Precio : " + arb.Producto.precioProducto.ToString().PadRight(10, ' '));
                mostrarProd(arb.der);
            }
        }
        public void mostrarProdArb(NodoArbol arb, int cont)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                mostrarProdArb(arb.der, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("        ");
                }
                Console.WriteLine("( " + arb.Producto.codigoProducto + " , " + arb.Producto.nombreProducto + " )");
                mostrarProdArb(arb.izq, cont + 1);
            }
        }
        public void mostrarProductos()
        {
            Console.WriteLine("Productos en la Farmacia:");
            mostrarProd(arbol);
        }
        
        public void buscarProd(int buscado)
        {
            NodoArbol t = arbol;
            int valorRaiz;

            Console.WriteLine("\nProceso de Busqueda en la Farmacia");
            Console.WriteLine("--------------------------------");
            if (arbol == null)
            {
                Console.WriteLine("No hay ningun producto en la Farmacia");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.Producto.codigoProducto;
                    if (buscado == valorRaiz)
                    {
                        Console.WriteLine("\nProducto Encontrado");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(" Codigo      : " + t.Producto.codigoProducto);
                        Console.WriteLine(" Nombre      : " + t.Producto.nombreProducto);
                        Console.WriteLine(" Cantidad    : " + t.Producto.cantidadProdcuto);
                        Console.WriteLine(" Precio      : " + t.Producto.precioProducto);
                        Console.WriteLine(" Categoria   : " + t.Producto.categoria);
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        return;
                    }
                    else if (buscado < valorRaiz)
                    {
                        if (t.izq != null)
                        {

                            Console.WriteLine($"Codigo : " + t.Producto.codigoProducto.ToString().PadRight(5, ' ') + "||" + " Producto : " + t.Producto.nombreProducto.PadRight(15, ' '));
                            t = t.izq;
                        }
                        else
                        {
                            Console.WriteLine("***Prodcuto no encontrado***");
                            return;
                        }
                    }
                    else
                    {
                        if (t.der != null)
                        {
                            Console.WriteLine($"Codigo : " + t.Producto.codigoProducto.ToString().PadRight(5, ' ') + "||" + " Producto : " + t.Producto.nombreProducto.PadRight(15, ' '));
                            t = t.der;
                        }
                        else
                        {
                            Console.WriteLine("***Prodcuto no encontrado***");
                            return;
                        }
                    }
                }
            }

        }
        public bool EstaVacio()
        {
            if (arbol == null)
                return true;
            else
                return false;
        }
        public bool eliminar(NodoArbol arb)
        {
            NodoArbol NodoActual = arbol, Padre = null;
            while (NodoActual.Producto.codigoProducto != arb.Producto.codigoProducto)
            {
                if(arb.Producto.codigoProducto < NodoActual.Producto.codigoProducto)
                {
                    Padre = NodoActual;
                    NodoActual = NodoActual.izq;
                }else
                {
                    if(arb.Producto.codigoProducto> NodoActual.Producto.codigoProducto)
                    {
                        Padre = NodoActual;
                        NodoActual = NodoActual.der;
                    }
                }
                if (NodoActual == null)
                {
                    return false;
                }
            }
            if (NodoActual.der == null)
            {
                if (Padre == null)
                    arbol = NodoActual.izq;
                else
                {
                    if (Padre.Producto.codigoProducto>NodoActual.Producto.codigoProducto)
                    {
                        Padre.izq= NodoActual.izq;
                    }
                    else
                    {
                        if (Padre.Producto.codigoProducto < NodoActual.Producto.codigoProducto)
                        {
                            Padre.der = NodoActual.der;
                        }
                    }
                }
            }
            else
            {
                if(NodoActual.der.izq == null)
                {
                    NodoActual.der.izq = NodoActual.izq;
                    if (Padre == null)
                        arbol = NodoActual.der;
                    else
                    {
                        if (Padre.Producto.codigoProducto > NodoActual.Producto.codigoProducto)
                            Padre.izq = NodoActual.der;
                        else
                        {
                            if (Padre.Producto.codigoProducto < NodoActual.Producto.codigoProducto)
                                Padre.der = NodoActual.der;
                        }
                    }
                }
                else
                {
                    NodoArbol NodoMenor = NodoActual.der.izq,
                        PadreDelNodoMenor = NodoActual.der;
                    while (NodoMenor.izq != null)
                    {
                        PadreDelNodoMenor = NodoMenor;
                        NodoMenor = NodoMenor.izq;
                    }
                    PadreDelNodoMenor.izq = NodoMenor.der;
                    NodoMenor.izq = NodoActual.izq;
                    NodoMenor.der = NodoActual.der;
                    if (Padre == null)
                        arbol = NodoMenor;
                    else
                    {
                        if (Padre.Producto.codigoProducto > NodoActual.Producto.codigoProducto)
                            Padre.izq = NodoMenor;
                        else
                        {
                            if (Padre.Producto.codigoProducto < NodoActual.Producto.codigoProducto)
                                Padre.der = NodoMenor;
                        }
                    }
                }
            }
            return true;
        }
        private void RecorrerYBorrar(NodoArbol NodoActual)
        {
            if (NodoActual != null)
            {
                //Recorre el arbol por la izquierda
                RecorrerYBorrar(NodoActual.izq);
                //Recorrer el arbol por la derecha
                RecorrerYBorrar(NodoActual.der);
                eliminar(NodoActual); //Elimina el nodo actual
            }
        }
        public void Vaciar()
        {
            if (!EstaVacio()) //Si no esta vacio
            {
                //Recorrer el arbol y eliminar cada uno de los nodos
                RecorrerYBorrar(arbol);
                arbol = null;
            }
        }
        public void EliminarB(int buscado)
        {
            NodoArbol t = arbol;
            int valorRaiz;
            if (arbol == null)
            {
                Console.WriteLine("No hay ningun producto en la Farmacia");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.Producto.codigoProducto;
                    if (buscado == valorRaiz)
                    { 
                        eliminar(t);
                        return;
                    }
                    else if (buscado < valorRaiz)
                    {
                        if (t.izq != null)
                        {
                            eliminar(t);
                            t = t.izq;
                        }
                        else
                        {
                            Console.WriteLine("***Prodcuto no encontrado***");
                            return;
                        }
                    }
                    else
                    {
                        if (t.der != null)
                        {
                            eliminar(t);
                            t = t.der;
                        }
                        else
                        {
                            Console.WriteLine("***Prodcuto no encontrado***");
                            return;
                        }
                    }
                }
            }
        }
    }
}
