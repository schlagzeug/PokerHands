using System.Windows;
using System.Collections.Generic;
using PokerHands.Objects;

namespace PokerHands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ShowWinner_Click(object sender, RoutedEventArgs e)
        {
            Label_Winner.Content = string.Empty;
            if (ValidateInputs())
            {
                var player1 = new Player(TextBox_Player1Name.Text, new Hand(CardListFromText(TextBox_Player1Cards.Text)));
                var player2 = new Player(TextBox_Player2Name.Text, new Hand(CardListFromText(TextBox_Player2Cards.Text)));

                var didPlayer1Win = player1.HasWon(player2);
                switch (didPlayer1Win)
                {
                    case WinLoseDraw.Win:
                        Label_Winner.Content = $"{player1.Name} wins with {player1.Hand.HandType}";
                        break;
                    case WinLoseDraw.Lose:
                        Label_Winner.Content = $"{player2.Name} wins with {player2.Hand.HandType}";
                        break;
                    case WinLoseDraw.Draw:
                        Label_Winner.Content = "Draw game";
                        break;
                    default:
                        Label_Winner.Content = "Something went wrong...";
                        break;
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(TextBox_Player1Name.Text))
            {
                Label_Winner.Content = "Player 1 missing name";
                return false;
            }

            if (string.IsNullOrEmpty(TextBox_Player2Name.Text))
            {
                Label_Winner.Content = "Player 2 missing name";
                return false;
            }

            if (string.IsNullOrEmpty(TextBox_Player1Cards.Text))
            {
                Label_Winner.Content = "Player 1 missing cards";
                return false;
            }
            else
            {
                var x = CardListFromText(TextBox_Player1Cards.Text);
                if (x.Count != 5)
                {
                    Label_Winner.Content = "Player 1 invalid cards";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(TextBox_Player2Cards.Text))
            {
                Label_Winner.Content = "Player 2 missing cards";
                return false;
            }
            else
            {
                var x = CardListFromText(TextBox_Player2Cards.Text);
                if (x.Count != 5)
                {
                    Label_Winner.Content = "Player 2 invalid cards";
                    return false;
                }
            }

            return true;
        }

        private List<Card> CardListFromText(string text)
        {
            var cardList = new List<Card>();
            var split = text.Split(' ');

            foreach (var designation in split)
            {
                var card = new Card(designation);
                cardList.Add(card);
            }

            return cardList;
        }
    }
}
