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
            var deck1 = Deck.CreateFullDeck();
            var deck2 = Deck.CreateFullDeck();
            Console.ReadLine();
            Console.WriteLine("Deck of Cards");
            Console.Write("Press any key");
            Console.WriteLine("Deck of Cards.....");
        }
    }
}
