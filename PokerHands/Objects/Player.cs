namespace PokerHands.Objects
{
    public enum WinLoseDraw
    {
        Win,
        Lose,
        Draw
    }

    public class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; set; }

        public Player(string name, Hand hand)
        {
            Name = name;
            Hand = hand;
        }

        public WinLoseDraw HasWon(Player otherPlayer)
        {
            return Hand.DoesBeat(otherPlayer.Hand);
        }
    }
}
