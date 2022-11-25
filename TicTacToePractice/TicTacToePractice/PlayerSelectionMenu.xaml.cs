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

namespace TicTacToePractice
{
    /// <summary>
    /// Interaction logic for PlayerSelectionMenu.xaml
    /// </summary>
    public partial class PlayerSelectionMenu : Window
    {
        private string playerOptionPlayerOneSelection;
        private string playerOptionPlayerTwoSelection;
        private readonly Brush SELECTED_OPTION_COLOUR;
        private Brush selectOptionPlayerOnePreviousColour;
        private Brush selectOptionPlayerTwoPreviousColour;
        MainWindow window;
        public const string DEFAULT_PLAYER_ONE_SYMBOL = "❤";
        public const string DEFAULT_PLAYER_TWO_SYMBOL = "☼";
        private Button playerTwoSelectedButton;
        private Button playerOneSelectedButton;
        public PlayerSelectionMenu(MainWindow window)
        {
            InitializeComponent();

            this.window = window;
            playerOptionPlayerOneSelection = string.Empty;
            playerOptionPlayerTwoSelection = string.Empty;
            SELECTED_OPTION_COLOUR = (Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#FFF4BD");
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if (playerOptionPlayerOneSelection != string.Empty && playerOptionPlayerTwoSelection != string.Empty)
            {
                window.playerOneSymbol = playerOptionPlayerOneSelection;
                window.playerTwoSymbol = playerOptionPlayerTwoSelection;
                this.Close();
            }
            else if(playerOptionPlayerOneSelection == string.Empty && playerOptionPlayerTwoSelection == string.Empty)
            {
                window.playerOneSymbol = DEFAULT_PLAYER_ONE_SYMBOL;
                window.playerTwoSymbol = DEFAULT_PLAYER_TWO_SYMBOL;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a symbol for each player or no symbols for either to go with the defaults.", "Selection Error", MessageBoxButton.OK);
            }

        }

        private void btnOptionPlayerOne_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if((sender as Button).Content.ToString() != playerOptionPlayerOneSelection)
                {
                    if (playerOneSelectedButton != null)
                    {
                        playerOneSelectedButton.Background = selectOptionPlayerOnePreviousColour;
                    }

                    playerOptionPlayerOneSelection = (sender as Button).Content.ToString();
                    playerOneSelectedButton = (sender as Button);
                    selectOptionPlayerOnePreviousColour = (sender as Button).Background;
                    (sender as Button).Background = SELECTED_OPTION_COLOUR;
                }
                else
                {
                    playerOptionPlayerOneSelection = string.Empty;
                    (sender as Button).Background = selectOptionPlayerOnePreviousColour;
                }            
            }
            
        }
        private void btnOptionPlayerTwo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if ((sender as Button).Content.ToString() != playerOptionPlayerTwoSelection)
                {
                    if(playerTwoSelectedButton != null)
                    {
                        playerTwoSelectedButton.Background = selectOptionPlayerTwoPreviousColour;
                    }

                    playerOptionPlayerTwoSelection = (sender as Button).Content.ToString();
                    playerTwoSelectedButton = (sender as Button);
                    selectOptionPlayerTwoPreviousColour = (sender as Button).Background;
                    (sender as Button).Background = SELECTED_OPTION_COLOUR;
                }
                else
                {
                    playerOptionPlayerTwoSelection = string.Empty;
                    (sender as Button).Background = selectOptionPlayerTwoPreviousColour;
                }
            }
        }
    }
}
