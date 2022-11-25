using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicTacToe;

namespace TicTacToePractice
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    /// 
    public partial class Game : Window, ViewInterface
    {
        private int[,] cellIndexes;
        private readonly string PLAYER_ONE_SYMBOL;
        private readonly string PLAYER_TWO_SYMBOL;
        private MainWindow mainWindow;
        private readonly Presenter presenter;


        public Game(MainWindow window)
        {
            InitializeComponent();
            presenter = new Presenter(this);
            SetCellIndexes();
            mainWindow = window;
            PLAYER_ONE_SYMBOL = window.playerOneSymbol;
            PLAYER_TWO_SYMBOL = window.playerTwoSymbol;
        }

        private void SetCellIndexes()
        {
            cellIndexes = new int[3, 3];
            int startingIndex = 1;
            const int STEP = 2;

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cellIndexes[i, j] = startingIndex;
                    startingIndex += STEP;
                }
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            presenter.PlayTurn();
        }

        public void GameWon(int player)
        {
            string WINNER_MESSAGE = $"Player {player} won the game!";
            EndScreen endScreen = new EndScreen(WINNER_MESSAGE, mainWindow);
            this.Close();
            endScreen.Show();
        }

        public void GameTied()
        {
            const string TIE_MESSAGE = "The game ended in a draw!";
            EndScreen endScreen = new EndScreen(TIE_MESSAGE, mainWindow);
            endScreen.ShowDialog();
            this.Close();
        }

        public string GetPlayerOneSymbol()
        {
            return PLAYER_ONE_SYMBOL;
        }

        public string GetPlayerTwoSymbol()
        {
            return PLAYER_TWO_SYMBOL;
        }

        public void PlayerTurn(int player)
        {
            tbTurn.Text = string.Format("Player {0}'s Turn", player);
        }

        public int[,] GetUserInput()
        {
            string rowString = (cmbRow.SelectedItem as ComboBoxItem).Content.ToString();
            string colString = (cmbCol.SelectedItem as ComboBoxItem).Content.ToString();

            var row = Int32.Parse(rowString);
            var col = Int32.Parse(colString);

            int[,] position = { { row - 1, col - 1 } };

            return position;
        }

        public void DrawBoard(){ }

        public void AdvanceRound(int roundNumber)
        {
            tbRound.Text = $"Round {roundNumber}";
        }

        public void PlacePlayer(int[,] position, string playerSymbol)
        {
            int cellIndex = cellIndexes[position[0,0], position[0, 1]];

            if (board.Children[cellIndex] as TextBlock != null)
            {
                (board.Children[cellIndex] as TextBlock).Text = playerSymbol;
            }

        }
        // not implemented
        public void Refresh() {  }

        public void ShowError(string error)
        {
            MessageBoxResult messageBox = MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
