using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidCalc.Views
{
    public partial class RaidCalcOptionWindow : Form
    {
        private bool CanApply
        {
            get
            {
                return _CanApply;
            }
            set
            {
                _CanApply = value;
                Button_Apply.Enabled = _CanApply;
            }
        }
        private bool _CanApply;

        private bool IsChanged
        {
            get
            {
                return _IsChanged;
            }
            set
            {
                _IsChanged = value;
                Button_Reset.Enabled = _IsChanged;
            }
        }
        private bool _IsChanged;
        private RaidCalcWindow MainFrame;
        private string SrcGameFile;
        private string SrcLogPath;

        public RaidCalcOptionWindow(RaidCalcWindow MainFrame)
        {
            InitializeComponent();
            this.MainFrame = MainFrame;
            SrcGameFile = MainFrame.GetGameFilePath();
            Text_GameFile.Text = SrcGameFile;
            SrcLogPath = MainFrame.GetLogStartPath();
            Text_LogFolder.Text = SrcLogPath;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Ok_Click(object sender, EventArgs e)
        {
            SetDatas();
            this.Close();
        }

        private void Button_Apply_Click(object sender, EventArgs e)
        {
            SetDatas();
            CanApply = false;
        }

        private void CheckCanApply()
        {
            if (File.Exists(Text_GameFile.Text) && Directory.Exists(Text_LogFolder.Text))
                CanApply = true;
        }

        private void Button_GameFileBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.DefaultExt = "json";
                dialog.Filter = "게임 데이터 파일|*.json";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(dialog.FileName))
                    {
                        Text_GameFile.Text = dialog.FileName;
                        CheckCanApply();
                        IsChanged = true;
                    }
                    else
                    {
                        MessageBox.Show("게임 데이터 파일 위치가 잘못되었습니다.", "실패");
                    }
                }
            }
        }

        private void Button_LogFolderBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (Directory.Exists(dialog.SelectedPath))
                    {
                        Text_LogFolder.Text = dialog.SelectedPath;
                        CheckCanApply();
                        IsChanged = true;
                    }
                    else
                    {
                        MessageBox.Show("로그 기본 폴더 위치가 잘못되었습니다.", "실패");
                    }
                }
            }
        }

        private void SetDatas()
        {
            string GameData = "";
            string LogFolder = "";
            if (File.Exists(Text_GameFile.Text))
                GameData = Text_GameFile.Text;
            else
            {
                MessageBox.Show("게임 데이터 파일 위치가 잘못되었습니다.", "실패");
            }
            
            if (Directory.Exists(Text_LogFolder.Text))
                LogFolder = Text_LogFolder.Text;
            else
            {
                MessageBox.Show("로그 기본 폴더 위치가 잘못되었습니다.", "실패");
                return;
            }

            MainFrame.SetDatas(GameData, LogFolder);
        }

        private void Text_GameFile_TextChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            Text_GameFile.Text = SrcGameFile;
            Text_LogFolder.Text = SrcLogPath;
            IsChanged = false;
        }
    }
}
