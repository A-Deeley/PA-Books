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
    public class Repertoire_Test
    {
        [TestMethod]
        public void AjouterDocument_ShouldBeTrue_AddedDocument()
        {
            Repertoire rep = new Repertoire();

            bool success = rep.AjouterDocument(new Audio("magie", "bob", 12, "waht"));

            success.Should().BeTrue();
        }

        [TestMethod]
        public void SupprimerDocument_ShouldBeTrue_DocumentDeleted()
        {
            Repertoire rep = new Repertoire();
            Audio audio = new Audio("blue", "marie", 19, "no");
            rep.AjouterDocument(audio);
            bool success = rep.SupprimerDocument(audio);

            success.Should().BeTrue();
        }

        [TestMethod]
        public void VerifierDisponibilite_ShouldBeTrue_IsDisponible()
        {
            Repertoire rep = new Repertoire();
            Audio audio = new Audio("bruh", "marie", 20, "no");
            rep.AjouterDocument(audio);
            bool success = rep.VerifierDisponibilite(audio);

            success.Should().BeTrue();
        }
        
        [TestMethod]
        public void TrouverDocument_()
        {
            Repertoire rep = new Repertoire();
            Audio audio = new Audio("bruh", "marie", 20, "no");
            rep.AjouterDocument(audio);
            Document success = rep.TrouverDocument("bruh", "marie");
            success.Should().BeSameAs(audio);
        }
    }
}
