using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public abstract class Document : IComparable<Document>
    {
        #region Properties
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public bool EstDisponible { get { return Emprunteur is null; } }//Retourne vrai si aucun emprunteur est en cours
        public Membre Emprunteur { get; set; }
        public List<Membre> ListeAttente { get; private set; }
        #endregion
        public Document()
        {
            Emprunteur = null;
            ListeAttente = new List<Membre>();
        }
        public Document(string titre, string auteur)
        {
            Titre = titre;
            Auteur = auteur;
            ListeAttente = new List<Membre>(); //Set empty list object with max 2
            Emprunteur = null; //set null value for emprunter
        }
        public int CompareTo(Document other)
        {
            return Titre.CompareTo(other.Titre);
        }

        public bool AjouterMembreListeAttente(Membre ajout)
        {
            //Check if the object is null first, and return false
            if (ajout is null) return false;
            //Prevent adding more than 2 people in the array
            if (ListeAttente.Count == 2) return false;

            int countBeforeAdding = ListeAttente.Count;
            ListeAttente.Add(ajout);
            return ListeAttente.Count > countBeforeAdding;//check if we really added a new member, will return false if the .Add did not add the member
        }

        public bool EnleverMembreListeAttente(Membre retrait)
        {
            if (retrait is null) return false;
            if (ListeAttente.Count == 0) return false;

            int countBeforeRemoving = ListeAttente.Count;
            ListeAttente.Remove(retrait);
            return ListeAttente.Count < countBeforeRemoving;//check if we really removed the member, will return false if the .Remove did not remove the member
        }

        public virtual string Description()
        {
            return $"{Auteur}, '{Titre}'";
        }
    }
}
