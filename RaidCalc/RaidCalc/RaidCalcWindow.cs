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
        private List<ISkillBase> _SkillList;

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
            return _SkillList;
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
                _SkillList = Game.GetSkills();
                ChangeView("UserCommand");
            }
        }

        public void Exit()
        {
            if (MessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        public void SetPlayerList(List<Player> players)
        {
            Game.SetPlayerList(players);
        }

        public List<Player> GetPlayerList()
        {
            return Game.GetPlayerList();
        }

        #region Event Handlers
        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (_CurrentPage.Controller.NextPage())
            {
                ChangeView(Game.NextPhase());
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
        }
        #endregion
    }
}
