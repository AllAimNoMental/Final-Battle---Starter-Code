

using FinalBattler.Character;
using FinalBattler.Character;
using FinalBattler.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace FinalBattler.GamePlay


{
    interface CombatBehavior
    {
        void AttackPhase(Hero Atttacker, Hero defender);
        void DefendPhase(Hero Attacker, Hero defender);
        void CombatSimulation();
    }


    public class Combatients
    {
        public Hero Hero1 { get; private set; }
        public Hero Hero2 { get; private set; }
        public Combatients(Hero hero, Hero heroSecond)
        {
            Hero1 = hero;
            Hero2 = heroSecond;
        }

    }
    public class CombatHandbyHand : CombatBehavior
    {
        private Combatients players;
        private Random rand = new Random();

        public CombatHandbyHand(Combatients players)
        {
            this.players = players;

        }

        public void AttackPhase(Hero atttacker, Hero enemy)
        {

            int damage = atttacker.Power + atttacker.Luck;
            enemy.Health -= damage;

        }
        public void DefendPhase(Hero attacker, Hero enemy)
        {

            enemy.Health -= attacker.Power / 3 + attacker.Luck/3;

        }
        public void CombatSimulation()
        {
            Hero currentAttacker = players.Hero1;
            Hero currentEnemy = players.Hero2;

            bool end = false;
            while (!end)
            {
                int dise = rand.Next(1, 7);
                Console.WriteLine(currentAttacker.Name + "Rolled the dise");
                if (dise >= 4)
                {
                    AttackPhase(currentAttacker, currentEnemy);
                    Console.WriteLine($"{currentAttacker.Name} Health: {currentAttacker.Health}");
                    Console.WriteLine($"{currentEnemy.Name} Health: {currentEnemy.Health}");

                }

                else
                {
                    Console.WriteLine(currentAttacker.Name + "missed");
                    Console.WriteLine(currentEnemy.Name + "get defense," + currentAttacker.Name + "made less damage");
                    DefendPhase(currentAttacker, currentEnemy);
                    Console.WriteLine($"{currentAttacker.Name} Health: {currentAttacker.Health}");
                    Console.WriteLine($"{currentEnemy.Name} Health: {currentEnemy.Health}");

                }
                Console.WriteLine($"Current {currentAttacker.Name} health |{currentAttacker.Health}| ");
                Console.WriteLine($"Current {currentEnemy.Name} health |{currentEnemy.Health}| ");




                if (players.Hero1.Health <= 0)
                {
                    Console.WriteLine(players.Hero2.Name + "Wins");
                    end = true;
                    Console.WriteLine($"{currentAttacker.Name} Health: {currentAttacker.Health}");
                    Console.WriteLine($"{currentEnemy.Name} Health: {currentEnemy.Health}");
                }
                else if (players.Hero2.Health <= 0)
                {
                    Console.WriteLine(players.Hero1.Name + "Wins");
                    end = true;
                    Console.WriteLine($"{currentAttacker.Name} Health: {currentAttacker.Health}");
                    Console.WriteLine($"{currentEnemy.Name} Health: {currentEnemy.Health}");

                }
                Hero swipe = currentAttacker;
                currentAttacker = currentEnemy;
                currentEnemy = swipe;


            }
        }

    }
    public class MagicCombat : CombatBehavior
    {
        private Combatients players;
        private Random rand = new Random();

        public MagicCombat(Combatients players)
        {
            this.players = players;

        }

        public void AttackPhase(Hero atttacker, Hero enemy)
        {

            int manaUsed = 3;
            if (atttacker.Mana >= manaUsed)
            {
                int damage = atttacker.Power / 3 + manaUsed;
                enemy.Health -= damage;
                atttacker.Mana -= manaUsed;

                Console.WriteLine(atttacker.Name + " used mana to attack ");

            }
            else
            {
                Console.WriteLine(atttacker.Name + " does not have enought mana to attack with magic ");
                int damage = atttacker.Power / 3;
                enemy.Health -= damage;
            }

        }
        public void DefendPhase(Hero attacker, Hero enemy)
        {
            int manaUsed = 3;
            if (attacker.Mana >= manaUsed)
            {
                enemy.Health -= attacker.Power / 3 + manaUsed / 3;
                attacker.Mana -= manaUsed;
            }
            else
            {
                enemy.Health -= attacker.Power / 3;
            }

        }
        public void CombatSimulation()
        {
            Hero currentAttacker = players.Hero1;
            Hero currentEnemy = players.Hero2;

            bool end = false;
            while (!end)
            {
                int dise = rand.Next(1, 7);
                Console.WriteLine(currentAttacker.Name + " Rolled the dise ");
                if (dise >= 4)
                {
                    AttackPhase(currentAttacker, currentEnemy);
                    Console.WriteLine($"{currentAttacker.Name} attacked {currentEnemy.Name} with magic and meele");
                    Console.WriteLine($"{currentAttacker.Name} Health: {currentAttacker.Health}");
                    Console.WriteLine($"{currentEnemy.Name} Health: {currentEnemy.Health}");
                }

                else
                {
                    Console.WriteLine(currentAttacker.Name + "missed");
                    Console.WriteLine(currentEnemy.Name + " get defense, " + currentAttacker.Name + "made less damage");
                    DefendPhase(currentAttacker, currentEnemy);
                    Console.WriteLine($"{currentAttacker.Name} Health: {currentAttacker.Health}");
                    Console.WriteLine($"{currentEnemy.Name} Health: {currentEnemy.Health}");
                }



                if (currentEnemy.Health <= 0)
                {
                    Console.WriteLine(currentAttacker.Name + "Wins");
                    end = true;
                    Console.WriteLine(currentAttacker.Name + " final health " + currentAttacker.Health);
                    Console.WriteLine(currentEnemy.Name + " final health " + currentEnemy.Health);
                }
                else if (currentAttacker.Health <= 0)
                {
                    Console.WriteLine(currentEnemy.Name + " Wins ");
                    end = true;
                    Console.WriteLine(currentEnemy.Name + " final health " + currentEnemy.Health);
                    Console.WriteLine(currentAttacker.Name + " final health " + currentAttacker.Health);
                }
                Hero swipe = currentAttacker;
                currentAttacker = currentEnemy;
                currentEnemy = swipe;
            }

        }
    }

}















