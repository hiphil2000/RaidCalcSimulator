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

        private Queue<ICommands> CommandQueue = new Queue<ICommands>();
        private List<Player> PlayerList = new List<Player>();
        private Player Boss;

        private void NextTurn()
        {
            Turn++;
        }

        public void SetCommands()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            IsGameStart = true;
            PlayerList.Clear();
            CommandQueue.Clear();
            Boss = null;
            Turn = -1;
            NextTurn();
        }

        public string NextPhase()
        {
            NextTurn();
            return ((GameFlow)Turn).ToString().Replace("2", "");
        }

        public void StartGame(object Args)
        {
            throw new NotImplementedException();
        }
    }
}
