﻿using System.Collections.Generic;

namespace PokerHands.Objects
{
    public enum HandType
    {
        HighCard,
        Pair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush
    }

    public class Hand
    {
        public List<Card> Cards { get; set; }
        public HandType HandType { get; set; }
        private Dictionary<CardValue, int> ValueDistribution { get; set; }
        public CardValue[] HighCardList { get; set; }

        public Hand(List<Card> cards)
        {
            Cards = cards;
            GenerateDistribution();
            CalculateHandType();
        }

        public WinLoseDraw DoesBeat(Hand otherHand)
        {
            if (HandType == otherHand.HandType)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (HighCardList[i] == otherHand.HighCardList[i])
                    {
                        continue;
                    }

                    if (HighCardList[i] > otherHand.HighCardList[i])
                    {
                        return WinLoseDraw.Win;
                    }
                    else
                    {
                        return WinLoseDraw.Lose;
                    }
                }

                return WinLoseDraw.Draw;
            }

            if (HandType > otherHand.HandType)
            {
                return WinLoseDraw.Win;
            }

            return WinLoseDraw.Lose;
        }

        private void CalculateHandType()
        {
            var isStraight = IsStraight();
            var isFlush = IsFlush();
            var is3OfAKind = HasGrouping(3);
            var is4OfAKind = HasGrouping(4);
            var is1Pair = HasGrouping(2);
            var is2Pair = HasTwoPair();

            if (isStraight && isFlush)
            {
                HandType = HandType.StraightFlush;
                SetHighCardList(HandType.StraightFlush);
            }
            else if (is4OfAKind)
            {
                HandType = HandType.FourOfAKind;
                SetHighCardList(HandType.FourOfAKind);
            }
            else if (is3OfAKind && is1Pair)
            {
                HandType = HandType.FullHouse;
                SetHighCardList(HandType.FullHouse);
            }
            else if (isFlush)
            {
                HandType = HandType.Flush;
                SetHighCardList(HandType.Flush);
            }
            else if (isStraight)
            {
                HandType = HandType.Straight;
                SetHighCardList(HandType.Straight);
            }
            else if (is3OfAKind)
            {
                HandType = HandType.ThreeOfAKind;
                SetHighCardList(HandType.ThreeOfAKind);
            }
            else if (is2Pair)
            {
                HandType = HandType.TwoPairs;
                SetHighCardList(HandType.TwoPairs);
            }
            else if (is1Pair)
            {
                HandType = HandType.Pair;
                SetHighCardList(HandType.Pair);
            }
            else
            {
                HandType = HandType.HighCard;
                SetHighCardList(HandType.HighCard);
            }
        }

        private void SetHighCardList(HandType type)
        {
            HighCardList = new CardValue[5] { CardValue.INVALID, CardValue.INVALID, CardValue.INVALID, CardValue.INVALID, CardValue.INVALID };
            switch (type)
            {
                case HandType.HighCard:
                case HandType.Flush:
                    FindHighCardsTopDown(1);
                    break;
                case HandType.Pair:
                    FindHighCardFromAmount(2);
                    break;
                case HandType.TwoPairs:
                    FindHighCardsTopDown(2);
                    break;
                case HandType.ThreeOfAKind:
                case HandType.FullHouse:
                    FindHighCardFromAmount(3);
                    break;
                case HandType.Straight:
                case HandType.StraightFlush:
                    FindHighCardsTopDown(1);

                    //correct for Ace = 1 or Ace high
                    if (HighCardList[0] == CardValue.Ace && HighCardList[1] == CardValue.Five)
                    {
                        HighCardList = new CardValue[5] { CardValue.Five, CardValue.Four, CardValue.Three, CardValue.Two, CardValue.LowAce};
                    }
                    break;
                case HandType.FourOfAKind:
                    FindHighCardFromAmount(4);
                    break;
                default:
                    break;
            }
        }

        private void FindHighCardFromAmount(int amt)
        {
            foreach (var dist in ValueDistribution)
            {
                if (dist.Value == amt)
                {
                    HighCardList[0] = dist.Key;
                }
            }
        }

        private void FindHighCardsTopDown(int amt)
        {
            var insertIndex = 0;
            for (int i = ValueDistribution.Count + 1; i >= 2; i--)
            {
                if (ValueDistribution[(CardValue)i] == amt)
                {
                    HighCardList[insertIndex] = (CardValue)i;
                    insertIndex++;
                }
            }
        }

        private void GenerateDistribution()
        {
            var distro = new Dictionary<CardValue, int>();
            distro.Add(CardValue.Ace, 0);
            distro.Add(CardValue.Two, 0);
            distro.Add(CardValue.Three, 0);
            distro.Add(CardValue.Four, 0);
            distro.Add(CardValue.Five, 0);
            distro.Add(CardValue.Six, 0);
            distro.Add(CardValue.Seven, 0);
            distro.Add(CardValue.Eight, 0);
            distro.Add(CardValue.Nine, 0);
            distro.Add(CardValue.Ten, 0);
            distro.Add(CardValue.Jack, 0);
            distro.Add(CardValue.Queen, 0);
            distro.Add(CardValue.King, 0);

            foreach (var card in Cards)
            {
                distro[card.CardValue]++;
            }

            ValueDistribution = distro;
        }

        private bool IsStraight()
        {
            var runCount = 0;
            if (HasAceAndTwo())
            {
                runCount = 1;
            }

            for (int i = 2; i <= 14; i++)
            {
                if (ValueDistribution[(CardValue)i] > 0)
                {
                    runCount++;
                    if (runCount == 5) break;
                }
                else if (runCount > 0)
                {
                    return false;
                }
            }

            if (runCount == 5)
            {
                return true;
            }

            return false;
        }

        private bool HasAceAndTwo()
        {
            return ValueDistribution[CardValue.Ace] > 0 && ValueDistribution[CardValue.Two] > 0;
        }

        private bool IsFlush()
        {
            var suite = Cards[0].Suit;
            foreach (var card in Cards)
            {
                if (card.Suit != suite)
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasGrouping(int count)
        {
            foreach (var x in ValueDistribution)
            {
                if (x.Value == count)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasTwoPair()
        {
            var count = 0;
            foreach (var x in ValueDistribution)
            {
                if (x.Value == 2)
                {
                    count++;
                }
            }

            return count == 2;
        }
    }
}
