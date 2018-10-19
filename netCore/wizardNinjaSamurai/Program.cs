using System;

namespace wizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
        Human HumanX = new Human("HumanX");
        Wizard WizardY = new Wizard("WizardY");
        Ninja NinjaZ = new Ninja("NinjaZ");

        Samurai SamuraiS = new Samurai("SamuraiS");


        System.Console.WriteLine("People created:");
        HumanX.DisplayStats();
        WizardY.DisplayStats();
        NinjaZ.DisplayStats();
        SamuraiS.DisplayStats();

        System.Console.WriteLine("\n\nActions performed:");
        WizardY.Fireball(HumanX);
        NinjaZ.Steal(WizardY);   
        NinjaZ.GetAway();
        SamuraiS.DeathBlow(WizardY);
        HumanX.Attack(SamuraiS);
        HumanX.Attack(SamuraiS);
        HumanX.Attack(SamuraiS);
        HumanX.Attack(SamuraiS);
        System.Console.WriteLine($"HumanX attacked {SamuraiS.name}, {SamuraiS.name}'s health is now: {SamuraiS.health}");
        SamuraiS.Meditate();


        System.Console.WriteLine("\n\nAll People's Stats After Actions:");
        HumanX.DisplayStats();
        WizardY.DisplayStats();
        NinjaZ.DisplayStats();
        SamuraiS.DisplayStats();
        
        }
    }
}