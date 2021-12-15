using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_BooksLib
{
    public class Audio : Document
    {
        public int NbMinutes { get; private set; }
        public string Format { get; private set; }
        public Audio() : base() { }
        public Audio(string titre, string auteur, int nbMinutes, string format)
            : base(titre, auteur)
        {
            NbMinutes = nbMinutes;
            Format = format;
        }

        public override string Description()
        {
            return base.Description() + $" ({Format}, {NbMinutes}min)";
        }
    }
}
