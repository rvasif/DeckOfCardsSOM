using System;
using TechTalk.SpecFlow;
using DeckOfCardsBusinessLogic;
using FluentAssertions;

namespace DeckOfCards.Features
{
    [Binding]
    public class DeckofPlayingCardsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private Deck _deck;
        private int _totalNumberofCards;

        public DeckofPlayingCardsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a deck of cards")]
        public void GivenADeckOfCards()
        {
            _deck = Deck.CreateFullDeck();
        }
        
        [When(@"I count each card")]
        public void WhenICountEachCard()
        {
            _totalNumberofCards = _deck.Cards.Count;
        }
        
        [When(@"I check for suits")]
        public void WhenICheckForSuits()
        {
            foreach (Card card in _deck.Cards)
            {
                DoesCardHaveAValidSuit(card).Should().BeTrue();
            }
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
            _deck.Cards.Count.Should().Be(p0);
        }

        [Then(@"I see hearts, clubs, spades, and diamonds")]
        public void ThenISeeHeartsClubsSpadesAndDiamonds()
        {
            foreach (Card card in _deck.Cards)
            {
                card.Suit.Should().Match<Suit>(x => x == Suit.Clubs || x == Suit.Diamonds || x == Suit.Hearts || x == Suit.Spades); 
            }
        }

        [Then(@"I have (.*) cards: Ace, (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), Jack, Queen, King")]
        public void ThenIHaveCardsAceJackQueenKing(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9)
        {
            int singleSuitCounter = 0;

            foreach (Card card in _deck.Cards)
            {
                if (card.Suit == Suit.Clubs)
                {
                    singleSuitCounter++;
                }                
            }
            singleSuitCounter.Should().Be(13);
        }
                       
        [Then(@"the card is worth (.*)")]
        public void ThenTheCardIsWorth(string p0, Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (Card card in _deck.Cards)
                {
                    if (row["<face_value>"] == card.CardValue.ToString())
                    {
                        row["<point_value>"].Should().Be(1.ToString());
                    }

                    if (row["<face_value>"] == CardValue.King.ToString())
                    {
                        row["<point_value>"].Should().Be(10.ToString());
                    }

                    if (row["<face_value>"] == CardValue.Jack.ToString())
                    {
                        row["<point_value>"].Should().Be(10.ToString());
                    }
                }
            }

        }
        
        [Then(@"the face cards are ordered Jack, Queen, King")]
        public void ThenTheFaceCardsAreOrderedJackQueenKing()
        {
            Deck deck = Deck.CreateFullDeck();
            deck.SortFaceCards();
            deck.Cards[51].CardValue.Should().Be(CardValue.King);
            deck.Cards[50].CardValue.Should().Be(CardValue.Queen);
            deck.Cards[49].CardValue.Should().Be(CardValue.Jack);
        }
    }
}
