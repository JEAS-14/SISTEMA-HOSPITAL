using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{ 
    internal class NodoCola
    {
        public Personas pers;
        public NodoCola sgte;
        public NodoCola(Personas pers)
        {
            this.pers = pers;
            sgte = null;
        }
    }
}
