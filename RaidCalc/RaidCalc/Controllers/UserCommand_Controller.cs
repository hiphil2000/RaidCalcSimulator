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
                view.DeletePlayers(_SelectedPlayers);
            }
            IsDeleting = !IsDeleting;
            view.IsPlayerEditing = IsDeleting;
        }

        public void PlayerClicked(string name)
        {
            UserCommand_View view = View as UserCommand_View;
            if (IsSkillSelecting)
            {
                SetPlayerSkill(view.GetSelectedSkills());
                view.ClearSkillSelection();
                view.ClearPlayerSelection(name);
                _SelectedPlayers.Clear();
            }
            if (_SelectedPlayers.Contains(name) == true)
            {
                _SelectedPlayers.Remove(name);
            }
            else
            {
                _SelectedPlayers.Add(name);
                if (_SelectedPlayers.Count > 0)
                    HighlightSkills();
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
                SetPlayerSkill(view.GetSelectedSkills());
            }
            IsSkillSelecting = !IsSkillSelecting;
            view.IsSkillEditing = IsSkillSelecting;
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
            SkillType type = (SkillType)Enum.Parse(typeof(SkillType), view.SkillsetName);
            var skillList = MainFrame.GetSkillList().Where(x => x.Type.HasFlag(type)).ToList<ISkillBase>();
            view.DrawSkillset(skillList);
        }

        public bool NextPage()
        {
            if (Validation())
            {
                MainFrame.SetPlayerList(_PlayerList);
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
                // 플레이어 이름 중복 체크
                if (_PlayerList.Where(x => x.Name.Equals(player.Name)).Count() > 1)
                {
                    MessageBox.Show($"플레이어 {player.Name}의 이름이 겹칩니다.");
                    return false;
                }
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
        }

        public void InitData()
        {
            AddPlayers(MainFrame.GetPlayerList());
        }
    }
}
