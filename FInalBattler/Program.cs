

using FinalBattler.Character;
using FinalBattler.GamePlay;

public class Program
{
    static void Main()
    {
        Hero player1 = new Hero("Luis");
        Hero player2 = new Hero("Craig");
        Console.WriteLine(" What kind of hero do you want to be player 1");
        Console.WriteLine("1.Warrior");
        Console.WriteLine("2.Wizard");
        Console.WriteLine("3.Rogue");
        int heroeType1 = int.Parse(Console.ReadLine());

        Console.WriteLine(" What kind of hero do you want to be player 2");
        Console.WriteLine("1.Warrior");
        Console.WriteLine("2.Wizard");
        Console.WriteLine("3.Rogue");
        int heroeType2 = int.Parse(Console.ReadLine());



        switch (heroeType1)
        {
            case 1:
                player1.CombatClass = CombatClass.Warrior;
                break;

            case 2:
                player1.CombatClass = CombatClass.Wizard;
                break;
            case 3:
                player1.CombatClass = CombatClass.Rogue;
                break;
        }
        player1.LevelUp();

        switch (heroeType2)
        {
            case 1:
                player1.CombatClass = CombatClass.Warrior;
                break;

            case 2:
                player1.CombatClass = CombatClass.Wizard;
                break;
            case 3:
                player1.CombatClass = CombatClass.Rogue;
                break;
        }
        player2.LevelUp();

        Combatients players = new Combatients(player1, player2);

        CombatBehavior fight;
        Console.WriteLine("You wanna fight with or without magic 1/2");
        int options = int.Parse(Console.ReadLine());
        if (options == 1)
        {
            fight = new CombatHandbyHand(players);
        }
        else
        {
            fight = new MagicCombat(players);
            
        }
        fight.CombatSimulation();
    }
}

