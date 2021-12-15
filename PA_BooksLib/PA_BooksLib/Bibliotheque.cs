using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public class Bibliotheque
    {
        public Repertoire leRepertoire;
        List<Membre> lesMembres;
        public string Nom { get; }
        public List<Membre> GetMembres()
        {
            return lesMembres;
        }

        /// <summary>
        /// Constructeur vide
        /// </summary>
        public Bibliotheque() {
            leRepertoire = new Repertoire();
            lesMembres = new List<Membre>();
        }

        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="nomBiblio">le nom de la bibliothèque</param>
        public Bibliotheque(string nomBiblio)
        {
            Nom = nomBiblio;
            leRepertoire = new Repertoire();
            lesMembres = new List<Membre>();
        }

        /// <summary>
        /// Ajout un emprunteur au document si possible,
        /// Ajouter le document au membre si possible
        /// </summary>
        /// <param name="nomMembre">le membre qui veut emprunter</param>
        /// <param name="leDocument">le doc a emprunter</param>
        /// <returns>si l'emprunt à bien été fait</returns>
        public bool NotifierEmprunt(string nomMembre, Document leDocument)
        {
            if (leDocument is null) return false;
            bool fait = false;
            Membre mem = TrouverMembre(nomMembre);
            Document doc = leRepertoire.TrouverDocument(leDocument.Titre, leDocument.Auteur);
            if(doc.EstDisponible)
            {
                doc.Emprunteur = mem;
                if(mem.AjouterDocument(doc))
                {
                    fait = true;
                }
                else
                {
                    fait = false;
                }
            }
            else
            {
                AjouterListeAttente(mem, doc);
                fait = false;
            }
            
            return fait;
        }

        /// <summary>
        /// retirer le document du membre
        /// retirer l'emprunteur au document
        /// </summary>
        /// <param name="leDocument"></param>
        /// <returns></returns>
        public bool NotifierRetour(Document leDocument)
        {
            if (leDocument is null) return false;
            bool fait = false;
            Document doc = leRepertoire.TrouverDocument(leDocument.Titre, leDocument.Auteur);
            if(doc.Emprunteur != null)
            {
                Membre mem = doc.Emprunteur;
                mem.RetirerDocument(doc);
                doc.Emprunteur = null;
                fait = true;
            }
            return fait;
            
        }

        public Membre TrouverMembre(string nom)
        {
            Membre mem = null;
            for(int i = 0; i < lesMembres.Count; i++)
            {
                if(lesMembres.ElementAt(i).Nom == nom)
                {
                    mem = lesMembres.ElementAt(i);
                }
            }
            
            return mem;
        }

        public bool AjouterMembre(Membre nouveau)
        {
            bool fait = false;
            if (nouveau == null)
            {
                throw new ArgumentNullException(nameof(nouveau), "Document null");
            }

            lesMembres.Add(nouveau);
            fait = true;
            return fait;
        }

        public bool AjouterListeAttente(Membre leMembre, Document leDoc)
        {
            if (leDoc == null) return false;
            if (leMembre == null) return false;

            bool fait = false;
            Document doc = leRepertoire.TrouverDocument(leDoc.Titre, leDoc.Auteur);
            if(doc.Emprunteur != null)
            {
                fait = doc.AjouterMembreListeAttente(leMembre);
            }
            return fait;
        }
    }
}
