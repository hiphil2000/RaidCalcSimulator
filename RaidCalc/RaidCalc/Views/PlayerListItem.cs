using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaidCalcCore.Models;

namespace RaidCalc.Views
{
    public partial class PlayerListItem : UserControl
    {
        [Category("ReadOnly"), Description("보기 전용 컨트롤인지 입력 가능 컨트롤인지를 나타냅니다.")]
        private bool isReadOnly { get; set; }

        public PlayerListItem()
        {
            InitializeComponent();
        }

        public Player GetDataAsPlayer()
        {
            Player player = new Player(
                Text_PlayerName.Text,
                new Stats(
                    double.Parse(Text_Stat1.Text),
                    double.Parse(Text_Stat2.Text),
                    double.Parse(Text_Stat3.Text)
                ),
                int.Parse(Text_MaxHp.Text),
                int.Parse(Text_CurrentHp.Text),
                1,
                -1,
                -1);
            return player;
        }

        
    }
}
