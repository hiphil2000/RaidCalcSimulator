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

namespace RaidCalc.Views
{
    public partial class RaidCalcInfoWindow : Form
    {
        public RaidCalcInfoWindow(Boss boss)
        {
            InitializeComponent();
            Lab_Type.Text = boss.Type;
            Lab_Name.Text = boss.Name;
            List_Descriptions.Items.AddRange(boss.Description);
            List_Skills.Items.AddRange(boss.Skills.Select(x => $"{x.Name}({x.Type.ToString()}) - const: {x.SkillConst}, range: {x.RangeType}({x.RangeConst}), description: {x.Description}").ToArray<object>());
            List_TimeLine.Items.AddRange(boss.TimeLines.Select(x => $"전조 : {x.Command}  -->  행동 : {x.Action}").ToArray<object>());
        }
    }
}
