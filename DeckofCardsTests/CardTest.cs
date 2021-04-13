using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DeckOfCardsBusinessLogic;

namespace DeckofCardsTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardIsInitializedWithSuitAndValue()
        {
            Card myCard = new Card(CardValue.Ace, Suit.Clubs);
            Assert.AreEqual("Clubs", myCard.Suit.ToString());
            Assert.AreEqual("Ace", myCard.CardValue.ToString());
        }

        [TestMethod]
        public void CompareWithAceAndClub()
        {
            Card myCard1 = new Card(CardValue.Ace, Suit.Clubs);
            Card myCard2 = new Card(CardValue.Ace, Suit.Clubs);

            Assert.AreEqual(0, myCard1.CompareTo(myCard2));
        }
    }
}
