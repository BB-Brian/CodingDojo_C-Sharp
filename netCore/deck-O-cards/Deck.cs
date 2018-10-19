using System;
using System.Collections.Generic;

namespace deck_O_cards
{
    public class Deck
    {
        List<Card> cards;
        List<Card> discards;
        public Deck()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.cards = new List<Card>();
            this.discards = new List<Card>();
            string[] suits = new string[] {"Spades", "Clubs", "Diamonds", "Hearts"};
            string[] stringvals = new string[] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            int count = 0;
            foreach(string suit in suits)
            {
                for(int idx = 0; idx < 13; idx++)
                {
                    this.cards.Add(new Card(stringvals[idx],suit, idx + 1));
                    count++;
                }
            }
            for(int i = 0; i < 5; i++)
            {
                this.Shuffle();
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for(int idx = 0; idx < this.cards.Count; idx++)
            {
                int randomIndex = rand.Next(this.cards.Count);
                Card temp = this.cards[idx];
                this.cards[idx] = this.cards[randomIndex];
                this.cards[randomIndex] = temp;
            }
        }

        public Card Deal()
        {
            Card drawCard = this.cards[0];
            this.cards.Remove(drawCard);   // same as "this.cards.Remove(this.cards[0]);"
            return drawCard;
        }
        public void AddDiscard(Card aCard) // add Deck aDeck and call AddDiscard function to not have to call AddDiscard funcion in Program.cs
        {
            this.discards.Add(aCard);
        }

    }  
}
