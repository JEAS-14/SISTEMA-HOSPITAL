using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PilaTramferencia
    {
        public NodoPilaTransferencia pila;
        public PilaTramferencia()
        {
            pila = null;
        }
        public void Agregar(ListaTransferenciaPaciente a)
        {
            NodoTransferenciaPacientes r = a.transferencia;
            while(r!=null)
            {
                NodoPilaTransferencia q = new NodoPilaTransferencia(r.paciente, r.hospital, r.hospitaltransferido);
                q.sgte = pila;
                pila = q;
                r = r.sgte;
            }
        }
        public void Mostrar()
        {
            Console.Clear();
            NodoPilaTransferencia q = pila;
            while(q!=null)
            {
                Console.WriteLine("EL paciente "+q.nombrepaciente+" que se encontraba en el hospital "+q.nombrehospital+" fue transferido" +
                    "al hospital "+q.nombrehospitaltranferido );
                q = q.sgte;
            }
            Console.ReadKey();
        }
    }
}
