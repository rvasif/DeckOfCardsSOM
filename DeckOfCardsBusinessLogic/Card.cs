using System;

namespace DeckOfCardsBusinessLogic
{
    public class Card : IComparable<Card>
    {
        public CardValue CardValue { get; private set; }
        public Suit Suit { get; private set; }

        public Card(CardValue cardValue, Suit suit)
        {
            CardValue = cardValue;
            Suit = suit;            
        }

        public override string ToString()
        {
            return CardValue + " of " + Suit;
        }

        public int CompareTo(Card other)
        {
            if(CardValue != other.CardValue)
            return CardValue.CompareTo(other.CardValue);

            return Suit.CompareTo(other.Suit);
        }

    }
}