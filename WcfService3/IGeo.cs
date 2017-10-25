using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService3
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGeo
    {
        // JASON
        [OperationContract]
        [WebGet(UriTemplate = "Pays?format=json", ResponseFormat = WebMessageFormat.Json)]
        List<string> GetNomsPaysAsJson();  
         
        //  XML
        [OperationContract]
        [WebGet(UriTemplate = "Pays")] 
        List<string> GetNomsPaysAsXml();  


        [OperationContract]
        [WebGet(UriTemplate = "Pays/{nom}")] 
        Pays GetInfosPays(string nom);
    }
}
