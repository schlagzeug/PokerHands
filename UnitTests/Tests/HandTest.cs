using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands.Objects;

namespace UnitTests
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void VerifyHighCardHandType()
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

            Assert.AreEqual(hand.HandType, HandType.HighCard, "High Card not assesing correctly");
        }

        [TestMethod]
        public void VerifyPairHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("AD"),
                new Card("JH"),
                new Card("3C"),
                new Card("7H"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.Pair, "Pair not assesing correctly");
        }

        [TestMethod]
        public void VerifyTwoPairHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("AD"),
                new Card("3H"),
                new Card("3C"),
                new Card("7H"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.TwoPairs, "Two pair not assesing correctly");
        }

        [TestMethod]
        public void VerifyThreeOfAKindHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("AD"),
                new Card("AH"),
                new Card("3C"),
                new Card("7H"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.ThreeOfAKind, "Three of a kind not assesing correctly");
        }

        [TestMethod]
        public void VerifyStraightHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("2D"),
                new Card("4H"),
                new Card("3C"),
                new Card("5H"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.Straight, "Straight not assesing correctly");
        }

        [TestMethod]
        public void VerifyFlushHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("5S"),
                new Card("JS"),
                new Card("3S"),
                new Card("7S"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.Flush, "Flush not assesing correctly");
        }

        [TestMethod]
        public void VerifyFullHouseHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("AD"),
                new Card("AH"),
                new Card("7C"),
                new Card("7H"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.FullHouse, "Full House not assesing correctly");
        }

        [TestMethod]
        public void VerifyFourOfAKindHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("AD"),
                new Card("AH"),
                new Card("AC"),
                new Card("7H"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.FourOfAKind, "Four Of A Kind not assesing correctly");
        }

        [TestMethod]
        public void VerifyStraightFlushHandType()
        {
            var cardList = new List<Card>()
            {
                new Card("AS"),
                new Card("KS"),
                new Card("QS"),
                new Card("JS"),
                new Card("10S"),
            };
            var hand = new Hand(cardList);

            Assert.AreEqual(hand.HandType, HandType.StraightFlush, "Straight Flush not assesing correctly");
        }
    }
}
