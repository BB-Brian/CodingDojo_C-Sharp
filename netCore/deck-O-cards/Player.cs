using System.Collections.Generic;

namespace deck_O_cards
{
    public class Player
    {
        string playerName;
        List<Card> hand;

        public Player(string name)
        {
            this.playerName = name;
            this.hand = new List<Card>();
        }
    
        public Card Draw(Deck aDeck)
        {
            Card drawCard = aDeck.Deal();   
            this.hand.Add(drawCard);
            return drawCard;
        }

        public Card Discard(int idx)
        {
            if(idx > this.hand.Count - 1)
            {
                return null;
            }
            else
            {
                Card discardedCard = this.hand[idx];
                this.hand.Remove(this.hand[idx]);
                return discardedCard;
            }
        }
    }
}