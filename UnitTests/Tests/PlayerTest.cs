using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands.Objects;

namespace UnitTests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void VerifyPlayerName()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("5D"),
                new Card("JH"),
                new Card("3C"),
                new Card("7H"),
            };
            var hand = new Hand(cardList);

            var name = "seth";
            var player = new Player(name, hand);
            
            Assert.AreEqual(player.Name, name, true, "Player name not setting correctly");
        }
    }
}
