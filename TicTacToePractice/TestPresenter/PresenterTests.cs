using System;
using Xunit;
using TicTacToePractice;
using System.Collections.Generic;

namespace TestPresenter
{
    public class TestView : ViewInterface
    {
        public bool calledAdvanceRound;
        public bool calledDrawBoard;
        public bool calledGameWon;
        public bool calledGameDraw;
        public bool calledShowError;
        public bool calledRefresh;
        public bool calledPlayerTurn;
        public bool calledGetUserInput;
        public bool calledGetPlayerOneSymbol;
        public bool calledGetPlayerTwoSymbol;
        public string currentPlayer;
        public List<int[,]> playerOnePlays;
        public List<int[,]> playerTwoPlays;
        public int[,] currentPlayerInput;
        public int playerWon;
        public const int DIMENSION_OF_BOARD = 3;

        public const string PLAYER_ONE_SYMBOL = "X";
        public const string PLAYER_TWO_SYMBOL = "O";
        public int[,] board;

        public void AdvanceRound(int roundNumber)
        {
            calledAdvanceRound = true;
        }

        public void DrawBoard()
        {
            calledDrawBoard = true;
            board = new int[DIMENSION_OF_BOARD, DIMENSION_OF_BOARD];
        }

        public void GameTied()
        {
            calledGameDraw = true;
        }

        public void GameWon(int player)
        {
            calledGameWon = true;
            playerWon = player;
        }

        public string GetPlayerOneSymbol()
        {
            calledGetPlayerOneSymbol = true;
            return PLAYER_ONE_SYMBOL;
        }

        public string GetPlayerTwoSymbol()
        {
            calledGetPlayerTwoSymbol = true;
            return PLAYER_TWO_SYMBOL;
        }

        public int[,] GetUserInput()
        {
            calledGetUserInput = true;
            return currentPlayerInput;
        }

        public void PlacePlayer(int[,] position, string playerSymbol)
        {
            int playerNumber = (playerSymbol == PLAYER_ONE_SYMBOL) ? 1 : 2;
            board[position[0, 0], position[0, 1]] = playerNumber;
        }

        public void PlayerTurn(int player)
        {
            calledPlayerTurn = true;
        }

        public void Refresh()
        {
            calledRefresh = true;
        }

        public void ShowError(string error)
        {
            calledShowError = true;
        }
    }

    public class PresenterTests
    {
        private void PrepareNewGameTest(TestView view)
        {
            view.calledGameWon = false;
            view.calledGameDraw = false;
            view.calledRefresh = false;
            view.calledDrawBoard = false;
            view.calledAdvanceRound = false;
            view.calledPlayerTurn = false;
            view.board = new int[TestView.DIMENSION_OF_BOARD, TestView.DIMENSION_OF_BOARD];
            view.playerWon = 0;
        }

        private void SimulateGame(TestView view, List<List<int[,]>> allPlays, Presenter presenter)
        {
            const int PLAYER_ONE_TURN = 0;

            for (int i = 0; i < view.playerOnePlays.Count; i++)
            {
                for (int j = 0; j < allPlays.Count; j++)
                {
                    view.currentPlayerInput = allPlays[j][i];
                    presenter.PlayTurn();

                    Assert.True(view.calledGetUserInput);
                    Assert.True(view.board[(allPlays[j][i][0, 0]), (allPlays[j][i][0, 1])] == j + 1);

                    if (j == PLAYER_ONE_TURN)
                    {
                        Assert.True(view.calledGetPlayerOneSymbol);
                        Assert.False(view.calledGetPlayerTwoSymbol);
                        view.calledGetPlayerOneSymbol = false;
                    }
                    else
                    {
                        Assert.True(view.calledGetPlayerTwoSymbol);
                        Assert.False(view.calledGetPlayerOneSymbol);
                        view.calledGetPlayerTwoSymbol = false;
                    }

                    if (view.calledGameWon || view.calledGameDraw)
                    {
                        return;
                    }

                    Assert.True(view.calledPlayerTurn);

                    view.calledPlayerTurn = false;

                    if (j == PLAYER_ONE_TURN)
                    {
                        Assert.False(view.calledAdvanceRound);
                    }

                }

                view.calledGetUserInput = false;
                view.calledAdvanceRound = false;
            }
        }

        [Fact]
        public void TestConstructor()
        {
            // Arrange
            TestView view = new TestView();

            // Act
            Presenter presenter = new Presenter(view);

            // Assert
            Assert.IsType<Presenter>(presenter);
        }

        [Fact]
        public void TestNewGame()
        {
            // Arrange
            TestView view = new TestView();
            Presenter presenter = new Presenter(view);

            // Act
            presenter.NewGame();

            // Assert
            Assert.True(view.calledRefresh);
            Assert.True(view.calledDrawBoard);
            Assert.True(view.calledAdvanceRound);
            Assert.True(view.calledPlayerTurn);
        }

        [Fact]
        public void TestPlayerOneWin()
        {
            // Arrange
            TestView view = new TestView();
            Presenter presenter = new Presenter(view);

            PrepareNewGameTest(view);

            // creating list of moves for each player to ensure player 1 win
            view.playerOnePlays = new List<int[,]>()
            {
                new int[,]{{0,0}},
                new int[,]{{0,1}},
                new int[,]{{0,2}},

            };

            view.playerTwoPlays = new List<int[,]>()
            {
                new int[,]{{1,2}},
                new int[,]{{2,1}},
                new int[,]{{2,2}},

            };


            List<List<int[,]>> allPlays = new List<List<int[,]>> { view.playerOnePlays, view.playerTwoPlays };

            // Act + Assert
            SimulateGame(view, allPlays, presenter);

            // Assert
            Assert.True(view.playerWon == 1);
            Assert.True(view.calledGameWon);
            Assert.False(view.calledGameDraw);
        }

