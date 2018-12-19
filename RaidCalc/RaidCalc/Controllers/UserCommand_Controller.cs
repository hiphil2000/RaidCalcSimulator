using RaidCalc.Interfaces;
using RaidCalc.Views;
using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidCalc.Controllers
{
    public class UserCommand_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }
        private bool IsDeleting;
        private bool IsSkillSelecting;

        private List<Player> _PlayerList;
        private Boss _Boss;
        private List<string> _SelectedPlayers;
        private int _PlayerNameCounter;

        public UserCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;

            IsDeleting = false;
            IsSkillSelecting = false;

            _PlayerList = new List<Player>();
            _SelectedPlayers = new List<string>();
            _PlayerNameCounter = 0;

            view.Clear();
        }

        public void AddPlayer()
        {
            UserCommand_View view = View as UserCommand_View;
            Player player = new Player($"Player{_PlayerNameCounter++}", new Stats(0, 0, 0), 0, 0, 1, -1, -1);
            _PlayerList.Add(player);
            view.AddPlayer(player);
            view.PlayerCounter = _PlayerList.Count;
        }

        public void AddPlayers(List<Player> players)
        {
            UserCommand_View view = View as UserCommand_View;
            _PlayerList = players;
            foreach (Player player in _PlayerList)
            {
                view.AddPlayer(player);
            }
            view.PlayerCounter = _PlayerList.Count;
        }

        public void Delete()
        {
            UserCommand_View view = View as UserCommand_View;
            if (IsDeleting == true)
            {
                var names = " ";
                List<Player> players = new List<Player>();
                foreach (string name in _SelectedPlayers)
                {
                    players.Add(_PlayerList.First(x => x.Name.Equals(name)));
                    names += name + ", ";
                }
                names = names.Equals(" ") ? "선택 없음" : names;
                if (MessageBox.Show($"선택한 플레이어들을 삭제하시겠습니까?\r\n[{names}]","삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    view.DeletePlayers(_SelectedPlayers);
                    foreach (Player p in players)
                    {
                        _PlayerList.Remove(p);
                    }

                }
            }
            IsDeleting = !IsDeleting;
            view.IsPlayerEditing = IsDeleting;
            view.PlayerCounter = _PlayerList.Count;
            _SelectedPlayers.Clear();
        }

        public void PlayerClicked(string name)
        {
            UserCommand_View view = View as UserCommand_View;
            if (IsSkillSelecting == true)
            {
                if (_SelectedPlayers.Count < 1)
                {
                    _SelectedPlayers.Add(name);
                }
                else
                {
                    var skillList = view.GetSelectedSkills();
                    string skills = " ";
                    foreach (ISkillBase sname in skillList)
                    {
                        skills += sname.Name + ", ";
                    }
                    if (MessageBox.Show($"{_SelectedPlayers[0]}의 스킬을 확정하시겠습니까?\r\n[{skills}]",
                        "확정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SetPlayerSkill(view.GetSelectedSkills());
                        view.ClearSkillSelection();
                        if (_SelectedPlayers.Contains(name) == true)
                        {
                            view.ClearPlayerSelection("");
                            _SelectedPlayers.Clear();
                        }
                        else
                        {
                            view.ClearPlayerSelection(name);
                            _SelectedPlayers.Clear();
                            _SelectedPlayers.Add(name);
                        }
                    }
                }
                if (_SelectedPlayers.Count > 0)
                    HighlightSkills();
            }
            else if (IsDeleting == true)
            {
                if (_SelectedPlayers.Contains(name) == false)
                {
                    _SelectedPlayers.Add(name);
                }
            }
        }

        private void HighlightSkills()
        {
            UserCommand_View view = View as UserCommand_View;
            Player player = _PlayerList.First(x => x.Name.Equals(_SelectedPlayers[0]));
            view.HighlightSkills(player.CommonSkills);
        }

        public void SetSkillList()
        {
            UserCommand_View view = View as UserCommand_View;
            if (IsSkillSelecting == true)
            {
                var skillList = view.GetSelectedSkills();
                string skills = " ";
                foreach (ISkillBase sname in skillList)
                {
                    skills += sname.Name + ", ";
                }
                if (_SelectedPlayers.Count > 0)
                if (MessageBox.Show($"{_SelectedPlayers[0]}의 스킬을 확정하시겠습니까?\r\n[{skills}]",
                        "확정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SetPlayerSkill(view.GetSelectedSkills());
            }
            IsSkillSelecting = !IsSkillSelecting;
            view.IsSkillEditing = IsSkillSelecting;
            _SelectedPlayers.Clear();
        }

        private void SetPlayerSkill(List<ISkillBase> skills)
        {
            if (_SelectedPlayers.Count > 0)
            {
                Player player = _PlayerList.First(x => x.Name.Equals(_SelectedPlayers[0]));
                player.CommonSkills.Clear();
                foreach (ISkillBase skill in skills)
                {
                    if (player.CommonSkills.Contains(skill) == false)
                    {
                        player.CommonSkills.Add(skill);
                    }
                }
            }
        }

        public void LoadSkillList()
        {
            UserCommand_View view = View as UserCommand_View;
            var skillList = MainFrame.GetSkillList();
            view.InitSkillset(skillList);
        }

        public bool NextPage()
        {
            if (Validation())
            {
                MainFrame.SetPlayerList(_PlayerList);
                MainFrame.SetBoss(_Boss);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Validation()
        {
            bool isValidated = false;
            SyncronizeData();
            foreach (Player player in _PlayerList)
            {
                if (player.MaxHp < player.CurrentHp)
                {
                    MessageBox.Show($"올바르지 않은 HP값입니다. ({player.Name})");
                    return false;
                }
                if (player.Stat.Stat1 < 0 || player.Stat.Stat1 > 5 ||
                    player.Stat.Stat2 < 0 || player.Stat.Stat2 > 5 ||
                    player.Stat.Stat3 < 0 || player.Stat.Stat3 > 5)
                {
                    MessageBox.Show($"올바르지 않은 스탯입니다. ({player.Name})");
                    return false;
                }
                if (player.CommonSkills.Count < 1)
                {
                    MessageBox.Show($"스킬이 지정되지 않았습니다. ({player.Name})");
                    return false;
                }
                isValidated = true;
            }
            if (_PlayerList.Count < 1)
            {
                MessageBox.Show($"플레이어가 너무 적습니다. ({_PlayerList.Count}명)"); 
                return false;
            }
            return isValidated;
        }

        private void SyncronizeData()
        {
            UserCommand_View view = View as UserCommand_View;
            foreach (PlayerItem pitem in view.PlayerItems)
            {
                Player player = _PlayerList.First(x => x.Name.Equals(pitem.Name));
                player.Name = pitem.Player_Name;
                player.MaxHp = pitem.Player_MaxHealth;
                player.CurrentHp = pitem.Player_CurrentHealth;
                player.Stat = new Stats(pitem.Player_Stat1, pitem.Player_Stat2, pitem.Player_Stat3);
            }
            PlayerItem bossItem = (PlayerItem)view.Controls["BossItem"];
            _Boss = new Boss();
            _Boss.Name = bossItem.Player_Name;
            _Boss.CurrentHp = bossItem.Player_CurrentHealth;
            _Boss.MaxHp = bossItem.Player_MaxHealth;
            _Boss.PosX = -1;
            _Boss.PosY = -1;

        }

        public void InitData()
        {
            AddPlayers(MainFrame.GetPlayerList());
            LoadSkillList();
        }
    }
}
