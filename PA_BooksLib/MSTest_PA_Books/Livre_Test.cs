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
    public class Livre_Test
    {
        #region Description
        [TestMethod]
        public void Description_ShouldBeSameAsProperties()
        {
            string titre = "MonTitre";
            string auteur = "MonAuteur";
            string editeur = "MonEditeur";
            DateTime dt = DateTime.Now;
            Livre livre = new Livre(titre, auteur, editeur, dt, 0, "", "");


            string description = livre.Description();


            description.Should().Be($"{auteur}, '{titre}' ({editeur}, {dt.Date})");
        }
        #endregion
        #region CompareTo
        [TestMethod]
        public void CompareTo_ShouldBeBeforeOrEqual()
        {
            Livre first_correctOrder = new Livre("The Great Gatsby", "F. Scott Fitzgerald", "", DateTime.Now, 0, "", "");
            Livre second_incorrectOrder = new Livre("The Nightingale", "Kristin Hannah", "", DateTime.Now, 0, "", "");

            Livre compareTo_Result = first_correctOrder.CompareTo(second_incorrectOrder) < 1 ? first_correctOrder : second_incorrectOrder; //compare first to second, set object to first if equal or it comes before, second if it comes before

            compareTo_Result.Should().BeSameAs(first_correctOrder);//compareTo_Result should be first since it comes before second in the comparison
        }
        #endregion
        #region EstDisponible
        [TestMethod]
        public void EstDispnible_ShouldBeTrue()
        {
            Livre Livre = new Livre();

            bool succeeded = Livre.EstDisponible;

            succeeded.Should().BeTrue();
        }
        [TestMethod]
        public void EstDispnible_ShouldBeFalse()
        {
            Livre Livre = new Livre();

            Livre.Emprunteur = new Membre();
            bool succeeded = Livre.EstDisponible;

            succeeded.Should().BeFalse();
        }
        #endregion
        #region AjouterMembreListeAttente
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeFalse_NullMember()
        {
            Livre Livre = new Livre();

            bool succeeded = Livre.AjouterMembreListeAttente(null);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeFalse_ListFull()
        {
            Livre Livre = new Livre();

            
            FillListeMembres(Livre);
            //Try to add a user while list is full
            bool succeeded = Livre.AjouterMembreListeAttente(new Membre());

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void AjouterMembreListAttente_LengthShouldBe2_ListFull()
        {
            Livre Livre = new Livre();

            FillListeMembres(Livre);
            //Count the number of members in the list
            int LivreListeAttenteLongeur = Livre.ListeAttente.Count;

            LivreListeAttenteLongeur.Should().Be(2);
        }
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeTrue_AddedUserToList()
        {
            Livre Livre = new Livre();
            Membre membreValid = new Membre();

            bool succeeded = Livre.AjouterMembreListeAttente(membreValid);

            succeeded.Should().BeTrue();
        }
        #endregion
        #region EnleverMembreListeAttente
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_NullMember()
        {
            Livre Livre = new Livre();

            FillListeMembres(Livre);
            bool succeeded = Livre.EnleverMembreListeAttente(null);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_ListEmpty()
        {
            Livre Livre = new Livre();

            bool succeeded = Livre.EnleverMembreListeAttente(new Membre());

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_WrongMembre()
        {
            Livre Livre = new Livre();
            Membre membreAjout = new Membre();
            Membre mauvaisRetrait = new Membre();

            Livre.AjouterMembreListeAttente(membreAjout);
            bool succeeded = Livre.EnleverMembreListeAttente(mauvaisRetrait);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeTrue_RemovedMember()
        {
            Livre Livre = new Livre();
            Membre myMembre = new Membre();

            Livre.AjouterMembreListeAttente(myMembre);
            bool succeeded = Livre.EnleverMembreListeAttente(myMembre);

            succeeded.Should().BeTrue();
        }
        #endregion
        #region Helper Methods
        private void FillListeMembres(Livre LivreListToFill)
        {
            while (LivreListToFill.AjouterMembreListeAttente(new Membre())) ;
        }
        #endregion
    }
}
