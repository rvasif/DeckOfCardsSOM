using System;
using TechTalk.SpecFlow;
using DeckOfCardsBusinessLogic;
using FluentAssertions;

namespace DeckOfCards.Features
{
    [Binding]
    public class DeckofPlayingCardsSteps
    {
        private Deck deck;
        private int totalNumberofCards;

        [Given(@"a deck of cards")]
        public void GivenADeckOfCards()
        {
            //ScenarioContext.Current.Pending();
            deck = Deck.CreateFullDeck();
        }
        
        [When(@"I count each card")]
        public void WhenICountEachCard()
        {
            totalNumberofCards = deck.Cards.Count;
        }
        
        [When(@"I check for suits")]
        public void WhenICheckForSuits()
        {
            foreach (Card card in deck.Cards)
            {
                DoesCardHaveAValidSuit(card).Should().BeTrue();
            }
            //TODO Check for numbe of Suits from a deck of cards.
        }

        private bool DoesCardHaveAValidSuit(Card card)
        {
            bool doesCardHaveAValidSuit = false;
            if (card.Suit == Suit.Clubs || card.Suit == Suit.Diamonds || card.Suit == Suit.Hearts || card.Suit == Suit.Spades)
            {
                doesCardHaveAValidSuit = true;
            }
            return doesCardHaveAValidSuit;
        }

        [When(@"I count all the cards in a single suit")]
        public void WhenICountAllTheCardsInASingleSuit()
        {

        }
        
        [When(@"I have a card with (.*)")]
        public void WhenIHaveACardWith(string face_value)
        {

        }
        
        [Then(@"I have a total of (.*) cards")]
        public void ThenIHaveATotalOfCards(int p0)
        {
            deck.Cards.Count.Should().Be(p0);
        }
        
        [Then(@"I see hearts, clubs, spades, and diamonds")]
        public void ThenISeeHeartsClubsSpadesAndDiamonds()
        {

        }

        [Then(@"I have (.*) cards: Ace, (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), Jack, Queen, King")]
        public void ThenIHaveCardsAceJackQueenKing(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9)
        {
            //TODO Check Card worth
            foreach (Card card in deck.Cards)
            {
                DoesCardHaveAValidSuit(card).Should().BeTrue();
            }
        }
                       
        [Then(@"the card is worth (.*)")]
        public void ThenTheCardIsWorth(string p0, Table table)
        {
            //ScenarioContext.Current.Pending();
            foreach (TableRow row in table.Rows)
            {
                foreach (CardValue cardvalue in (CardValue[])Enum.GetValues(typeof(CardValue)))
                {
                    if (row["<face_value>"] == cardvalue.ToString())
                    { 

                    }
                }
                //TODO Check Card worth
                
            }

        }
        
        [Then(@"the face cards are ordered Jack, Queen, King")]
        public void ThenTheFaceCardsAreOrderedJackQueenKing()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
