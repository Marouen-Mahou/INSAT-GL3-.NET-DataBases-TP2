using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_non_connecté
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se connecter sur BD
            string cString = ConfigurationManager.ConnectionStrings["gl3tp2Act1"].ConnectionString;
            SqlConnection connection = new SqlConnection(cString);

            SqlDataAdapter voitureAdapter = new SqlDataAdapter("Select * " +
                "from voitures",connection);

            SqlDataAdapter marqueAdapter = new SqlDataAdapter("Select *" +
                "from marques", connection);

            SqlDataAdapter personneAdapter = new SqlDataAdapter("Select *" +
                "from personnes", connection);

            DataSet ListeVoitures = new DataSet();

            voitureAdapter.Fill(ListeVoitures, "Voitures");
            marqueAdapter.Fill(ListeVoitures, "Marques");
            personneAdapter.Fill(ListeVoitures, "Personnes");

            DataRelation relation = ListeVoitures.Relations.Add("marque",
                ListeVoitures.Tables["Marques"].Columns["id"],
               ListeVoitures.Tables["Voitures"].Columns["marque"]
               );

            foreach(DataRow mRow in ListeVoitures.Tables["Marques"].Rows)
            {
                
                foreach (DataRow vRow in mRow.GetChildRows(relation))
                {
                    Console.Write(vRow["id"]);
                    Console.Write("\t" + mRow["nom"]);
                    Console.WriteLine("\t" + vRow["modele"]);
                }
                    
            }
            Console.Read();
        }
    }
}
