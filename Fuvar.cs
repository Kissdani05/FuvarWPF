using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Fuvar
    {
        public int TaxiId;
        public DateTime Indulas;
        public int Idotartam;
        public double Tavolsag;
        public double Viteldij;
        public double Borravalo;
        public string Fizetes_modja;

        public Fuvar(string sor)
        {
            string[] darabok = sor.Split(';');
            this.TaxiId = Convert.ToInt32(darabok[0]);
            this.Indulas = Convert.ToDateTime(darabok[1]);
            this.Idotartam = Convert.ToInt32(darabok[2]);
            this.Tavolsag = Convert.ToDouble(darabok[3]);
            this.Viteldij = Convert.ToDouble(darabok[4]);
            this.Borravalo = Convert.ToDouble(darabok[5]);
            this.Fizetes_modja = darabok[6];
        }
    }
}
