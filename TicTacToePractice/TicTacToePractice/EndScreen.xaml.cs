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
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        private MainWindow mainWindow;
        public EndScreen(string displayMessage, MainWindow window)
        {
            InitializeComponent();

            tbTitle.Text = displayMessage;
            mainWindow = window;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            Game gameWindow = new Game(mainWindow);
            this.Close();
            gameWindow.ShowDialog();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            // can we avoid opening a second main window
            // MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Activate();
        }

        private void btnExitGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Close();
        }
    }
}
