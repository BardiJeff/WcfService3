using Client.SRGeo;
using RestSharp;
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
            
            // Partie commune aux méthodes

            string URL_SERVICE = "http://user23.2isa.org/Service1.svc";
            RestClient client = new RestClient(URL_SERVICE);

            // METHODE 1 - Page 11 sur 20 - Doc

            //List<string> listePays = null;
            //var request = new RestRequest("Pays", Method.GET);
            //var response = client.Execute<List<string>>(request);
            //if (response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    listePays = response.Data;

            //    foreach (string retour in listePays)
            //    {
            //        Console.WriteLine(retour);                    
            //    }
            //    Console.ReadKey();
            //}

            //if (response.ErrorException != null)
            //{
            //    string message = "Erreur, voir les détails pour plus d'information";
            //    var e = new ApplicationException(message, response.ErrorException);
            //    throw e;
            //}


            // METHODE 2 - Page 12 sur 20 - Doc

            //List<string> listePays = null;
            //var request = new RestRequest("Pays", Method.GET);

            //request.AddQueryParameter("format", "json");

            //var response = client.Execute<List<string>>(request);

            //if (response.ResponseStatus == ResponseStatus.Completed)
            //{
            //    listePays = response.Data;

            //    foreach (string retour in listePays)
            //    {
            //        Console.Out.WriteLine(retour);                    
            //    }
            //    Console.ReadKey();
            //}

            //if(response.ErrorException != null)
            //{
            //    string message = "Erreur, voir les détails pour plus d'information";
            //    var e = new ApplicationException(message, response.ErrorException);
            //    throw e;                
            //}


            // METHODE 3 - Page 12 sur 20 - Doc

            Pays DonneesPays = null;            

            string nom = "France";

            var request = new RestRequest("Pays/{nom}", Method.GET);

            request.AddParameter("nom", nom, ParameterType.UrlSegment);

            var response = client.Execute<Pays>(request);

            if(response.ResponseStatus == ResponseStatus.Completed)
            {
                DonneesPays = response.Data;

                Console.Out.WriteLine(DonneesPays.Nom);
                Console.Out.WriteLine(DonneesPays.Capitale);
                Console.Out.WriteLine(DonneesPays.NbHabitants);
                               
            }
            Console.ReadKey();
        }
    }
}
