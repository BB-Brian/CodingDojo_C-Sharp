using System;

namespace deck_O_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card myCard = new Card("A", "Spades", 1);
            
            Deck myDeck = new Deck();
            
            myDeck.Shuffle();
            
            Card drawnCard = myDeck.Deal();
            
            Player p1 = new Player("Darth Vader");
            
            p1.Draw(myDeck);
            p1.Draw(myDeck);
            p1.Draw(myDeck);
            p1.Draw(myDeck);
            p1.Draw(myDeck);
            
            Card discardedCard = p1.Discard(4);
            p1.Discard(1);
            p1.Discard(2);
            
            myDeck.AddDiscard(discardedCard);
        }
    }
}
