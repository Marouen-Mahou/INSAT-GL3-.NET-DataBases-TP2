using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_EF_Model_First
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demarrage ...");
            int rep;
            ModelFirstQ1Container db = new ModelFirstQ1Container();

            do
            {
                Console.WriteLine("\n\n Voitures");
                Console.WriteLine(" 1-Lister les voitures");
                Console.WriteLine(" 2-Ajouter une voiture");
                Console.WriteLine(" 3-Supprimer une voiture");
                Console.WriteLine(" 0-Quitter");
                Console.Write("Reponse : ");
                rep = Int32.Parse(Console.ReadLine());

                if (rep == 1)
                {
                    Program.ListerVoitures(db);
                }
                else if (rep == 2)
                {
                    Program.ListerMarques(db);
                    Program.ListerPersonnes(db);
                    Program.AjouterVoiture(db);
                }
                else if (rep == 3)
                {
                    Program.ListerVoitures(db);
                    Program.SupprimerVoiture(db);
                }
            } while (rep != 0);
            Console.Write("\nAu revoir ! ");
            db.SaveChanges();

        }

         private static void ListerVoitures(ModelFirstQ1Container db)
         {
             Console.Write("Filtre (Modele) : ");
             string filter = Console.ReadLine();

            var listVoitures = (from v in db.voitures
                                join p in db.personnes on v.Proprietaire equals p.Id
                                join m in db.marques on v.Marque equals m.Id
                                where v.Modele.Contains(filter)
                                select new
                                {
                                    Id = v.Id,
                                    Marque = m.Nom,
                                    Modele = v.Modele,
                                    Nom = p.Nom,
                                    Prenom = p.Prénom,
                                });

            Console.WriteLine("\n Liste des voitures \n");

            foreach (var vt in listVoitures)
                 Console.WriteLine($"{vt.Id} - {vt.Marque} - {vt.Modele} - {vt.Nom}  {vt.Prenom}");
         }
        private static void ListerPersonnes(ModelFirstQ1Container db)
        {
            var personnes = (from p in db.personnes
                             select p)
                             .ToList();

            

            Console.WriteLine("\n Liste des personnes \n");
            foreach (Personne p in personnes)
            {
                Console.WriteLine($"{p.Id} - {p.Nom} - {p.Prénom}");
            }
        }

        private static void ListerMarques(ModelFirstQ1Container db)
        {
            var marques = (from mq in db.marques
                           select mq)
                           .ToList();

            Console.WriteLine("\n Liste des marques \n");
            foreach (Marque mq in marques)
            {
                Console.WriteLine($"{mq.Id} - {mq.Nom}");
            }
        }
        private static void AjouterVoiture(ModelFirstQ1Container db)
        {

            Console.Write("\n\nModel : ");
            string model = Console.ReadLine();
            Console.Write("MarqueId: ");
            string marque = Console.ReadLine();
            Console.Write("ProprietaireId :");
            string prop = Console.ReadLine();

            Voiture v = new Voiture();
            v.Modele = model;
            v.Marque = Int32.Parse(marque);
            v.Proprietaire = Int32.Parse(prop);

            db.voitures.Add(v);

            db.SaveChanges();

            Console.WriteLine("Succés");
        }
    
        private static void SupprimerVoiture(ModelFirstQ1Container db)
        {
            Console.Write("Id : ");
            int id = Int32.Parse(Console.ReadLine());
            try
            {
                var v = (from Voiture voit in
                             db.voitures
                         where voit.Id == id
                         select voit).Single();
                db.voitures.Remove(v);
                db.SaveChanges();
                Console.WriteLine("Succés");
            }catch(Exception e)
            {
                Console.WriteLine("Echec");
            }
        }
    }
}
