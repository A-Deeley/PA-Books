using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PA_BooksLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest_PA_Books
{
    [TestClass]
    public class Bibliotheque_Test
    {
        [TestMethod]
        public void AjouterMembre_ShouldBeTrue_AddedDocument()
        {
            Bibliotheque rep = new Bibliotheque();
            Membre mem = new Membre();

            bool success = rep.AjouterMembre(mem);

            success.Should().BeTrue();
        }

        #region AjouterListeAttente
        [TestMethod]
        public void AjouterListeAttente_ShouldBeTrue()
        {
            Bibliotheque bi = new Bibliotheque();
            Membre mem = new Membre("Jwan");
            Membre mem2 = new Membre("San");
            Audio audio = new Audio("Nice", "Bob", 19, "Beautiful weird noice");
            bi.leRepertoire.AjouterDocument(audio);
            audio.Emprunteur = mem2;
            mem2.AjouterDocument(audio);
            bool success = bi.AjouterListeAttente(mem, audio);

            success.Should().BeTrue();
        }

        [TestMethod]
        public void AjouterListeAttente_ShouldBeFalse()
        {
            Bibliotheque bi = new Bibliotheque();
            Membre mem = new Membre("Jwan");
            Membre mem2 = new Membre("San");
            Audio audio = new Audio("Nice", "Bob", 19, "Beautiful weird noice");
            bi.leRepertoire.AjouterDocument(audio);
            bool success = bi.AjouterListeAttente(mem, audio);

            success.Should().BeFalse();
        }
        #endregion 

        #region TrouverMembre
        [TestMethod]
        public void TrouverMembre_ShouldReturnMembre()
        {
            Bibliotheque bibliotheque = new Bibliotheque();
            Membre mem = new Membre("Sans");
            bibliotheque.AjouterMembre(mem);
            Membre success = bibliotheque.TrouverMembre("Sans");
            success.Should().BeSameAs(mem);
        }

        [TestMethod]
        public void TrouverMembre_ShouldReturnNull()
        {
            Bibliotheque bibliotheque = new Bibliotheque();
            Membre mem = new Membre("Papyrus");
            Membre success = bibliotheque.TrouverMembre("Papyrus");
            success.Should().Be(null);
        }
        #endregion

        #region NotifierEmprunt
        [TestMethod]
        public void NotifierEmprunt_ShouldReturnTrue()
        {
            Bibliotheque bibliotheque = new Bibliotheque();
            Membre mem = new Membre("Sans");
            bibliotheque.AjouterMembre(mem);
            Audio audio = new Audio("Nice", "Bob", 19, "Beautiful weird noice");
            bibliotheque.leRepertoire.AjouterDocument(audio);
            bool success = bibliotheque.NotifierEmprunt("Sans", audio);
            success.Should().BeTrue();
        }
        #endregion

        #region NotifierRetour
        [TestMethod]
        public void NotifierRetour_ShouldReturnTrue()
        {
            Bibliotheque bibliotheque = new Bibliotheque();
            Audio audio = new Audio("Nice", "Bob", 19, "Beautiful weird noice");
            Membre mem = new Membre("Sans");
            bibliotheque.AjouterMembre(mem);
            bibliotheque.leRepertoire.AjouterDocument(audio);
            audio.Emprunteur = mem;
            mem.AjouterDocument(audio);

            bool success = bibliotheque.NotifierRetour(audio);
            success.Should().BeTrue();
        }
        [TestMethod]
        public void NotifierRetour_ShouldReturnFalse()
        {
            Bibliotheque bibliotheque = new Bibliotheque();
            Audio audio = new Audio("Nice", "Bob", 19, "Beautiful weird noice");
            Membre mem = new Membre("Sans");
            bibliotheque.AjouterMembre(mem);
            bibliotheque.leRepertoire.AjouterDocument(audio);

            bool success = bibliotheque.NotifierRetour(audio);
            success.Should().BeFalse();
        }
        #endregion

    }
}
