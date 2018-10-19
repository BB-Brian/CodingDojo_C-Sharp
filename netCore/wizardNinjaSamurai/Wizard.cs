using System;

namespace wizardNinjaSamurai
{
    public class Wizard: Human
    {
        public Wizard(string name): base(name)
        {
            this.intelligence = 25;
            this.health = 50;
        }
        
        public Wizard Heal()
        {
            health  = intelligence * 10;
            return this;
        }

        public Wizard Fireball(object fireballTarget)
        {
            Random rand = new Random();
            int damage = rand.Next(20, 51);
            System.Console.WriteLine("Firball damage: {0}", damage); 
            Human target = (Human)fireballTarget;
            target.health -= damage;
            target.DisplayStats();
            return this;
        }
    }
}
