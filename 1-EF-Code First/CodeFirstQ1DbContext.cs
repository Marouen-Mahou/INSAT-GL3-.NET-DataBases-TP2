using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_EF_Code_First
{
    class CodeFirstQ1DbContext :DbContext
    {
        public CodeFirstQ1DbContext() : base("name=CodeFirstQ1")
        {

        }

        public DbSet<Marque> Marques { get; set; }
        public DbSet<Personne> Personnes { get; set; } 
        public DbSet<Voiture> Voitures { get; set; }
    }
}
