using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Game
{
    public interface IGame
    {
        bool IsGameStart { get; set; }
        int Turn { get; set; }

        void StartGame();
        void StartGame(object Args);
        void SetCommands();

    }
}
