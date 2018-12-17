using RaidCalc.Controllers;
using RaidCalc.Interfaces;
using RaidCalc.Views;
using RaidCalcCore.Game;
using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidCalc
{
    public struct ViewController
    {
        public IView View;
        public IController Controller;

        public ViewController(IView view, IController controller)
        {
            View = view;
            Controller = controller;
        }
    }

    public partial class RaidCalcWindow : Form
    {
        Dictionary<string, ViewController> Dic_ViewController;  // View와 Controller의 목록을 정의한 Dictionary
        Game Game;
        private Dictionary<string, ISkillBase> _SkillList;

        private ViewController _CurrentPage;

        public RaidCalcWindow()
        {
            InitializeComponent();
            InitializeViewController();
            ChangeView("Index");
            Game = new Game();
        }

        private void InitializeViewController()
        {
            IView view;
            IController controller;
            Dic_ViewController = new Dictionary<string, ViewController>();

            // Index
            view = new Index_View();
            controller = new Index_Controller(this, view);
            view.SetController(controller);
            Dic_ViewController.Add(view.ViewName, new ViewController(view, controller));

            // UserCommand
            view = new UserCommand_View();
            controller = new UserCommand_Controller(this, view);
            view.SetController(controller);
            Dic_ViewController.Add(view.ViewName, new ViewController(view, controller));

            // PlayerCommand
            view = new PlayerCommand_View();
            controller = new PlayerCommand_Controller(this, view);
            view.SetController(controller);
            Dic_ViewController.Add(view.ViewName, new ViewController(view, controller));

            // BossCommand
            view = new BossCommand_View();
            controller = new BossCommand_Controller(this, view);
            view.SetController(controller);
            Dic_ViewController.Add(view.ViewName, new ViewController(view, controller));

            // BossAction
            view = new BossAction_View();
            controller = new BossAction_Controller(this, view);
            view.SetController(controller);
            Dic_ViewController.Add(view.ViewName, new ViewController(view, controller));
        }

        public void ChangeView(string viewName)
        {
            // 현재 페이지 변경
            _CurrentPage = Dic_ViewController[viewName];
            _CurrentPage.View.Clear();

            // 메인프레임 비우고 현재 페이지로 교체
            Panel_MainFrame.Controls.Clear();
            Panel_MainFrame.Controls.Add(_CurrentPage.View as Control);

            // 메인 타이틀 변경
            Lab_Title.Text = _CurrentPage.View.ViewName;

            // 현재 윈도우의 크기를 페이지 크기에 맞게 변경
            Panel_MainFrame.Size = (_CurrentPage.View as Control).Size;

            // 데이터 초기화
            _CurrentPage.Controller.InitData();
        }

        public List<ISkillBase> GetSkillList()
        {
            List<ISkillBase> skills = new List<ISkillBase>();
            foreach (var item in _SkillList.Values)
            {
                skills.Add(item);
            }
            return skills;
        }

        public ISkillBase GetSkillByName(string name)
        {
            return _SkillList[name];
        }

        private void RaidCalc_Load(object sender, EventArgs e)
        {

        }

        public void StartGame()
        {
            if (Game.IsGameStart)
                MessageBox.Show("이미 실행중입니다.", "에러");
            else
            {
                MessageBox.Show("게임을 시작합니다.", "알림");
                Game.StartGame();
                Button_Log.Enabled = true;
                _SkillList = Game.GetSkills();
                ChangeView("UserCommand");
            }
        }

        public void SetPlayerList(List<Player> players)
        {
            Game.SetPlayerList(players);
            foreach (Player p in players)
            {
                string msg = $"[{p.Name}](이)가 로드됨. {{\"Name\": \"{p.Name}\", \"Stat\": \"{p.Stat.ToString()}\", \"HP\": \"{p.CurrentHp}/{p.MaxHp}\", \"CommonSkills\": [";
                foreach (ISkillBase skill in p.CommonSkills)
                {
                    msg += $"\"{skill.Name}\", ";
                }
                msg = msg.Substring(0, msg.Length - 1);
                msg += "]}";
                Game.WriteLog(msg);
            }
        }

        public void SetBoss(Player boss)
        {
            Game.SetBoss(boss);
            string msg = $"[<Boss>{boss.Name}](이)가 로드됨. {{\"Name\": \"{boss.Name}\", \"HP\": \"{boss.CurrentHp}/{boss.MaxHp}\", \"CommonSkills\": [";
            foreach (ISkillBase skill in boss.CommonSkills)
            {
                msg += $"\"{skill.Name}\", ";
            }
            msg = msg.Substring(0, msg.Length - 2);
            msg += "]}";
            Game.WriteLog(msg);
        }

        public Player GetBoss()
        {
            return Game.GetBoss();
        }

        public List<Player> GetPlayerList()
        {
            return Game.GetPlayerList();
        }

        public void SetQueue(List<ICommands> commands)
        {
            Game.SetCommandQueue(commands);
        }

        private void ExecuteQueue()
        {
            Game.ExecuteCommandQueue();
        }
        public void SetBossQueue(List<ICommands> commands)
        {
            Game.SetBossCommandQueue(commands);
        }

        private void ExecuteBossQueue()
        {
            Game.ExecuteBossCommandQueue();
        }

        public void Exit()
        {
            if (MessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void WriteLog(string msg)
        {
            Game.WriteLog(msg);
        }

        public string PrintLog()
        {
            return Game.PrintLog();
        }

        #region Event Handlers
        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (_CurrentPage.Controller.NextPage())
            {
                if (Game.Turn == 2)
                {
                    ExecuteBossQueue();
                }
                var phaseText = Game.NextPhase();
                if (phaseText.Equals("PlayerAction"))
                {
                    ExecuteQueue();
                    ChangeView(Game.NextPhase());
                }
                else if(phaseText.Equals("BossAction"))
                {
                    ExecuteBossQueue();
                    ChangeView(Game.NextPhase());
                }
                else
                {
                    ChangeView(phaseText);
                }
            }
        }

        private void Button_Previous_Click(object sender, EventArgs e)
        {
            ChangeView(Game.PreviousPhase());
        }

        private void Panel_MainFrame_Resize(object sender, EventArgs e)
        {
            Flow_ButtonBox.Location = new Point(Panel_MainFrame.Width + 12 - Flow_ButtonBox.Width,
                Panel_MainFrame.Location.Y + Panel_MainFrame.Height + 6);
            Height = Panel_MainFrame.Height + 155;
            Width = Panel_MainFrame.Width + 40;
            Flow_ToolBox.Location = new Point(Flow_ToolBox.Location.X, Flow_ButtonBox.Location.Y);
        }

        private void Button_Log_Click(object sender, EventArgs e)
        {
            var LogWindow = new RaidCalcLogWindow(this);
            LogWindow.ShowDialog();
        }
        #endregion

    }
}
