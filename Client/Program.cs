using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        // Coté CLIENT // 
        static void Main(string[] args)
        {
            using (SRGeo.GeoClient geo = new SRGeo.GeoClient())
            {
                SRGeo.Pays p = geo.GetInfosPays("France");
                Console.Out.WriteLine(" Le Nom du pays est =  " + p.Nom + "\n Sa Capitale est =  " + p.Capitale + "\n Le Nombre de ses habitants est de =  " + p.NbHabitants + "  Millions ");

                List<string> listeNomPays = geo.GetNomsPays();
                foreach (string s in listeNomPays)
                {
                    Console.Out.WriteLine(s);
                }
                Console.In.Read();
            }
        }
    }
}
