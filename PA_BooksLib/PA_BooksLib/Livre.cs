using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public class Livre : Document
    {
        public string Editeur { get; private set; }
        public DateTime DatePublication { get; private set; }
        public int NbPages { get; private set; }
        public string ISBN { get; private set; }
        public string Cote { get; private set; }
        public Livre()
            :base()
        { }
        public Livre (string titre, string auteur, string editeur, DateTime datePublication, int nbPages, string isbn, string cote)
            :base(titre, auteur)
        {
            Editeur = editeur;
            DatePublication = datePublication;
            NbPages = nbPages;
            ISBN = isbn;
            Cote = cote;
        }
        public override string Description()
        {
            return base.Description() + $" ({Editeur}, {DatePublication.Date})";
        }
    }
}
