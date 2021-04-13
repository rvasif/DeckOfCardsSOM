using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCardsBusinessLogic
{
    public class Deck
    {
        private static Random _random = new Random();
        public List<Card> Cards { get; private set; }

        private Deck()
        {
            Cards = new List<Card>();  
        }

        public static Deck CreateFullDeck()
        {
            Deck deck = new Deck();

            CardValue cardValue = CardValue.Ace;
            for (int suitIndex = 0; suitIndex < Constants.DeckValues.maximumNumberofSuits; suitIndex++)
            {
                for (int cardValueIndex = 0; cardValueIndex < Constants.DeckValues.maximumNumberofCardsonInASingleSuit; cardValueIndex++)
                {
                    cardValue = AddCardToDeck(deck, cardValue, suitIndex, cardValueIndex);
                }
            }
            return deck;
        }

        private static CardValue AddCardToDeck(Deck deck, CardValue cardValue, int suitIndex, int cardValueIndex)
        {
            if (cardValueIndex < 10)
            {
                cardValue = (CardValue)cardValueIndex + 1;

                deck.Cards.Add(new Card(cardValue, (Suit)suitIndex));
            }

            else if (cardValueIndex >= 10)
            {
                if (cardValueIndex == 10)
                {
                    cardValue = CardValue.Jack;
                }

                if (cardValueIndex == 11)
                {
                    cardValue = CardValue.Queen;
                }

                if (cardValueIndex == 11)
                {
                    cardValue = CardValue.King;
                }

                deck.Cards.Add(new Card(cardValue, (Suit)suitIndex));
            }

            return cardValue;
        }

        public void SortFaceCards()
        {
            Cards.GroupBy(x => x.Suit)
                .OrderByDescending(y => y.Count())
                .SelectMany(z => z.OrderByDescending(c => c.CardValue));
        }

        public void Shuffle()
        {
            List<Card> cardsToShuffle = new List<Card>(Cards);

            Cards.Clear();

            while (cardsToShuffle.Count > 0)
            {
                int cardIndex = _random.Next(cardsToShuffle.Count);

                Card cardToShuffle = cardsToShuffle[cardIndex];
                cardsToShuffle.RemoveAt(cardIndex);

                Cards.Add(cardToShuffle);
            }
        }
    }
}
