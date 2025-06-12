using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListaHospital
    {
        public NodoHospital lista;
        public ListaHospital()
        {
            lista = null;
        }
        public void InsertarHospital(string NomHospital,string DrcHospital, string PubOPriv)
        {
            
            if(lista == null)
            {
                NodoHospital q = new NodoHospital(NomHospital, DrcHospital, PubOPriv);
                q.NomHospital = NomHospital;
                q.DrcHospital = DrcHospital;
                q.PubOPriv = PubOPriv;
                lista = q;
            }
            else
            {
                NodoHospital q = new NodoHospital(NomHospital, DrcHospital, PubOPriv);
                q.NomHospital = NomHospital;
                q.DrcHospital= DrcHospital;
                q.PubOPriv = PubOPriv;
                q.sgte=lista ;
                lista = q;
            }
        }
        public void MostrarHospital()
        {
            NodoHospital t = lista;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("|\tHospitales Registrados\t|");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|\t"+ "{0}{1}{2}{3}{4}", "Nombre Hospital".PadRight(38, ' '),"|".PadRight(2,' ') ,"Direccion Hospital".PadRight(58, ' '), "|".PadRight(2, ' '), "Estado" + "\t|");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            while (t != null)
            {

                Console.WriteLine("|\t"+ "{0}{1}{2}{3}{4}", t.NomHospital.PadRight(38,' '), "|".PadRight(2, ' '), t.DrcHospital.PadRight(58,' '), "|".PadRight(2, ' '), t.PubOPriv + "\t|");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                t = t.sgte;
            }
        }
        public void EliminarHospital()
        {
            bool encontrado = false;
            NodoHospital ant= lista;
            int codigo = 1, num ;
            NodoHospital t = lista;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("|\t"+"{0}{1}{2}", "Codigo".PadRight(10,' '),"|".PadRight(2, ' '),"Nombre Hospital"+"\t\t\t|");
            Console.WriteLine("---------------------------------------------------------");
            while (t!=null)
            {
                Console.WriteLine("|\t"+ "{0}{1}{2}{3}", codigo++.ToString().PadRight(10,' '), "|".PadRight(2, ' '), t.NomHospital.PadRight(36,' '),"|".PadRight(2,' '));
                Console.WriteLine("---------------------------------------------------------");
                t =t.sgte;
            }
            Console.WriteLine("Ingrese el codigo del hospital : ");
            num=int.Parse(Console.ReadLine());
            codigo = 1;
            t=lista;
            while (t != null)
            {
                if (num == codigo)
                {
                    if(t==lista) {
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
                t=t.sgte;
            }
            if (encontrado)
            {
                Console.Clear();
                Console.WriteLine(t.NomHospital+" eliminado");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Codigo incorrecto");
                Console.ReadKey();
            }
        }
        public void ModificarHospital()
        {
            bool encontrado=false;
            int codigo = 1,num,opc;
            NodoHospital t = lista;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("|\t" + "{0}{1}{2}", "Codigo".PadRight(10, ' '), "|".PadRight(2, ' '), "Nombre Hospital" + "\t\t\t|");
            Console.WriteLine("---------------------------------------------------------");
            while (t != null)
            {
                Console.WriteLine("|\t" + "{0}{1}{2}{3}", codigo++.ToString().PadRight(10, ' '), "|".PadRight(2, ' '), t.NomHospital.PadRight(36, ' '), "|".PadRight(2, ' '));
                Console.WriteLine("---------------------------------------------------------");
                t = t.sgte;
            }
            Console.WriteLine("Ingrese el codigo del hospital : ");
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
                            Console.WriteLine("{0}", t.NomHospital);
                            Console.WriteLine("1. Actualizar Nombre");
                            Console.WriteLine("2. Actualizar Direccion");
                            Console.WriteLine("3. Actualizar Estado");
                            Console.WriteLine("4. Regresar");
                            Console.WriteLine("Ingrese su opcion : ");
                            opc = int.Parse(Console.ReadLine());
                        } while (opc < 0 || opc >= 5);
                        switch (opc)
                        {
                            case 1: Console.WriteLine("Ingrese el nuevo Nombre");
                                t.NomHospital=Console.ReadLine();
                                break;
                            case 2: Console.WriteLine("Ingrese la nueva Direccion");
                                t.DrcHospital=Console.ReadLine();
                                break;
                            case 3: Console.WriteLine("Ingrese nuevo Estado del Hospital");
                                t.PubOPriv=Console.ReadLine();
                                break;
                            case 4: 
                                break;
                        }
                    } while (opc != 4);    
                }
                codigo++;
                t = t.sgte;
            }
            if (encontrado)
            {
                Console.WriteLine("Modificacion exitosa");
                Console.ReadKey();
            }
            else { Console.WriteLine("Codigo incorrecto");
                Console.ReadKey();
            }
             
        }
    }
}
