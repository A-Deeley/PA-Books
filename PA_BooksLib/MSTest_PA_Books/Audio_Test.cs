using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA_BooksLib;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest_PA_Books
{
    [TestClass]
    public class Audio_Test
    {
        #region Description
        [TestMethod]
        public void Description_ShouldBeSameAsProperties()
        {
            string titre = "MonTitre";
            string auteur = "MonAuteur";
            int nbMin = 125;
            string format = "MonFormat";
            Audio audio = new Audio(titre, auteur, nbMin, format);


            string description = audio.Description();


            description.Should().Be($"{auteur}, '{titre}' ({format}, {nbMin}min)");
        }
        #endregion
        #region CompareTo
        [TestMethod]
        public void CompareTo_ShouldBeBeforeOrEqual()
        {
            Audio first_correctOrder = new Audio("The Great Gatsby", "F. Scott Fitzgerald", 50, "Filme");
            Audio second_incorrectOrder = new Audio("The Nightingale", "Kristin Hannah", 50, "Filme");

            Audio compareTo_Result = first_correctOrder.CompareTo(second_incorrectOrder) < 1 ? first_correctOrder : second_incorrectOrder; //compare first to second, set object to first if equal or it comes before, second if it comes before

            compareTo_Result.Should().BeSameAs(first_correctOrder);//compareTo_Result should be first since it comes before second in the comparison
        }
        #endregion
        #region EstDisponible
        [TestMethod]
        public void EstDispnible_ShouldBeTrue()
        {
            Audio audio = new Audio();

            bool succeeded = audio.EstDisponible;

            succeeded.Should().BeTrue();
        }
        [TestMethod]
        public void EstDispnible_ShouldBeFalse()
        {
            Audio audio = new Audio();

            audio.Emprunteur = new Membre();
            bool succeeded = audio.EstDisponible;

            succeeded.Should().BeFalse();
        }
        #endregion
        #region AjouterMembreListeAttente
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeFalse_NullMember()
        {
            Audio audio = new Audio();

            bool succeeded = audio.AjouterMembreListeAttente(null);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeFalse_ListFull()
        {
            Audio audio = new Audio();


            FillListeMembres(audio);
            //Try to add a user while list is full
            bool succeeded = audio.AjouterMembreListeAttente(new Membre());

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void AjouterMembreListAttente_LengthShouldBe2_ListFull()
        {
            Audio audio = new Audio();

            FillListeMembres(audio);
            //Count the number of members in the list
            int audioListeAttenteLongeur = audio.ListeAttente.Count;

            audioListeAttenteLongeur.Should().Be(2);
        }
        [TestMethod]
        public void AjouterMembreListeAttente_ShouldBeTrue_AddedUserToList()
        {
            Audio audio = new Audio();
            Membre membreValid = new Membre();

            bool succeeded = audio.AjouterMembreListeAttente(membreValid);

            succeeded.Should().BeTrue();
        }
        #endregion
        #region EnleverMembreListeAttente
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_NullMember()
        {
            Audio audio = new Audio();

            FillListeMembres(audio);
            bool succeeded = audio.EnleverMembreListeAttente(null);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_ListEmpty()
        {
            Audio audio = new Audio();

            bool succeeded = audio.EnleverMembreListeAttente(new Membre());

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeFalse_WrongMembre()
        {
            Audio audio = new Audio();
            Membre membreAjout = new Membre();
            Membre mauvaisRetrait = new Membre();

            audio.AjouterMembreListeAttente(membreAjout);
            bool succeeded = audio.EnleverMembreListeAttente(mauvaisRetrait);

            succeeded.Should().BeFalse();
        }
        [TestMethod]
        public void EnleverMembreListeAttente_ShouldBeTrue_RemovedMember()
        {
            Audio audio = new Audio();
            Membre myMembre = new Membre();

            audio.AjouterMembreListeAttente(myMembre);
            bool succeeded = audio.EnleverMembreListeAttente(myMembre);

            succeeded.Should().BeTrue();
        }
        #endregion
        #region Helper Methods
        private void FillListeMembres(Audio audioListToFill)
        {
            while (audioListToFill.AjouterMembreListeAttente(new Membre())) ;
        }
        #endregion
    }
}
