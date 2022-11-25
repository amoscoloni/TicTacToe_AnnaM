using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;

namespace TicTacToePractice
{
    public class Presenter
    {
        private readonly ViewInterface view;
        private readonly TicTacToeModel currentSession;
        private int playerTurn;
        private int roundNumber;
        private bool gameEnded;
        private const int STARTING_PLAYER = 1;
        private const int FIRST_ROUND = 1;
        private const int PLAYER_ONE = 1;
        private const int PLAYER_TWO = 2;
        public Presenter(ViewInterface view)
        {
            currentSession = new TicTacToeModel();
            this.view = view;
            NewGame();
        }

        public void NewGame()
        {
            currentSession.NewBoard();
            playerTurn = STARTING_PLAYER;
            roundNumber = FIRST_ROUND;
            gameEnded = false;
            view.Refresh();
            view.DrawBoard();
            view.AdvanceRound(roundNumber);
            view.PlayerTurn(playerTurn);
        }

        public bool CheckIfGameEnded()
        {
            if (gameEnded)
            {
                return gameEnded;
            }
            else if (currentSession.status == TicTacToeModel.PlayStatus.won)
            {
                view.GameWon(currentSession.NextPlayer);
                gameEnded = true;

                return true;
            }
            else if (currentSession.status == TicTacToeModel.PlayStatus.draw)
            {
                view.GameTied();
                gameEnded = true;

                return true;
            }

            return false;
        }

        private bool CheckForError()
        {
            return currentSession.GameError != TicTacToeModel.ErrorCodes.NoError;
        }

        public void PlayTurn()
        {
            if (!gameEnded)
            {
                string currentPlayerSymbol = (playerTurn == PLAYER_ONE) ? view.GetPlayerOneSymbol() : view.GetPlayerTwoSymbol();

                int[,] positionOfPlay = view.GetUserInput();
                int row = positionOfPlay[0, 0];
                int column = positionOfPlay[0, 1];


                currentSession.MakePlay(playerTurn, row, column);

                if (CheckForError())
                {
                    view.ShowError(string.Format("Error: {0}", Enum.GetName(typeof(TicTacToeModel.ErrorCodes), currentSession.GameError)));

                }
                else
                {
                    view.PlacePlayer(positionOfPlay, currentPlayerSymbol);

                    if (!CheckIfGameEnded())
                    {
                        if (playerTurn == PLAYER_TWO)
                        {
                            view.AdvanceRound(++roundNumber);
                        }

                        playerTurn = currentSession.NextPlayer;
                        view.PlayerTurn(playerTurn);
                    }
                    // view.DrawBoard();
                }
            }

        }
    }
}
