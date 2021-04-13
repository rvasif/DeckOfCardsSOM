using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DeckOfCardsBusinessLogic;

namespace DeckofCardsTests
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void CheckIfFullDeckIsCreated()
        {
            Deck.CreateFullDeck();

            Assert.AreEqual(52, Deck.CreateFullDeck().Cards.Count);
        }

        [TestMethod]
        public void AreDecksDifferent()
        {
            Deck firstDeck = Deck.CreateFullDeck();
            firstDeck.Shuffle();
            Deck secondDeck = Deck.CreateFullDeck();
            secondDeck.Shuffle();
            Assert.IsTrue((firstDeck.Cards[0].CardValue != secondDeck.Cards[0].CardValue) ||
                           (firstDeck.Cards[0].Suit != secondDeck.Cards[0].Suit));                            
        }
    }
}
