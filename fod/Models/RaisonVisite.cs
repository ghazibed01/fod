using System;
using System.Collections.Generic;

namespace fod.Models
{
    public partial class RaisonVisite
    {
        public RaisonVisite()
        {
            Visites = new HashSet<Visite>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }

        public virtual ICollection<Visite> Visites { get; set; }
    }
}