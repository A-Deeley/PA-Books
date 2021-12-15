using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public class Periodique : Document
    {
        public int Annee { get; private set; }
        public int Numero { get; private set; }
        public int NbPages { get; private set; }

        public Periodique() : base() { }
        public Periodique(string titre, string auteur, int annee, int numero, int nbPages)
            :base(titre, auteur)
        {
            Annee = annee;
            Numero = numero;
            NbPages = nbPages;
        }

        public override string Description()
        {
            return base.Description() + $" (#{Numero}, {Annee})";
        }
    }
}
