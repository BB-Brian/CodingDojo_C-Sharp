namespace human
{
    public class Human
    {
    // Create a base Human class with five attributes: name, strength, intelligence, dexterity, and health.
        public string name;
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        // Give a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100. 
        // When an object is constructed from this class it should have the ability to pass a name
        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        // Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }

        // Now add a new method called attack, which when invoked, should attack another Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker).

        public void Attack(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                System.Console.WriteLine("Failed Attack");
            }
            else   
            {
                enemy.health -= strength * 5;
            }
        }
    }
}
