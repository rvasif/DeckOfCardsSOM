using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCardsBusinessLogic
{
    public class Deck
    {
        private static Random random = new Random();
        public List<Card> Cards { get; set; }

        private Deck()
        {
            Cards = new List<Card>();  
        }

        public static Deck CreateFullDeck()
        {
            Deck deck = new Deck();

            for (int suitIndex = 0; suitIndex < Constants.DeckValues.maximumNumberofSuits; suitIndex++)
            {
                for (int cardValueIndex = 0; cardValueIndex < Constants.DeckValues.maximumNumberofCardsonInASingleSuit ; cardValueIndex++)
                {
                    deck.Cards.Add(new Card((CardValue)cardValueIndex, (Suit)suitIndex));
                }
            }
            return deck;
        }

        public void SortFaceCards()
        {
            Cards.Sort();
        }
    }
}
