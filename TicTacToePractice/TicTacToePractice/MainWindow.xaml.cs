using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe;

namespace TicTacToePractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TicTacToeModel game;
        public string playerOneSymbol;
        public string playerTwoSymbol;
        public MainWindow()
        {
            InitializeComponent();
            playerOneSymbol = PlayerSelectionMenu.DEFAULT_PLAYER_ONE_SYMBOL;
            playerTwoSymbol = PlayerSelectionMenu.DEFAULT_PLAYER_TWO_SYMBOL;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            Game gameWindow = new Game(this);
            gameWindow.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            PlayerSelectionMenu playerSelectionMenu = new PlayerSelectionMenu(this);
            playerSelectionMenu.ShowDialog();
        }
    }
}
