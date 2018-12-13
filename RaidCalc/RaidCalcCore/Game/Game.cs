using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
        private Dictionary<string, ISkillBase> SkillList;
        private Player Boss;

        private StringBuilder LogBuilder;

        private void NextTurn()
        {
            Turn++;
        }

        private void PreviousTurn()
        {
            Turn--;
        }

        public void SetPlayerList(List<Player> players)
        {
            PlayerList = players;
        }

        public List<Player> GetPlayerList()
        {
            return PlayerList;
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
            SkillList = new Dictionary<string, ISkillBase>();
            LogBuilder = new StringBuilder($"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}] 게임 시작.");
            LogBuilder.AppendLine();
            InitializeSkillset();
            NextTurn();
        }

        public string NextPhase()
        {
            NextTurn();
            var pageName = ((GameFlow)Turn).ToString();
            if (pageName.Equals("PlayerAction"))
                return "BossCommand";
            else if (pageName.Equals("PlayerAction2"))
                return "BossAction";
            else
                return pageName.Replace("2", "");
        }

        public void InitializeSkillset()
        {
            #region ------------------BasicSkills--------------------
            BasicSkill bs;
            // 이동
            bs = new BasicSkill() { Name = "이동", Cooltime = 5, ForceConst = -1, Type = SkillType.Basic, UsedTurn = -999, Description= "마스레이드에서 이동 제한을 받지 않고, 원하는 마스로 이동할 수 있습니다." };
            bs.SetFunction((user, victim, obj) => {
                var p = ((Point)obj);
                user.PosX = p.X;
                user.PosY = p.Y;
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 자가회복
            bs = new BasicSkill() { Name = "자가회복", Cooltime = 6, ForceConst = 0.2, Type = SkillType.Basic | SkillType.Heal, UsedTurn = -999, Description= "자신의 최대 체력의 20%만큼을 즉시 회복합니다." };
            bs.SetFunction((user, victim, obj) => {
                double amountOfHeal = user.MaxHp * bs.ForceConst;
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 연속공격
            bs = new BasicSkill() { Name = "연속공격", Cooltime = 6, ForceConst = 2, Type = SkillType.Basic | SkillType.Offence, UsedTurn = -999, Description= "다음 턴에 사용하는 스킬이 2회 적용됩니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 방어력 증가
            bs = new BasicSkill() { Name = "위력 증가", Cooltime = 10, ForceConst = 3, Type = SkillType.Basic | SkillType.Offence, UsedTurn = -999, Description = "시전 턴을 포함하여 3턴 간 위력이 3 증가합니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 방어력 증가
            bs = new BasicSkill() { Name = "방어력 증가", Cooltime = 10, ForceConst = 3, Type = SkillType.Basic | SkillType.Defence, UsedTurn = -999, Description= "시전 턴을 포함하여 3턴 간 방어력이 3 증가합니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 도발
            bs = new BasicSkill() { Name = "도발", Cooltime = 4, ForceConst = -1, Type = SkillType.Basic | SkillType.Defence, UsedTurn = -999, Description= "대상의 어그로를 사용자 자신에게 향하도록 합니다. 다른 사람이 도발을 사용하거나, 자신이 사망하기 전까지 어그로는 자신에게 향하도록 유지됩니다."};
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 주의 분산
            bs = new BasicSkill() { Name = "주의 분산", Cooltime = 4, ForceConst = -1, Type = SkillType.Basic | SkillType.Defence, UsedTurn = -999, Description= "자신의 어그로를 대상자에게 즉시 부여합니다. 같은 턴에 여러 사람이 도발을 사용한 경우, 기피를 통해 어그로를 획득한 대상이 1순위 어그로를 획득하게 됩니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 흡혈
            bs = new BasicSkill() { Name = "흡혈", Cooltime = -1, ForceConst = 3, Type = SkillType.Basic | SkillType.Offence, UsedTurn = -999, Description= "DoT로 입힌 피해만큼 체력을 회복합니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 전염
            bs = new BasicSkill() { Name = "전염", Cooltime = -1, ForceConst = -1, Type = SkillType.Basic | SkillType.Offence | SkillType.Heal, UsedTurn = -999, Description= "DoT 및 HoT시전 시, 지정 대상 기준 범위 내의 다수 대상으로 확장합니다. 범위는 '공격범위' 스탯의 영향을 받습니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            #endregion // ------------------BasicSkills--------------------
        }

        public void WriteLog(string message)
        {
            LogBuilder.AppendLine(message);
        }

        public string PrintLog()
        {
            return LogBuilder.ToString();
        }

        public string PreviousPhase()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, ISkillBase> GetSkills()
        {
            return SkillList;
        }
        public void StartGame(object Args)
        {
            throw new NotImplementedException();
        }
    }
}

