using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADO.NET_Connecté
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demarrage ...");
            int rep;

            //Se connecter sur BD
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["gl3tp2Act1"].ConnectionString;
            con.Open();

            //Commande
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            do
            {
                Console.WriteLine("\n\n Voitures");
                Console.WriteLine(" 1-Lister les voitures");
                Console.WriteLine(" 2-Ajouter une voiture");
                Console.WriteLine(" 3-Supprimer une voiture");
                Console.WriteLine(" 0-Quitter");
                Console.Write("Reponse : ");
                rep = Int32.Parse(Console.ReadLine());

                if(rep == 1)
                {
                    Program.ListerVoitures(cmd);
                }else if(rep == 2)
                {
                    Program.ListerMarques(cmd);
                    Program.ListerPersonnes(cmd);
                    Program.AjouterVoiture(cmd);
                }else if(rep == 3)
                {
                    Program.ListerVoitures(cmd);
                    Program.SupprimerVoiture(cmd);
                }
            } while (rep != 0);
            Console.Write("\nAu revoir ! ");
            con.Close();
            
        }

        private static void ListerVoitures(SqlCommand cmd)
        {
            Console.Write("Filtre (Modele) : ");
            string filter = Console.ReadLine();

            cmd.CommandText = "Select * " +
                        "from voitures v,marques m,personnes p " +
                        "where v.marque = m.Id AND  v.proprietaire = p.Id AND v.modele LIKE '%"+filter+"%'";

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\n -- Voitures -- \n");
            while (reader.Read())
            {
                int id = Int32.Parse(reader[0].ToString());
                string modele = reader[1].ToString();
                string marque = reader[5].ToString();
                string personne = reader[7].ToString() + " " + reader[8].ToString();
                Console.WriteLine(id + "-" + modele + "-" + marque + "-" + personne);
            }
            reader.Close();
        }

        private static void ListerPersonnes(SqlCommand cmd)
        {
            cmd.CommandText = "Select * " +
                        "from personnes p ";

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\n -- Personnes -- \n");
            while (reader.Read())
            {
                int id = Int32.Parse(reader[0].ToString());
                string nom = reader[1].ToString();
                string prenom = reader[2].ToString();
                Console.WriteLine(id + "-" + nom + "-" + prenom );
            }
            reader.Close();
        }

        private static void ListerMarques(SqlCommand cmd)
        {
            cmd.CommandText = "Select * " +
                        "from marques ";

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\n -- Marques -- \n");

            while (reader.Read())
            {
                int id = Int32.Parse(reader[0].ToString());
                string nom = reader[1].ToString();
                Console.WriteLine(id + "-" + nom);
            }
            reader.Close();
        }

        private static void AjouterVoiture(SqlCommand cmd)
        {
            Console.Write("\n\nModel : ");
            string model = Console.ReadLine();
            Console.Write("MarqueId: ");
            string marque = Console.ReadLine();
            Console.Write("ProprietaireId :");
            string prop = Console.ReadLine();

            cmd.CommandText = "INSERT INTO Voitures(modele,marque,proprietaire) VALUES ('"+model+"',"+ marque + ","+ prop + ")";
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
            {
                Console.WriteLine("Succés");
            }
            else
            {
                Console.WriteLine("Echec");
            }
        }

        private static void SupprimerVoiture(SqlCommand cmd)
        {
            Console.Write("Id : ");
            string id = Console.ReadLine();

            cmd.CommandText = "DELETE FROM voitures where  id = "+ id;
            int res = cmd.ExecuteNonQuery();
            if (res != 0)
            {
                Console.WriteLine("Succés");
            }
            else
            {
                Console.WriteLine("Echec");
            }
        }
    }
}
