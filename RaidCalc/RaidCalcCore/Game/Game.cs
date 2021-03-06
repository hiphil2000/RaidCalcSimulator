﻿using Newtonsoft.Json.Linq;
using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

namespace RaidCalcCore.Game
{
    public enum GameFlow
    {
        UserCommand = -1,
        PlayerCommand = 0,
        PlayerAction,
        BossCommand,
        PlayerCommand2,
        PlayerAction2,
        BossAction
    }

    public class Game : IGame
    {
        public int Turn { get; set; }
        public int ExacTurn { get; set; }
        public bool IsGameStart { get; set; }

        private Queue<ICommands> CommandQueue;
        private Queue<ICommands> BossCommandQueue;
        private List<Player> PlayerList;
        private Dictionary<string, Boss> BossDictionary;
        private Dictionary<string, ISkillBase> SkillList;
        private Dictionary<string, ISkillBase> BossSkillList;
        private Boss Boss;
        private List<Player> MobList;

        private string LogBase;
        private string LogBuffer;

        #region Constructor
        public Game()
        {
            BossCommandQueue = new Queue<ICommands>();
            CommandQueue = new Queue<ICommands>();
            PlayerList = new List<Player>();
            SkillList = new Dictionary<string, ISkillBase>();
            BossDictionary = new Dictionary<string, Boss>();
            MobList = new List<Player>();
            BossSkillList = new Dictionary<string, ISkillBase>();
        }
        #endregion

        #region Initialization
        public void SetPlayerList(List<Player> players)
        {
            PlayerList = players;
        }
        #endregion

