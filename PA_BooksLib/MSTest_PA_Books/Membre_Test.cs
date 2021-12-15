using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_BooksLib;

namespace MSTest_PA_Books
{
    [TestClass]
    public class Membre_Test
    {
        [TestMethod]
        public void AjouterDocument_ShouldBeTrue_AddedDocument()
        {
            Membre mem = new Membre();

            bool success = mem.AjouterDocument(new Audio());

            success.Should().BeTrue();
        }

        [TestMethod]
        public void RetirerDocument_ShouldBeTrue_DocumentRemoved()
        {
            Membre mem = new Membre();
            Audio audio = new Audio();
            mem.AjouterDocument(audio);
            bool success = mem.RetirerDocument(audio);

            success.Should().BeTrue();
        }

        [TestMethod]
        public void NbMembre_ShouldBeTrue_IncrementedStaticTotal()
        {
            Membre m0 = new Membre();
            Membre m1 = new Membre();

            bool success = m0.NoMembre == m1.NoMembre - 1;

            success.Should().BeTrue();
        }
    }
}
