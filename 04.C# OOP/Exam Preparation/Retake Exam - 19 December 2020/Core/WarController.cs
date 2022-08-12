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
				case "Priest":
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
			string attackerName = args[0];
			string receiverName = args[1];

			var attacker = characters.FirstOrDefault(x => x.Name == attackerName);
			var defender = characters.FirstOrDefault(x => x.Name == attackerName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (defender == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, defender));
			}
			if (attackerName.GetType().Name == "Priest")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}

			Warrior warrior = attacker as Warrior;
			warrior.Attack(defender);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, defender.Name, defender.Health, defender.BaseHealt, defender.Armor, defender.BaseArmor));

			if (defender.IsAlive == false)
			{
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			var healer = characters.FirstOrDefault(x => x.Name == healerName);
			var receiver = characters.FirstOrDefault(x => x.Name == receiverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}
			if (healerName.GetType().Name == "Warrior")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			Priest priest = healer as Priest;
			priest.Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, healerName, receiverName, priest.AbilityPoints, receiverName, receiver.Health);

        }
	}
}