        #region DataLoad
        public void InitializeSkillset()
        {
            #region ------------------BasicSkills--------------------
            BasicSkill bs;
            // 이동
            bs = new BasicSkill() { Name = "이동", Cooltime = 5, ForceConst = -1, RangeType = "Point", RangeConst = null, Type = SkillType.Basic, UsedTurn = -999, Description = "마스레이드에서 이동 제한을 받지 않고, 원하는 마스로 이동할 수 있습니다." };
            bs.SetFunction((user, victim, obj) => {
                var p = ((Point)obj);
                user.PosX = p.X;
                user.PosY = p.Y;
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 자가회복
            bs = new BasicSkill() { Name = "자가회복", Cooltime = 6, ForceConst = 0.2, RangeType = "Ellipse", RangeConst = "3", Type = SkillType.Basic | SkillType.Heal, UsedTurn = -999, Description = "자신의 최대 체력의 20%만큼을 즉시 회복합니다." };
            bs.SetFunction((user, victim, obj) => {
                var inner = SkillList["자가회복"];
                double amountOfHeal = user.MaxHp * inner.ForceConst;
                user.CurrentHp = user.CurrentHp + amountOfHeal >= user.MaxHp ? user.MaxHp : user.CurrentHp + amountOfHeal;
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 연속공격
            bs = new BasicSkill() { Name = "연속공격", Cooltime = 6, ForceConst = 2, RangeType = "Rectangle", RangeConst = "3,3:1,2", Type = SkillType.Basic | SkillType.Offence, UsedTurn = -999, Description = "다음 턴에 사용하는 스킬이 2회 적용됩니다." };
            bs.SetFunction((user, victim, obj) => {
                ISkillBase skill = obj as ISkillBase;
                BuffBase buff = new BuffBase(user, BuffType.Buff, 1, 1, 1);
                buff.SetSkillFunction(skill.SkillFunction);
                user.Buffs.Add(buff);
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 위력 증가
            bs = new BasicSkill() { Name = "위력 증가", Cooltime = 10, ForceConst = 3, RangeType = "Player", RangeConst = "Self", Type = SkillType.Basic | SkillType.Offence, UsedTurn = -999, Description = "시전 턴을 포함하여 3턴 간 위력이 3 증가합니다." };
            bs.SetFunction((user, victim, obj) => {
                var inner = SkillList["위력 증가"];
                user.GiveConst += inner.ForceConst;
                BuffBase buff = new BuffBase(user, BuffType.Buff, 3, 3, inner.ForceConst);
                buff.SetSkillFunction((IPlayer src, IPlayer dst, object buffObj) => {
                    src.GiveConst = src.GiveConst - inner.ForceConst < 0 ? 0 : src.GiveConst - inner.ForceConst;
                    return true;
                });
                user.Buffs.Add(buff);
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 방어력 증가
            bs = new BasicSkill() { Name = "방어력 증가", Cooltime = 10, ForceConst = 3, RangeType = "Player", RangeConst = "Self", Type = SkillType.Basic | SkillType.Defence, UsedTurn = -999, Description = "시전 턴을 포함하여 3턴 간 방어력이 3 증가합니다." };
            bs.SetFunction((user, victim, obj) => {
                var inner = SkillList["방어력 증가"];
                user.HarmConst += inner.ForceConst;
                BuffBase buff = new BuffBase(user, BuffType.Buff, 1, 1, inner.ForceConst);
                buff.SetSkillFunction((IPlayer src, IPlayer dst, object buffObj) => {
                    src.HarmConst = src.HarmConst - inner.ForceConst < 0 ? 0 : src.HarmConst - inner.ForceConst;
                    return true;
                });
                user.Buffs.Add(buff);
                return true;
            });
            SkillList.Add(bs.Name, bs);
            // 도발
            bs = new BasicSkill() { Name = "도발", Cooltime = 4, ForceConst = -1, RangeType = "Player", RangeConst = "Select", Type = SkillType.Basic | SkillType.Defence, UsedTurn = -999, Description = "대상의 어그로를 사용자 자신에게 향하도록 합니다. 다른 사람이 도발을 사용하거나, 자신이 사망하기 전까지 어그로는 자신에게 향하도록 유지됩니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 주의 분산
            bs = new BasicSkill() { Name = "주의 분산", Cooltime = 4, ForceConst = -1, RangeType = "Player", RangeConst = "Select", Type = SkillType.Basic | SkillType.Defence, UsedTurn = -999, Description = "자신의 어그로를 대상자에게 즉시 부여합니다. 같은 턴에 여러 사람이 도발을 사용한 경우, 기피를 통해 어그로를 획득한 대상이 1순위 어그로를 획득하게 됩니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 흡혈
            bs = new BasicSkill() { Name = "흡혈", Cooltime = -1, ForceConst = 3, RangeType = "Player", RangeConst = "Self", Type = SkillType.Basic | SkillType.Offence, UsedTurn = -999, Description = "DoT로 입힌 피해만큼 체력을 회복합니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            // 전염
            bs = new BasicSkill() { Name = "전염", Cooltime = -1, ForceConst = -1, RangeType = "Player", RangeConst = "Self", Type = SkillType.Basic | SkillType.Offence | SkillType.Heal, UsedTurn = -999, Description = "DoT 및 HoT시전 시, 지정 대상 기준 범위 내의 다수 대상으로 확장합니다. 범위는 '공격범위' 스탯의 영향을 받습니다." };
            bs.SetFunction((user, victim, obj) => {
                throw new NotImplementedException();
            });
            SkillList.Add(bs.Name, bs);
            #endregion  // ------------------BasicSkills----------------------
            #region 
            // 일반 공격
            bs = new BasicSkill() { Name = "일반 공격", Cooltime = 0, ForceConst = 80, RangeType = "Point", RangeConst = null, Type = SkillType.Offence, UsedTurn = -999, Description = "단일 대상에게 시전하는 일반 공격입니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 강공격
            bs = new BasicSkill() { Name = "강공격", Cooltime = 4, ForceConst = 200, RangeType = "Point", RangeConst = null, Type = SkillType.Offence, UsedTurn = -999, Description = "단일 대상에게 시전하는 강한 공격입니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 분산공격
            bs = new BasicSkill() { Name = "분산공격", Cooltime = 1, ForceConst = 50, RangeType = "Ellipse", RangeConst = "3", Type = SkillType.Offence, UsedTurn = -999, Description = "범위 내 다수 대상에게 시전하는 공격입니다. 범위는 '공격범위' 스탯의 영향을 받습니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // DoT
            bs = new BasicSkill() { Name = "DoT", Cooltime = 2, ForceConst = 40, RangeType = "Player", RangeConst = "Select", Type = SkillType.Offence | SkillType.OffenceTick, UsedTurn = -999, Description = "단일 대상에게 시전 직후부터 3턴 간 데미지를 입힙니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 공격력 증가
            bs = new BasicSkill() { Name = "공격력 증가", Cooltime = 6, ForceConst = 3, RangeType = "Player", RangeConst = "Self", Type = SkillType.Offence, UsedTurn = -999, Description = "시전 턴을 포함하여 4턴 간 위력과 받는 피해량이 증가합니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 접근
            bs = new BasicSkill() { Name = "접근", Cooltime = 3, ForceConst = 50, RangeType = "Point", RangeConst = null, Type = SkillType.Offence, UsedTurn = -999, Description = "대상으로부터 10마스 이내의 거리에 있을 경우, 대상에게 바로 접근하며 공격을 가합니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 후퇴
            bs = new BasicSkill() { Name = "후퇴", Cooltime = 3, ForceConst = 50, RangeType = "Point", RangeConst = null, Type = SkillType.Offence, UsedTurn = -999, Description = "대상의 위치와 현재 위치를 기준으로 하여 직선거리로 10마스만큼 뒤로 이동합니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 단일대상-궁극기
            bs = new BasicSkill() { Name = "단일대상-궁극기", Cooltime = 999, ForceConst = 800, RangeType = "Player", RangeConst = "Select", Type = SkillType.Offence | SkillType.Ultimate, UsedTurn = -999, Description = "단일 대상에 대한 가장 강력한 공격을 가합니다. 해당 스킬은 전투 중 1회만 사용 가능하며, 사용 직후 2턴 간 커맨드 입력이 불가능해집니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);

            // 다수대상-궁극기
            bs = new BasicSkill() { Name = "다수대상-궁극기", Cooltime = 999, ForceConst = 400, RangeType = "Ellipse", RangeConst = "3", Type = SkillType.Offence | SkillType.Ultimate, UsedTurn = -999, Description = "다수 대상에 대한 가장 강력한 공격을 가합니다. 해당 스킬은 전투 중 1회만 사용 가능하며, 사용 직후 2턴 간 커맨드 입력이 불가능해집니다." };
            bs.SetFunction((user, victim, obj) => {
                return true;
            });
            SkillList.Add(bs.Name, bs);
            #endregion  // ------------------Attack Skills--------------------
            #region ------------------Boss Skills--------------------
            #region 승리

            #endregion
            #endregion
        }

        public ValueTuple<string, string> LoadSetting(string settingJsonRaw)
        {
            JObject setting = JObject.Parse(settingJsonRaw.Replace("\\", "\\\\"));
            string dataPath = setting["GameDataFile"].ToString();
            string savePath = setting["LogStartPath"].ToString();
            return (dataPath, savePath);
        }

        public string SetDatas(string gameData)
        {
            return LoadCustomBossData(gameData);
        }

        public string LoadCustomBossData(string data)
        {
            BossDictionary.Clear();
            JObject BossData = null;
            BossData = JObject.Parse(data);
            JArray BossArr = JArray.Parse(BossData["Boss"].ToString());
            string msg = $"게임 데이터 파일 로드 완료. 현재 로드된 보스: [ "; 
            foreach (var item in BossArr)
            {
                List<BossSkillBase> skills = new List<BossSkillBase>();
                List<TimeLine> timeLines = new List<TimeLine>();

                string Type = item["Type"].ToString();
                string Name = item["Name"].ToString();
                string[] Description = JArray.Parse(item["Description"].ToString()).ToObject<string[]>();
                double MaxHP = item["MaxHp"].ToObject<double>();
                double MobHP = item["MobHp"].ToObject<double>();
                string SkillUpgradeKeyword = item["SkillUpgradeKeyword"].ToString();
                foreach (var skill in JArray.Parse(item["Skills"].ToString()))
                {
                    string SkillName = skill["SkillName"].ToString();
                    string SkillConst = skill["SkillConst"].ToString();
                    string SkillType = skill["SkillType"].ToString();
                    string SkillRangeType = skill["SkillRangeType"].ToString();
                    string SkillRangeConst = skill["SkillRangeConst"].ToString();
                    string SkillDescription = skill["SkillDescription"].ToString();
                    string SkillScript = skill["SkillScript"].ToString();
                    skills.Add(GenerateSkill(new BossSkillBase(SkillName, SkillConst, (SkillType)Enum.Parse(typeof(SkillType), SkillType), SkillRangeType, SkillRangeConst, SkillDescription, SkillScript, 0)));
                }

                foreach (var timeline in JArray.Parse(item["TimeLine"].ToString()))
                {
                    string Command = timeline["Command"].ToString();
                    string Action = timeline["Action"].ToString();
                    timeLines.Add(new TimeLine(Command, Action));
                }
                var bossitem = new Boss(Name, Type, Description, MaxHP, MobHP, SkillUpgradeKeyword, skills, timeLines);
                BossDictionary.Add(Name, bossitem);
                msg += Name + ", ";
            }
            msg = msg.Substring(0, msg.Length - 2) + " ]";
            WriteSystemLog(msg);
            return msg;
        }

        private BossSkillBase GenerateSkill(BossSkillBase skill)
        {
            string skillExp = skill.SkillConst;

            if (skill.Type.HasFlag(SkillType.Offence))
            {
                skill.SkillFunction = (IPlayer boss, IPlayer player, object obj) =>
                {
                    Boss bs = boss as Boss;
                    Player py = player as Player;
                    double damage = ((double)ComputeSkillConst(skillExp, SkillType.Offence)) * py.HarmConst;
                    py.CurrentHp = py.CurrentHp - damage <= 0 ? 0 : py.CurrentHp - damage;
                    return true;
                };
            }
            else if (skill.Type.HasFlag(SkillType.MobAdd))
            {
                skill.SkillFunction = (IPlayer boss, IPlayer player, object obj) =>
                {
                    Boss bs = boss as Boss;
                    double MobHp = bs.MobHp;
                    int count = int.Parse(skillExp);
                    Random r = new Random();
                    var MobSkill = new BasicSkill() { Name = "일반 공격", Cooltime = 0, ForceConst = 300, RangeType = "", RangeConst = "", Type = SkillType.Offence, UsedTurn = -999, Description = "일반 공격" };
                    MobSkill.SetFunction((user, victim, scobj) => {
                        victim.CurrentHp = victim.CurrentHp - (300 * victim.HarmConst) <= 0 ? 0 : victim.CurrentHp - (300 * victim.HarmConst);
                        return true;
                    });
                    for (int i = 0; i < count; i++)
                    {
                        var mob = new Player("Mob" + i, new Stats(), MobHp, MobHp, 1, r.Next(20), r.Next(20));
                        mob.CommonSkills.Add(MobSkill);
                        MobList.Add(mob);
                    }
                    return true;
                };
            }
            else if (skill.Type.HasFlag(SkillType.Defence))
            {
                skill.SkillFunction = (IPlayer boss, IPlayer player, object obj) =>
                {
                    double skillConst = (double)ComputeSkillConst(skillExp, SkillType.Defence);
                    boss.HarmConst = boss.HarmConst - (boss.HarmConst * skillConst) < 0 ? 0 : boss.HarmConst - (boss.HarmConst * skillConst);
                    return true;
                };
            }
            else if (skill.Type.HasFlag(SkillType.OffenceTick))
            {
                //var consts = (ValueTuple<double, int>)ComputeSkillConst(skillExp, SkillType.OffenceTick);
                //double skillConst = consts.Item1;
                //int duration = consts.Item2;
                //skill.SkillFunction = (IPlayer boss, IPlayer player, object obj) =>
                //{
                //    Boss bs = boss as Boss;
                //    Player py = player as Player;
                //    BuffBase buffBase = new BuffBase(boss, duration, duration, skillConst);
                //    buffBase.SkillFunction = (Player source, Player dst) =>
                //    {
                //        dst.CurrentHp = dst.CurrentHp - (skillConst * dst.HarmConst) <= 0 ? 0 : dst.CurrentHp - (skillConst * dst.HarmConst);
                //        return true;
                //    };
                //    py.Buffs.Add(buffBase);
                //    return true;
                //};
            }
            return skill;
        }

        private object ComputeSkillConst(string exp, SkillType skillType)
        {
            int MobCnt = MobList.Count;
            string expRep = exp.Replace("MobCnt", MobCnt.ToString());
            object result;

            if (skillType.ToString().Contains("Tick"))
            {
                var expSplit = exp.Split('-');
                double sc = double.Parse(expSplit[0]);
                int dur = int.Parse(expSplit[1]);
                result = (sc, dur);
            }
            else
            {
                result = new DataTable().Compute(expRep, null);
            }
            return result;
        }
        #endregion

        #region Game Flow Control
        public void StartGame()
        {
            IsGameStart = true;
            PlayerList.Clear();
            CommandQueue.Clear();
            Boss = null;
            Turn = -2;
            ExacTurn = -1;
            SkillList = new Dictionary<string, ISkillBase>();
            LogBase = $"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}] 게임 시작." + Environment.NewLine;
            InitializeSkillset();
            NextTurn();
        }

        public void SetCommandQueue(List<ICommands> commands)
        {
            foreach (var item in commands)
            {
                CommandQueue.Enqueue(item);
            }
        }
        public void SetBossCommandQueue(List<ICommands> commands)
        {
            foreach (var item in commands)
            {
                BossCommandQueue.Enqueue(item);
            }
        }

        public void ExecuteCommandQueue()
        {
            while (CommandQueue.Count > 0)
            {
                var command = CommandQueue.Dequeue();

                var sourcePlayer = command.SourcePlayer.Name;
                var destPlayer = command.DestinationPlayer == null ? "자신 혹은 대상 없음" : command.DestinationPlayer.Name;
                var skillName = command.UsedSkill.Name;
                string message = $"[{sourcePlayer}] (이)가 [{destPlayer}] 에게 [{skillName}] (을)를 사용.";
                Command com = command as Command;
                com.Execute(ExacTurn);
                Console.WriteLine(message);
                WriteLog(message);
            }
        }

        public void ExecuteBossCommandQueue()
        {
            while (BossCommandQueue.Count > 0)
            {
                var command = BossCommandQueue.Dequeue();

                var sourcePlayer = command.SourcePlayer.Name;
                var destPlayer = command.DestinationPlayer == null ? "자신 혹은 대상 없음" : command.DestinationPlayer.Name;
                var skillName = command.UsedSkill.Name;
                string message = $"[<Boss>{sourcePlayer}] (이)가 [{destPlayer}] 에게 [{skillName}] (을)를 사용.";
                Command com = command as Command;
                com.Execute(ExacTurn);
                Boss.Copy(command.SourcePlayer);
                Console.WriteLine(message);
                WriteLog(message);
            }
        }

        public void StartGame(object Args)
        {
            throw new NotImplementedException();
        }
        private void NextTurn()
        {
            Turn++;
            ExacTurn++;
        }
        private void PreviousTurn()
        {
            Turn--;
        }
        public string NextPhase()
        {
            NextTurn();
            var pageName = ((GameFlow)(Turn % 6)).ToString();
            return pageName.Replace("2", "");
        }
        public string PreviousPhase()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region getter setter
        public List<Player> GetPlayerList()
        {
            return PlayerList;
        }
        public Dictionary<string, ISkillBase> GetSkills()
        {
            return SkillList;
        }

        public Dictionary<string, ISkillBase> BossGetSkills()
        {
            return BossSkillList;
        }

        public void SetBoss(Boss boss)
        {
            Boss = boss;
        }

        public Boss GetBoss()
        {
            return Boss;
        }

        public Boss GetBossByName(string name)
        {
            return BossDictionary[name];
        }

        public Dictionary<string, Boss> GetBossDict()
        {
            return BossDictionary;
        }
        #endregion

        #region Utils
        #region Logs
        public string PrintLog()
        {
            FlushLog();
            return LogBase.ToString();
        }

        public string PrintLogBuffer()
        {
            return LogBuffer;
        }

        public void WriteLog(string message)
        {
            string log = $"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}][Turn {ExacTurn} : {((GameFlow)(Turn % 6)).ToString().Replace("2", "")}] " + message;
            LogBuffer += log + Environment.NewLine;
            Console.WriteLine(log);
        }

        public void WriteSystemLog(string message)
        {
            string log = $"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}][SYSTEM] " + message;
            LogBuffer += log + Environment.NewLine;
            Console.WriteLine(log);
        }
        
        public void FlushLog()
        {
            LogBase += LogBuffer;
            LogBuffer = "";
        }
        #endregion
        #endregion

        public void SetCommands()
        {
            throw new NotImplementedException();
        }



        




    }
}

