using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DiskReader
{
    public partial class Form7 : Form
    {
        const uint WM_SETTEXT = 0xC;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr Zero, string lpName);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        class ProcInfo
        {
            public string Name;
            public IntPtr Handle;

            public ProcInfo(string Name, IntPtr Handle)
            {
                this.Name = Name; this.Handle = Handle;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public Form7()
        {
            InitializeComponent();
            foreach (var proc in Process.GetProcesses())
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    comboBox1.Items.Add(new ProcInfo(proc.MainWindowTitle, proc.MainWindowHandle));
        }

        void SetWinTitle(ProcInfo pi, string newTitle)
        {
            pi.Name = newTitle;
            SendMessage(pi.Handle, WM_SETTEXT, IntPtr.Zero, newTitle);
            comboBox1.Items[comboBox1.SelectedIndex] = pi;
        }

        public int wind = 0;
        void MaxMinimize(ProcInfo pi)
        {
            wind++;
            if (wind % 2 == 1)
            {
                ShowWindow(pi.Handle, 4);
            }
            if (wind % 2 == 0)
            {
                ShowWindow(pi.Handle, 6);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = ((ProcInfo)comboBox1.SelectedItem).Name;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SetWinTitle((ProcInfo)comboBox1.SelectedItem, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MaxMinimize((ProcInfo)comboBox1.SelectedItem);
        }
    }
}

/// Показывает окно
/// </summary>
/// <param name="hWnd">Дескриптор окна, которое нужно показать</param>
/// <param name="nCmdShow">Определяет, как окно отображается:
///SW_HIDE = 0
///Скрыть окно и активизировать другое окно.
///SW_MAXIMIZE = 3
///Развернуть окно.
///SW_MINIMIZE = 6
///Свернуть окно и активизировать следующее окно в Z-порядке(следующее под свернутым окном).
///SW_RESTORE = 9
///Активизировать и отобразить окно.Если окно свернуто или развернуто,Windows восстанавливает его исходный размер и положение.
///SW_SHOW = 5
///Активизировать окно.
///SW_SHOWMAXIMIZED = 3
///Отобразить окно в развернутом виде.
///SW_SHOWMINIMIZED = 2
///Отобразить окно в свернутом виде.
///SW_SHOWMINNOACTIVE = 7
///Отобразить окно в свернутом виде.Активное окно остается активным.
///SW_SHOWNA = 8
///Отобразить окно в текущем состоянии.Активное окно остается активным.
///SW_SHOWNOACTIVATE = 4
///Отобразить окно в соответствии с последними значениями позиции и размера.Активное окно остается активным.
///SW_SHOWNORMAL = 1
///Активизировать и отобразить окно.Если окно свернуто или развернуто,Windows восстанавливает его исходный размер и положение.Приложение должно указывать этот флаг при первом отображении окна.
