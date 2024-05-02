using System;
using System.Collections.Generic;

namespace fod.Models
{
    public partial class Personnel
    {
        public Personnel()
        {
            Visites = new HashSet<Visite>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Telephone { get; set; }
        public string? Poste { get; set; }

        public virtual ICollection<Visite> Visites { get; set; }
    }
}