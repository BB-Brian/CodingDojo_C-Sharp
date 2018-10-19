namespace wizardNinjaSamurai
{
    public class Human
    {
        public string name;
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }

        public Human Attack(object obj)
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
            return this;
        }

        public Human DisplayStats()
        {
            System.Console.WriteLine($"Stats: Name: {this.name}, Strength: {this.strength}, Intelligence: {this.intelligence}, Dexterity {this.dexterity}, Health {this.health}");
            return this;
        }
    }
}
