using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;


namespace Tests
{
    public class TestEcon
    {
        GameObject ui;
        BankUi bankUi;
        Bank bank;

        [OneTimeSetUp]
        public void oneTimeSetup()
        {
        

        }

        [Test]
        public void TestTransaction()
        {
            ui = GameObject.Find("BankUi");
            bankUi = ui.GetComponent<BankUi>();
            bank = new Bank();

            bank.Red = 0;
            bank.Blue = 0;

            Assert.That(bank.Transaction(Currency.red, 1));
            Assert.That(bank.Red == 1);
            Assert.That(bank.Transaction(Currency.red, -1));
            Assert.That(bank.Red == 0);
            Assert.That(bank.Transaction(Currency.blue, -1) == false);
        }

        [Test]
        public void TestCheckTransaction()
        {

            bank.Red = 0;
            bank.Blue = 0;

            Assert.That(bank.CheckTransaction(Currency.red, 1));
            Assert.That(!bank.CheckTransaction(Currency.red, -1));
            Assert.That(bank.CheckTransaction(Currency.blue, 1));
            Assert.That(!bank.CheckTransaction(Currency.blue, -1));
            Assert.That(bank.CheckTransaction(Currency.coin, 1));
            Assert.That(!bank.CheckTransaction(Currency.coin, -1));
        }
        // A Test behaves as an ordinary method
        [Test]
        public void TestEconSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestEconWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
