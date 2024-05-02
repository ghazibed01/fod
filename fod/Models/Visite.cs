using System;
using System.Collections.Generic;

namespace fod.Models
{
    public partial class Visite
    {
        public Guid Uid { get; set; }
        public DateTime? DateHeureDebut { get; set; }
        public DateTime? DateHeureFin { get; set; }
        public int? RaisonVisiteId { get; set; }
        public int? TypeVisiteId { get; set; }
        public int? StatutId { get; set; }
        public int? PersonnelId { get; set; }
        public int? VisiteurId { get; set; }
        public string? Details { get; set; }

        public virtual Personnel? Personnel { get; set; }
        public virtual RaisonVisite? RaisonVisite { get; set; }
        public virtual Statut? Statut { get; set; }
        public virtual TypeVisite? TypeVisite { get; set; }
        public virtual Visiteur? Visiteur { get; set; }
    }
}