using RaidCalcCore.Models;
using System;
using System.Collections.Generic;

namespace RaidCalcCore.Game
{
    public enum GameFlow
    {
        PlayerCommand = 1,
        PlayerAction,
        BossCommand,
        PlayerCommand2,
        PlayerAction2,
        BossAction
    }

    public class Game : IGame
    {
        public int Turn { get; set; }
        public bool IsGameStart { get; set; }

        public Queue<ICommands> CommandQueue = new Queue<ICommands>();

        public void SetCommands()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void StartGame(object Args)
        {
            throw new NotImplementedException();
        }
    }
}
