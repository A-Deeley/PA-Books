using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PA_BooksLib;
using System.Threading.Tasks;
using FluentAssertions;

namespace MSTest_PA_Books
{
    [TestClass]
    public class Periodique_Test
    {
        #region Description
        [TestMethod]
        public void Description_ShouldBeSameAsProperties()
        {
            string titre = "MonTitre";
            string auteur = "MonAuteur";
            int annee = 2020;
            int numero = 69;
            int nbPages = 420;
            Periodique Periodique = new Periodique(titre, auteur, annee, numero, nbPages);


            string description = Periodique.Description();


            description.Should().Be($"{auteur}, '{titre}' (#{numero}, {annee})");
        }
        #endregion
        #region CompareTo
        [TestMethod]
        public void CompareTo_ShouldBeBeforeOrEqual()
        {
            Periodique first_correctOrder = new Periodique("The Great Gatsby", "F. Scott Fitzgerald", 2020, 69, 420);
            Periodique second_incorrectOrder = new Periodique("The Nightingale", "Kristin Hannah", 2020, 69, 420);

            Periodique compareTo_Result = first_correctOrder.CompareTo(second_incorrectOrder) < 1 ? first_correctOrder : second_incorrectOrder; //compare first to second, set object to first if equal or it comes before, second if it comes before

            compareTo_Result.Should().BeSameAs(first_correctOrder);//compareTo_Result should be first since it comes before second in the comparison
        }
        #endregion
        #region EstDisponible
        [TestMethod]
        public void EstDispnible_ShouldBeTrue()
        {
            Periodique Periodique = new Periodique();

            bool succeeded = Periodique.EstDisponible;

            succeeded.Should().BeTrue();
        }
        [TestMethod]
        public void EstDispnible_ShouldBeFalse()
        {
            Periodique Periodique = new Periodique();

            Periodique.Emprunteur = new Membre();
            bool succeeded = Periodique.EstDisponible;

            succeeded.Should().BeFalse();
        }
        #endregion
        #region AjouterMembreListeAttente
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeFalse_NullMember()
        {
            Periodique Periodique = new Periodique();

            bool succeeded = Periodique.AjouterMembreListeAttente(null);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeFalse_ListFull()
        {
            Periodique Periodique = new Periodique();


            FillListeMembres(Periodique);
            //Try to add a user while list is full
            bool succeeded = Periodique.AjouterMembreListeAttente(new Membre());

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void AjouterMembreListAttente_LengthShouldBe2_ListFull()
        {
            Periodique Periodique = new Periodique();

            FillListeMembres(Periodique);
            //Count the number of members in the list
            int PeriodiqueListeAttenteLongeur = Periodique.ListeAttente.Count;

            PeriodiqueListeAttenteLongeur.Should().Be(2);
        }
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeTrue_AddedUserToList()
        {
            Periodique Periodique = new Periodique();
            Membre membreValid = new Membre();

            bool succeeded = Periodique.AjouterMembreListeAttente(membreValid);

            succeeded.Should().BeTrue();
        }
        #endregion
        #region EnleverMembreListeAttente
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_NullMember()
        {
            Periodique Periodique = new Periodique();

            FillListeMembres(Periodique);
            bool succeeded = Periodique.EnleverMembreListeAttente(null);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_ListEmpty()
        {
            Periodique Periodique = new Periodique();

            bool succeeded = Periodique.EnleverMembreListeAttente(new Membre());

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_WrongMembre()
        {
            Periodique Periodique = new Periodique();
            Membre membreAjout = new Membre();
            Membre mauvaisRetrait = new Membre();

            Periodique.AjouterMembreListeAttente(membreAjout);
            bool succeeded = Periodique.EnleverMembreListeAttente(mauvaisRetrait);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeTrue_RemovedMember()
        {
            Periodique Periodique = new Periodique();
            Membre myMembre = new Membre();

            Periodique.AjouterMembreListeAttente(myMembre);
            bool succeeded = Periodique.EnleverMembreListeAttente(myMembre);

            succeeded.Should().BeTrue();
        }
        #endregion
        #region Helper Methods
        private void FillListeMembres(Periodique PeriodiqueListToFill)
        {
            while (PeriodiqueListToFill.AjouterMembreListeAttente(new Membre())) ;
        }
        #endregion
    }
}
