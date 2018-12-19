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
    public partial class RaidCalcLogWindow : Form
    {
        private RaidCalcWindow _MainFrame;

        public RaidCalcLogWindow(RaidCalcWindow mainFrame)
        {
            InitializeComponent();
            _MainFrame = mainFrame;
            Text_Logs.Text = mainFrame.PrintLog();
        }

        private void RaidCalcLogWindow_Resize(object sender, EventArgs e)
        {
            Text_Logs.Size = new Size(Width - 36, Height - 51 - Text_Logs.Location.Y);
            Flow_ButtonBox.Location = new Point(Text_Logs.Location.X + Text_Logs.Width - Flow_ButtonBox.Width, Flow_ButtonBox.Location.Y);

        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, Text_Logs.Text);
            MessageBox.Show("클립보드에 저장됐습니다.", "알림");
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = null;
                try
                {
                    string path = folderBrowserDialog.SelectedPath;
                    string fileName = $"{path}/{DateTime.Now.ToString("yyyy/MM/dd hh/mm/ss")}LOG.txt";
                    writer = new StreamWriter(fileName);
                    writer.WriteLine(Text_Logs.Text);
                    MessageBox.Show($"로그파일이 저장됐습니다. 경로:\r\n[{fileName}", "성공");
                    string msg = $"로그파일이 저장됐습니다. => {fileName}";
                    Console.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생했습니다.\r\n" + ex.ToString(), "실패");
                    string msg = $"로그 저장에 실패했습니다.\n{ex.ToString()}";
                    Console.WriteLine(msg);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
                
            }
        }

        private void Button_SaveDefault_Click(object sender, EventArgs e)
        {
            StreamWriter writer = null;
            try
            {
                string path = _MainFrame.GetLogStartPath();
                string fileName = $"{path}/{DateTime.Now.ToString("yyyy/MM/dd hh/mm/ss")}LOG.txt";
                writer = new StreamWriter(fileName);
                writer.WriteLine(Text_Logs.Text);
                MessageBox.Show($"로그파일이 저장됐습니다. 경로:\r\n[{fileName}", "성공");
                string msg = $"로그파일이 저장됐습니다. => {fileName}";
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다.\r\n" + ex.ToString(), "실패");
                string msg = $"로그 저장에 실패했습니다.\n{ex.ToString()}";
                Console.WriteLine(msg);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