        [Fact]
        public void TestPlayerTwoWin()
        {
            // Arrange
            TestView view = new TestView();
            Presenter presenter = new Presenter(view);

            PrepareNewGameTest(view);

            // creating list of moves for each player to ensure player 2 win
            view.playerOnePlays = new List<int[,]>()
            {
                new int[,]{{0,0}},
                new int[,]{{0,1}},
                new int[,]{{1,0}},

            };

            view.playerTwoPlays = new List<int[,]>()
            {
                new int[,]{{1,1}},
                new int[,]{{0,2}},
                new int[,]{{2,0}},

            };


            List<List<int[,]>> allPlays = new List<List<int[,]>> { view.playerOnePlays, view.playerTwoPlays };

            // Act + Assert
            SimulateGame(view, allPlays, presenter);

            // Assert
            Assert.True(view.playerWon == 2);
            Assert.True(view.calledGameWon);
            Assert.False(view.calledGameDraw);
        }

        [Fact]
        public void TestDraw()
        {
            // Arrange
            TestView view = new TestView();
            Presenter presenter = new Presenter(view);

            PrepareNewGameTest(view);

            // creating list of moves for each player to ensure draw
            view.playerOnePlays = new List<int[,]>()
            {
                new int[,]{{0,0}},
                new int[,]{{1,2}},
                new int[,]{{2,0}},
                new int[,]{{0,1}},
                new int[,]{{1,1}},
            };

            view.playerTwoPlays = new List<int[,]>()
            {
                new int[,]{{0,2}},
                new int[,]{{1,0}},
                new int[,]{{2,2}},
                new int[,]{{2,1}},

            };


            List<List<int[,]>> allPlays = new List<List<int[,]>> { view.playerOnePlays, view.playerTwoPlays };

            // Act + Assert
            SimulateGame(view, allPlays, presenter);

            // Assert
            Assert.True(view.calledGameDraw);
            Assert.False(view.calledGameWon);
        }

        private void AssignCellsWithErrors(TestView view, List<List<int[,]>> allPlays, Presenter presenter)
        {
            const int PLAYER_ONE_TURN = 0;

            for (int i = 0; i < view.playerOnePlays.Count - 1; i++)
            {
                for (int j = 0; j < allPlays.Count; j++)
                {
                    view.currentPlayerInput = allPlays[j][i];
                    presenter.PlayTurn();

                    int counter = 0;
                    while (view.calledShowError)
                    {
                        int allPlaysRowValue = allPlays[j][i + counter][0, 0];
                        int allPlaysColumnValue = allPlays[j][i + counter][0, 1];

                        if (allPlaysRowValue < TestView.DIMENSION_OF_BOARD && allPlaysColumnValue < TestView.DIMENSION_OF_BOARD)
                        {
                            Assert.False(view.board[(allPlays[j][i + counter][0, 0]), (allPlays[j][i + counter][0, 1])] == j + 1);
                        }

                        Assert.True(view.calledShowError);
                        Assert.False(view.calledPlayerTurn);

                        view.calledShowError = false;

                        counter++;
                        view.currentPlayerInput = allPlays[j][i + counter];
                        presenter.PlayTurn();

                        Assert.True(view.calledGetUserInput);
                        view.calledGetUserInput = false;
                    }

                    // Assert.True(view.calledGetUserInput);
                    Assert.True(view.board[(allPlays[j][i + counter][0, 0]), (allPlays[j][i + counter][0, 1])] == j + 1);

                    Assert.True(view.calledPlayerTurn);

                    view.calledPlayerTurn = false;
                    view.calledShowError = false;

                    if (j == PLAYER_ONE_TURN)
                    {
                        Assert.False(view.calledAdvanceRound);
                    }

                }

                view.calledGetUserInput = false;
                view.calledAdvanceRound = false;
            }
        }

        [Fact]
        public void TestInputError()
        {
            const int INDEX_OF_INPUT_ERRORS = 1;
            TestView view = new TestView();
            Presenter presenter = new Presenter(view);

            PrepareNewGameTest(view);

            view.playerOnePlays = new List<int[,]>()
            {
                new int[,]{{0,0}},
                new int[,]{{1,1}}, // already assigned error
                new int[,]{{0,1}},

            };

            view.playerTwoPlays = new List<int[,]>()
            {
                new int[,]{{1,1}},
                new int[,]{{1,4}}, // out of bounds error
                new int[,]{{0,2}},

            };


            List<List<int[,]>> allPlays = new List<List<int[,]>> { view.playerOnePlays, view.playerTwoPlays };

            AssignCellsWithErrors(view, allPlays, presenter);

            view.playerOnePlays.RemoveAt(INDEX_OF_INPUT_ERRORS);
            view.playerTwoPlays.RemoveAt(INDEX_OF_INPUT_ERRORS);

            int counter = 1;

            foreach (List<int[,]> playerPlays in allPlays)
            {
                foreach (int[,] cell in playerPlays)
                {

                    Assert.True(view.board[cell[0, 0], cell[0, 1]] == counter); // making sure that the correct input cells were populated successfully
                }

                counter++;
            }
        }
    }
}
