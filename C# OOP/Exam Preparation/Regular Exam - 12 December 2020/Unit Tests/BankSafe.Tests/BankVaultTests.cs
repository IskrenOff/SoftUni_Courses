using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{

    public class BankVaultTests
    {
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
        }

        [Test]
        public void ConstructorShouldCreateDictionaryWithNullValues()
        {
            Assert.That(vault.VaultCells.Values.All(x => x == null));
        }

        [Test]
        public void AddmethodShouldThrowExceptionIfCellAlreadyExist()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("D1", new Item("Pepi", "0987")));
        }

        [Test]
        public void AddmethodShouldThrowExceptionIfCellAlreadyTaken()
        {
            vault.AddItem("A1", new Item("Pepi", "0987"));
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", new Item("Iva", "1234")));
        }

        [Test]
        public void AddmethodShouldThrowExceptionIfItemAlreadyExist()
        {
            vault.AddItem("A1", new Item("Pesho", "1234"));
            vault.AddItem("A2", new Item("Mitko", "4567"));

            Assert.Throws<InvalidOperationException>(() => vault.AddItem("C1", new Item ("Mitko", "4567")));
        }

        [Test]
        public void AddmethodShouldAddItemInEmptyCell()
        {
            vault.AddItem("A1", new Item("Teo", "0001"));
            Assert.That(vault.VaultCells["A1"] != null);
        }

        [Test]
        public  void RemoveMethodShouldThrowExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("D1", new Item("Pepi", "1234")));
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionIfItemDosNotExist()
        {
            vault.AddItem("A1", new Item("Teo", "0000"));
            vault.AddItem("A2", new Item("Teo2", "0001"));

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1",new Item ("Pepi","1234")));
        }

        [Test]
        public void IsThisMethodWorks()
        {
            Item item1 = new Item("Teo", "0000");

            vault.AddItem("A1", item1);

            vault.RemoveItem("A1", item1);

            Assert.That(vault.VaultCells["A1"] == null);
        }
    }
}