using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private string name;
        private double baseHealt;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
			get => name;
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
				name = value;
            }
        }

        public double BaseHealt
        {
            get => baseHealt;
            private set => baseHealt = value;
        }

        public double Health
        {
            get => health;
            protected internal set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > baseHealt)
                {
                    value = baseHealt;
                }
                health = value;
            }
        }

        public double BaseArmor
        {
            get => baseArmor;
            private set => baseArmor = value;
        }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > baseArmor)
                {
                    value = baseArmor;
                }
                armor = value;
            }
        }

        public double AbilityPoints
        {
            get => abilityPoints;
            private set => abilityPoints = value;
        }

        public Bag Bag
        {
            get => bag;
            private set => bag = value;
        }


        public bool IsAlive { get; set; } = true;


        public void TakeDamage (double hitPoints)
        {
            EnsureAlive();

            double pointsLeft = 0;

            if (armor - hitPoints < 0)
            {
                pointsLeft = armor - hitPoints;
            }

            armor -= hitPoints;
            health -= Math.Abs(pointsLeft);

            if (health == 0)
            {
                IsAlive = false;
            }

        }

        public void UseItem (Item item)
        {
            EnsureAlive();

            item.AffectCharacter (this);
        }
        protected internal void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}