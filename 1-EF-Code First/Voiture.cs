﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_EF_Code_First
{
    class Voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Modele { get; set; }

        [ForeignKey("Marque")]
        public int MarqueId { get; set; }
        public virtual Marque Marque { get; set; }

        [ForeignKey("Personne")]
        public int PersonneId { get; set; }
        public virtual Personne Personne { get; set; }
    }
}
