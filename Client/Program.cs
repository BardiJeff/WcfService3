using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {  

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri("http://user23.2isa.org/Service1.svc/Pays", UriKind.Absolute));
            Console.In.Read();
        }

        private static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            string str = "";
            try
            {
                Console.Out.WriteLine(e.Result);
                str = e.Result;
            }
            catch (Exception)
            {               

                Console.WriteLine(" Erreur 404 - Destination non trouvée, sorry !!");
                Console.WriteLine("\n Appuyez sur ''entrée'' pour quitter la console.");
                Console.ReadKey();
            }            

            XElement xml = XElement.Parse(str);
            XNamespace ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

            var noms = from p in xml.Elements(ns + "string") select p.Value;
            foreach (string nom in noms)
            {
                Console.Out.WriteLine(nom);
            }

        }
    }    
}
