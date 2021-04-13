using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DeckOfCardsBusinessLogic;


namespace DeckofCardsTests
{
    [TestClass]
    public class DeckTest
    {
        [TestInitialize]
        public void Initialize()
        {
           
        }
        [TestMethod]
        public void CheckIfFullDeckIsCreated()
        {
            Deck.CreateFullDeck();

            Assert.AreEqual(52, Deck.CreateFullDeck().Cards.Count);
        }
    }
}
