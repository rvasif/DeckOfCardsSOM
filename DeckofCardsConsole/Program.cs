using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCardsBusinessLogic;

namespace DeckofCardsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fisrtDeck = Deck.CreateFullDeck();
            var secondDeck = Deck.CreateFullDeck();
            Console.WriteLine("Deck of Cards");
        }
    }
}
