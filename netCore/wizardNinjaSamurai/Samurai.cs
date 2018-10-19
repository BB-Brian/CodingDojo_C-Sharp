namespace wizardNinjaSamurai
{
 public class Samurai: Human
    {
        public Samurai(string name): base(name)
        {
            this.health = 200;
        }

        public Samurai DeathBlow(object deathBlowTarget)
        {
            Human target = (Human)deathBlowTarget;
            if(target.health < 50)
            {
                target.health = 0;
                System.Console.WriteLine($"You killed {target.name} with your deathblow!");
            }
            else
            {
                Attack(target);
                System.Console.WriteLine($"{target.name} has too much life for your deathblow to work. Dealt regular damage.");

                target.DisplayStats();
            }
            return this;
        }

        public Samurai Meditate()
        {
            this.health = 200;
            System.Console.WriteLine($"Samurai {this.name}'s health fully recovered.");
            this.DisplayStats();
            return this;
        }

    }
}
