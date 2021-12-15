using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public class Repertoire
    {
        public List<Document> listDocuments = new List<Document>();
        public string Nom { get; }


        /// <summary>
        /// La liste des documents avec une liste d'attente
        /// </summary>
        /// <returns>liste d'attente</returns>
        public List<Document> GetListeAttente()
        {
            List<Document> docList = new List<Document>();

            for (int i = 0; i < listDocuments.Count; i++)
            {
                if (listDocuments.ElementAt(i).ListeAttente.Count != 0)
                {
                    docList.Add(listDocuments.ElementAt(i));
                }
            }
            return docList;
        }

        /// <summary>
        /// Un liste des documents empruntés par les membres
        /// </summary>
        /// <returns>les documents empruntés</returns>
        public List<Document> GetListeEmprunt()
        {
            List<Document> emList = new List<Document>();

            for (int i = 0; i < listDocuments.Count; i++)
            {
                if (listDocuments.ElementAt(i).Emprunteur != null)
                {
                    emList.Add(listDocuments.ElementAt(i));
                }
            }
            return emList;
        }

        public Repertoire(){}

        public Repertoire(string nomRepertoire, string nomFichier)
        {
            Nom = nomRepertoire;
        }

        /// <summary>
        /// Cherche un document dans la liste d'Après son titre et l'auteur
        /// </summary>
        /// <param name="titre">Le titre du document</param>
        /// <param name="nomAuteur">le nom de l'auteur</param>
        /// <returns>le document trouver ou null</returns>
        public Document TrouverDocument(string titre, string nomAuteur)
        {   
            Document doc = null;

            for (int i = 0; i < listDocuments.Count(); i++)
            {
                if (listDocuments.ElementAt(i).Titre == titre && listDocuments.ElementAt(i).Auteur == nomAuteur)
                {
                    doc = listDocuments.ElementAt(i);
                }
            }
            return doc;
        }

        /// <summary>
        /// Ajouter un document au répertoire
        /// </summary>
        /// <param name="nouveauDoc"></param>
        /// <returns></returns>
        public bool AjouterDocument(Document nouveauDoc)
        {
            //Faire la validation de données
            if(nouveauDoc == null)
            {
                throw new ArgumentNullException(nameof(nouveauDoc), "Document null");
            }
            if (string.IsNullOrEmpty(nouveauDoc.Titre))
            {
                throw new ArgumentNullException(nameof(nouveauDoc.Titre), "Entrer le titre");

            }
            if (string.IsNullOrEmpty(nouveauDoc.Auteur))
            {
                throw new ArgumentNullException(nameof(nouveauDoc.Auteur), "Entrer le nom de l'auteur");    
            }

            listDocuments.Add(nouveauDoc);
            return true;
        }

        /// <summary>
        /// Supprime le document s'il existe
        /// </summary>
        /// <param name="documentASupprimer">le document a supprimé</param>
        /// <returns>si supprimer ou non</returns>
        public bool SupprimerDocument(Document documentASupprimer)
        {
            bool verif  =  false;
            for (int i = 0; i < listDocuments.Count(); i++)
            {
                if (listDocuments.ElementAt(i).Titre == documentASupprimer.Titre && listDocuments.ElementAt(i).Auteur == documentASupprimer.Auteur)
                {
                    listDocuments.RemoveAt(i);
                    verif = true;
                }
            }
            return verif;
        }
        /// <summary>
        /// Verifier si le document est disponible
        /// </summary>
        /// <param name="docVerifier">doc à vérifier</param>
        /// <returns>Si disponible ou non</returns>
        public bool VerifierDisponibilite(Document docVerifier)
        {
            if (docVerifier is null) return false;
            bool verif = false;

            for (int i = 0; i < listDocuments.Count(); i++)
            {
                if (listDocuments.ElementAt(i).Titre == docVerifier.Titre && listDocuments.ElementAt(i).Auteur == docVerifier.Auteur)
                {
                    if(docVerifier.EstDisponible)
                    {
                        verif = true;
                    } 
                }
            }
            return verif;
        }

    }
}
