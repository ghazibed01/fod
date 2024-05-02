using System;
using System.Collections.Generic;

namespace fod.Models
{
    public partial class TypeVisiteur
    {
        public TypeVisiteur()
        {
            Visiteurs = new HashSet<Visiteur>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }

        public virtual ICollection<Visiteur> Visiteurs { get; set; }
    }
}
