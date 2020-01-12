namespace PokerHands.Objects
{
    public enum Suit
    {
        Diamond,
        Heart,
        Club,
        Spade
    }

    public enum CardValue
    {
        INVALID = -1,
        LowAce = 1,
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public CardValue CardValue { get; set; }

        public Card(string designation)
        {
            var suit = designation.Substring(designation.Length - 1);
            switch (suit.ToUpper())
            {
                case "D":
                    Suit = Suit.Diamond;
                    break;
                case "H":
                    Suit = Suit.Heart;
                    break;
                case "C":
                    Suit = Suit.Club;
                    break;
                case "S":
                    Suit = Suit.Spade;
                    break;
                default:
                    break;
            }

            var value = designation.Substring(0, designation.Length - 1);
            switch (value.ToUpper())
            {
                case "J":
                    CardValue = CardValue.Jack;
                    break;
                case "Q":
                    CardValue = CardValue.Queen;
                    break;
                case "K":
                    CardValue = CardValue.King;
                    break;
                case "A":
                    CardValue = CardValue.Ace;
                    break;
                default:
                    CardValue = (CardValue)int.Parse(value);
                    break;
            }
        }
    }
}
