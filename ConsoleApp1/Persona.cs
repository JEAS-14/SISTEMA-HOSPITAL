using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Personas
    {
        public string Nombre;
        public string Apellido;
        public int Dni;
        public string Especificacion;
        public int Precio;
        public Personas(string nombre, string apellido, int dni, string especificacion, int boleta, int precio)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Especificacion = especificacion;
            this.Precio = precio;
        }
        public void MostrarPersonas()
        {
            Console.WriteLine("Nombre    : " + this.Nombre);
            Console.WriteLine("Apellido  : " + this.Apellido);
            Console.WriteLine("Dni       : " + this.Dni);
            Console.WriteLine("especificacion de atencion : " + this.Especificacion);
            Console.WriteLine("Precio    : " + this.Precio);
        }
    }
}
