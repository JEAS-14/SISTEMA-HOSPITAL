using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    internal class ProductoFarmacia
    {
        public int codigoProducto;
        public string nombreProducto;
        public int cantidadProdcuto;
        public double precioProducto;
        public string categoria;
        public ProductoFarmacia(int codgioP, string nombreP, int cantidadP, double precioP, string categoria) 
        {
            this.codigoProducto = codgioP;
            this.nombreProducto = nombreP;
            this.cantidadProdcuto = cantidadP;
            this.precioProducto = precioP;
            this.categoria = categoria;
        }
        public void MostrarProducto()
        {
            Console.WriteLine(" Codigo del Producto     : " + this.codigoProducto);
            Console.WriteLine(" Nombre del Producto     : " + this.nombreProducto);
            Console.WriteLine(" Cantidad del Producto   : " + this.cantidadProdcuto);
            Console.WriteLine($" Precio del Producto     : " + this.precioProducto);
            Console.WriteLine(" Categoria               : " + this.categoria);
        }
    }
}
