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
        Dictionary<string, ViewController> Dic_ViewController;
        Game Game;
        private List<ISkillBase> _SkillList;

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
            ViewController vc = Dic_ViewController[viewName];
            (vc.View as Control).Location = new Point(0, 0);
            Panel_MainFrame.Controls.Clear();
            Panel_MainFrame.Controls.Add(vc.View as Control);
            Lab_Title.Text = vc.View.ViewName;
            Panel_MainFrame.Size = (vc.View as Control).Size;
        }

        public List<ISkillBase> GetSkillList()
        {
            return _SkillList;
        }

        private void RaidCalc_Load(object sender, EventArgs e)
        {

        }

        public void Exit()
        {
            if (MessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void Button_Next_Click(object sender, EventArgs e)
        {
            ChangeView(Game.NextPhase());
        }

        private void Panel_MainFrame_Resize(object sender, EventArgs e)
        {
            Flow_ButtonBox.Location = new Point(Panel_MainFrame.Width + 12 - Flow_ButtonBox.Width,
                Panel_MainFrame.Location.Y + Panel_MainFrame.Height + 6);
            Height = Panel_MainFrame.Height + 155;
            Width = Panel_MainFrame.Width + 40;
        }
    }
}
