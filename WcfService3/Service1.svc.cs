using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService3
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, 
    //            le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur
    //            de solutions et démarrez le débogage.
    public class Service1 : IGeo
    { 
        private List<Pays> listePays = new List<Pays>()
        {        
        new Pays{Nom = "France", Capitale = "Paris", NbHabitants = 65},
        new Pays{Nom = "Italie", Capitale = "Rome", NbHabitants = 60},
        new Pays{Nom = "Espagne", Capitale = "Madrid", NbHabitants = 45},
        new Pays{Nom = "Madagascar", Capitale = "Tananarive", NbHabitants = 18}
        };

        public Pays GetInfosPays(string nom)
        {
            foreach (Pays p in listePays)
            {
                if(p.Nom.Equals(nom))
                {
                    return p;
                }
           }
           return null;
        }

        // Appel de la méthode  "GetNomsPays()" pour une sérialisation/désérialisation en JSON
        public List<string> GetNomsPaysAsJson()
        {
            return GetNomsPays();
        }

        // Appel de la méthode  "GetNomsPays()" pour une sérialisation/désérialisation en XML
        public List<string> GetNomsPaysAsXml()
        {
            return GetNomsPays();
        }

        // Méthode "GetNomsPays()" appelée par les 2 méthodes précédentes "GetNomsPaysAsJson()" ou "GetNomsPaysAsXml()"
        public List<string> GetNomsPays()
        {
            List<string> listeNomsPays = new List<string>();

            foreach (Pays p in listePays)
            {
                listeNomsPays.Add(p.Nom);
            }
            return listeNomsPays;
        }


        // CONNEXION A LA BASE DE DONNEES - RAPATRIEMENT DE TOUS LES EMPLOYES
        private static string ConnnectStr = "Data Source=176.31.248.137; Initial Catalog=user10; Persist Security Info=True; User ID=user10; Password=026user10";


        public string ConnectBaseNom(int IdEmploye)
        {
            //     SQLCONNECTION

            SqlConnection connect = new SqlConnection(); // Instanciation de la classe "SqlConnection"
            connect.ConnectionString = ConnnectStr;
            connect.Open();

            //     SQLCOMMAND

            string requete = " SELECT * FROM EMP WHERE EMPNO =" + IdEmploye;

            SqlCommand command = new SqlCommand(requete, connect); // Instanciation de la classe "SqlCommand"

            SqlDataReader reader = command.ExecuteReader(); // ExecuteReader est un curseur placé par défaut au dessus de la 1ère ligne 

            reader.Read(); // read permet le " Move " du curseur 

            return reader.GetString(1);
        }

























    }
}
