using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_EF_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demarrage ...");
            int rep;
            CodeFirstQ1DbContext db = new CodeFirstQ1DbContext();

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

        private static void ListerVoitures(CodeFirstQ1DbContext db)
        {
            Console.Write("Filtre (Modele) : ");
            string filter = Console.ReadLine();

            var listVoitures = (from v in db.Voitures
                                join p in db.Personnes on v.PersonneId equals p.Id
                                join m in db.Marques on v.MarqueId equals m.Id
                                where v.Modele.Contains(filter)
                                select new
                                {
                                    Id = v.Id,
                                    Marque = m.Nom,
                                    Modele = v.Modele,
                                    Nom = p.Nom,
                                    Prenom = p.Prenom,
                                });

            Console.WriteLine("\n Liste des voitures \n");

            foreach (var vt in listVoitures)
                Console.WriteLine($"{vt.Id} - {vt.Marque} - {vt.Modele} - {vt.Nom}  {vt.Prenom}");
        }
        private static void ListerPersonnes(CodeFirstQ1DbContext db)
        {
            var personnes = (from p in db.Personnes
                             select p)
                             .ToList();



            Console.WriteLine("\n Liste des personnes \n");
            foreach (Personne p in personnes)
            {
                Console.WriteLine($"{p.Id} - {p.Nom} - {p.Prenom}");
            }
        }

        private static void ListerMarques(CodeFirstQ1DbContext db)
        {
            var marques = (from mq in db.Marques
                           select mq)
                           .ToList();

            Console.WriteLine("\n Liste des marques \n");
            foreach (Marque mq in marques)
            {
                Console.WriteLine($"{mq.Id} - {mq.Nom}");
            }
        }
        private static void AjouterVoiture(CodeFirstQ1DbContext db)
        {

            Console.Write("\n\nModel : ");
            string model = Console.ReadLine();
            Console.Write("MarqueId: ");
            string marque = Console.ReadLine();
            Console.Write("ProprietaireId :");
            string prop = Console.ReadLine();

            Voiture v = new Voiture();
            v.Modele = model;
            v.MarqueId = Int32.Parse(marque);
            v.PersonneId = Int32.Parse(prop);

            db.Voitures.Add(v);

            db.SaveChanges();

            Console.WriteLine("Succés");
        }

        private static void SupprimerVoiture(CodeFirstQ1DbContext db)
        {
            Console.Write("Id : ");
            int id = Int32.Parse(Console.ReadLine());
            try
            {
                var v = (from Voiture voit in
                             db.Voitures
                         where voit.Id == id
                         select voit).Single();
                db.Voitures.Remove(v);
                db.SaveChanges();
                Console.WriteLine("Succés");
            }
            catch (Exception e)
            {
                Console.WriteLine("Echec");
            }
        }
    }
}
