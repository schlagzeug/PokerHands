using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands.Objects;

namespace UnitTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void VerifyHighValue()
        {
            var tenOfSpades = "10S";
            var ten = new Card(tenOfSpades);
            
            Assert.AreEqual(ten.CardValue, CardValue.Ten, "Ten isn't working");
        }

        [TestMethod]
        public void VerifyLowercaseValue()
        {
            var kingOfHearts = "kH";
            var king = new Card(kingOfHearts);

            Assert.AreEqual(king.CardValue, CardValue.King, "Lowercase Value not working");
        }

        [TestMethod]
        public void VerifyLowercaseSuit()
        {
            var sevenOfClubs = "7c";
            var seven = new Card(sevenOfClubs);

            Assert.AreEqual(seven.Suit, Suit.Club, "Lowercase Suit not working");
        }
    }
}
