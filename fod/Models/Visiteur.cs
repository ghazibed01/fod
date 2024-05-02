using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace fod.Models
{
    public partial class Visiteur
    {
        public Visiteur()
        {
            Visites = new HashSet<Visite>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Telphone { get; set; }
        public string? Email { get; set; }
        public int? TypeVisiteurId { get; set; }

        public virtual TypeVisiteur? TypeVisiteur { get; set; }
        public virtual ICollection<Visite> Visites { get; set; }
    }
}