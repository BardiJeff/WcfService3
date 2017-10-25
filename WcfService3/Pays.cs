using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services.Description;

namespace WcfService3
{
    [DataContract]
    public class Pays : IGeo
    {
        // PROPERTY
        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Capitale { get; set; }

        [DataMember]
        public double NbHabitants { get; set; }

        // METHODES - Rprises de l'interface "IGeo"
        public List<string> GetNomsPaysAsJson()
        {
            throw new NotImplementedException();
        }

        public List<string> GetNomsPaysAsXml()
        {
            throw new NotImplementedException();
        }

        public Pays GetInfosPays(string nom)
        {
            throw new NotImplementedException();
        }

        // Constructeur par défaut " OBLIGATOIRE" pour la DESERIALISATION en XML
        public Pays() { }


        public Pays (string nom)
        {
            this.Nom = nom;
        }

        public Pays (string nom, string capitale, double nbHabitants) : this (nom)
        {
            this.Capitale = capitale;
            this.NbHabitants = nbHabitants;
        }

        
        public override string ToString()
        {
            return "Le Pays : " + Nom + " a pour capitale " + Capitale + " et pour nombre d'habitants " + NbHabitants;
        }



    }
}