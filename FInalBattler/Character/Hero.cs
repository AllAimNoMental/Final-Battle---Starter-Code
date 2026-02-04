using FinalBattler.Character.Upgrades;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero
    {

        public int Health { get; set; }
        public int Power { get; set; }
        public int Luck { get; set; }
        public int Mana { get; set; }
        public int ExperienceRemaining { get; set; }
        public CombatClass CombatClass { get; set; }
        public List<Item> Items { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Equipment> Equipment { get; set; }

        public Hero()
        {
            Name = "Unknown";
            Level = 0;
            TotalHealth = 1;
            TotalLuck = 1;
            TotalPower = 1;

        }

        public void LevelUp()
        {
            Random random = new Random();
            switch (CombatClass)
            {
                case CombatClass.None:
                    break;

                case CombatClass.Warrior:
                    Health += random.Next(10, 21);
                    Power += random.Next(1, 4);
                    Luck += random.Next(1, 4);
                    break;

                case CombatClass.Wizard:
                    Health += random.Next(1, 16);
                    Power += random.Next(3, 6);
                    Luck += random.Next(1, 4);
                    break;

                case CombatClass.Rogue:
                    Health += random.Next(1, 16);
                    Power += random.Next(1, 4);
                    Luck += random.Next(3, 6);
                    break;
            }
        }

        public void DisplayStats(bool showTotalStats = false)
        {

        }
       public  void CalculateTotals()
        {

        }

    }
}
