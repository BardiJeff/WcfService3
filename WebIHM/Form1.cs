using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using WcfService3;
using System.Web.UI.WebControls;

namespace WebIHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri("http://user23.2isa.org/Service1.svc/Pays", UriKind.Absolute));
            req.BeginGetResponse(new AsyncCallback(fnReponse), req);
        }

                      
        private void fnReponse(IAsyncResult ar)
        {
            HttpWebRequest req = (HttpWebRequest)ar.AsyncState;  
            HttpWebResponse rep = (HttpWebResponse)req.EndGetResponse(ar);
            Stream stream = rep.GetResponseStream();
            StreamReader reader = new StreamReader(stream);            
            string str = reader.ReadToEnd();
            reader.Close();
            rep.Close();

            if (InvokeRequired)
            {
                //Invoke(new EventHandler(delegate { textBox1.Text = str; }));                
            }
            else
            {
                //textBox1.Text = str;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL_SERVICE = "http://user23.2isa.org/Service1.svc";
            RestClient client = new RestClient(URL_SERVICE);

            // METHODE 1 - Page 11 sur 20 - Doc

            List<string> listePays = null;
            var request = new RestRequest("Pays", Method.GET);
            var response = client.Execute<List<string>>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                listePays = response.Data;

                foreach (string retour in listePays)
                {
                    listBox1.Items.Add(retour);                    
                }
                textBox1.Text = response.Content; // Affichage du retour de la requète non désérialisée
            }            
        }       


        private void button2_Click(object sender, EventArgs e)
        {
            string URL_SERVICE = "http://user23.2isa.org/Service1.svc";
            RestClient client = new RestClient(URL_SERVICE);

            // METHODE 2 - Page 12 sur 20 - Doc

            List<string> listePays = null;
            var request = new RestRequest("Pays", Method.GET);

            request.AddQueryParameter("format", "json");

            var response = client.Execute<List<string>>(request);

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                listePays = response.Data;

                foreach (string retour in listePays)
                {
                    listBox2.Items.Add(retour);
                    listBox4.Items.Add(retour);                    
                }
                textBox2.Text = response.Content; // Affichage du retour de la requète non désérialisée
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string URL_SERVICE = "http://user23.2isa.org/Service1.svc";
            RestClient client = new RestClient(URL_SERVICE);            

            // METHODE 3 - Page 12 sur 20 - Doc

            Pays pays = null;
            string nom = listBox4.Text;
            listBox3.Items.Clear();
           
           var request = new RestRequest("Pays/{nom}", Method.GET);

            request.AddParameter("nom", nom, ParameterType.UrlSegment);

            var response = client.Execute<Pays>(request);

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                pays = response.Data;

                listBox3.Items.Add(pays.Nom);
                listBox3.Items.Add(pays.Capitale);
                listBox3.Items.Add(pays.NbHabitants);

                listBox5.Items.Add(pays.Nom);
                listBox5.Items.Add(pays.Capitale);
                listBox5.Items.Add(pays.NbHabitants);

                bindingSource1.DataSource = pays;
                dataGridView1.DataSource = bindingSource1;                
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            // Bouton pour la sélection de l'employé
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
        }

        
    }
}
