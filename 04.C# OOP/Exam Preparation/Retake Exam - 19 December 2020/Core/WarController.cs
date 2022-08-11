using System;
using System.Collections.Generic;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using System.Linq;
using System.Text;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private List<Item> items;
		public WarController()
		{
			characters = new List<Character>();
			items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string type = args[0];
			string name = args[1];

			Character character;

            switch (type)
            {
                case "Warrior":
					character = new Warrior(name);
                    break;
				case "Pries":
					character = new Priest(name);
					break;
					default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }

			characters.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

            switch (itemName)
            {
                case "FirePotion":
					item = new FirePotion();
                    break;
				case "HealthPotion":
					item = new HealthPotion();
					break;
				default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

			items.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			var targetName = characters.FirstOrDefault(x => x.Name == characterName);

            if (targetName == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!items.Any())
            {
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

			var item = items.Last();
			targetName.Bag.AddItem(item);

			items.RemoveAt(items.Count - 1);
			return string.Format(string.Format(SuccessMessages.PickUpItem, targetName, item.GetType().Name));
 
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			var targetName = characters.FirstOrDefault(x => x.Name == characterName);

			if (targetName == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			var item = targetName.Bag.GetItem(itemName);
			targetName.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			var ordered = characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);

            foreach (var character in ordered)
            {
				string lifeStatus = character.IsAlive == true ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealt}, AP: {character.Armor}/{character.BaseArmor}, Status: {lifeStatus}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			throw new NotImplementedException();
		}

		public string Heal(string[] args)
		{
			throw new NotImplementedException();
		}
	}
}
