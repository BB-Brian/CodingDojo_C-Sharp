namespace wizardNinjaSamurai
{
 public class Ninja: Human
    {
        public Ninja(string name): base(name)
        {
            this.dexterity = 175;
        }

        public Ninja Steal(object stealTarget)
        {
            Human target = (Human)stealTarget;
            int preAttackHealth = target.health;

            System.Console.WriteLine($"Target's Health Before Attack: {preAttackHealth}");
            System.Console.WriteLine($"Ninja's Health Before Steal {this.health}\n");

            Attack(target);
            int attackDamage = preAttackHealth - target.health;

            System.Console.WriteLine($"Ninja Attack Damage: {attackDamage}\n");

            int targetHealth = target.health;

            System.Console.WriteLine($"Target's Current Health: {targetHealth}");

            this.health += 10;

            System.Console.WriteLine($"Ninja's Current Health: {this.health}\n");;

            return this;
        }

        public Ninja GetAway()
        {
            this.health -= 15;
            return this;
        }     
    }
}
