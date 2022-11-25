using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToePractice
{
    public interface ViewInterface
    {
        void GameWon(int player);

        void GameTied();

        string GetPlayerOneSymbol();
        string GetPlayerTwoSymbol();
        void PlayerTurn(int player);

        int[,] GetUserInput();

        void DrawBoard();

        void AdvanceRound(int roundNumber);

        void PlacePlayer(int[,] position, string playerSymbol);

        void ShowError(string error);

        void Refresh();
    }
}
