//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1_EF_Database_First
{
    using System;
    using System.Collections.Generic;
    
    public partial class voitures
    {
        public int Id { get; set; }
        public string Modele { get; set; }
        public int Marque { get; set; }
        public Nullable<int> Proprietaire { get; set; }
    
        public virtual marques marques { get; set; }
        public virtual personnes personnes { get; set; }
    }
}