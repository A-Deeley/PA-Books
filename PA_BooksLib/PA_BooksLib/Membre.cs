using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public class Membre
    {
        public string Nom { get; private set; }
        public List<Document> ListeEmprunts { get; private set; }
        public int NoMembre { get; private set; }
        private static int NbMembresTotal = 0;

        public Membre()
        {
            NbMembresTotal++;
            NoMembre = NbMembresTotal;
            ListeEmprunts = new List<Document>();
            Nom = "test";
        }
        public Membre(string nom)
        {
            NbMembresTotal++;
            NoMembre = NbMembresTotal;
            ListeEmprunts = new List<Document>();
            Nom = nom;
        }

        public bool AjouterDocument(Document nouveau)
        {
            if (nouveau is null) return false;
            if (ListeEmprunts.Count >= 4) return false;

            ListeEmprunts.Add(nouveau);
            return true;
        }

        public bool RetirerDocument(Document retrait)
        {
            if (retrait is null) return false;
            if (ListeEmprunts.Count == 0) return false;

            return ListeEmprunts.Remove(retrait);
        }
    }
}
