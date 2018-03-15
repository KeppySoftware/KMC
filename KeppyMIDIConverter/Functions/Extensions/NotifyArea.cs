using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    class NotifyArea
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        static ContextMenu NotifyMenu = new ContextMenu();
        static MenuItem KMCVersion = new MenuItem();
        static MenuItem Separator = new MenuItem();
        public static MenuItem ExitItem = new MenuItem();
        static NotifyIcon NotifyTray = new NotifyIcon();

        public static void ShowIconTray()
        {
            KMCVersion.Index = 0;
            KMCVersion.Text = String.Format("KMC {0}.{1}.{2} {3} (Ses. {4})", 
                InfoDialog.Converter.FileMajorPart, InfoDialog.Converter.FileMinorPart, InfoDialog.Converter.FileBuildPart,
                (Environment.Is64BitProcess ? "x64" : "x86"), BootUp.Session);
            KMCVersion.Enabled = false;

            Separator.Index = 1;
            Separator.Text = "-";
            Separator.Enabled = false;

            ExitItem.Index = 2;
            ExitItem.Text = Languages.Parse("Exit");
            ExitItem.Click += new System.EventHandler(ExitFromApp);

            NotifyMenu.MenuItems.AddRange(new MenuItem[] {
                KMCVersion,
                Separator,
                ExitItem
            });

            NotifyTray.Icon = Properties.Resources.mainlogo1;
            NotifyTray.Text = "Keppy's MIDI Converter";
            NotifyTray.Visible = true;
            NotifyTray.MouseClick += new MouseEventHandler(ClickTray);
            NotifyTray.ContextMenu = NotifyMenu;
        }

        public static void HideIconTray()
        {
            NotifyTray.Icon = null;
            NotifyTray.Text = null;
            NotifyTray.Visible = false;
        }

        public static void ChangeTitleTray(String Title)
        {
            NotifyTray.Text = Title;
        }

        public static void ShowStatusTray(String Title, String Status, ToolTipIcon Icon)
        {
            NotifyTray.BalloonTipIcon = Icon;
            NotifyTray.BalloonTipTitle = Title;
            NotifyTray.BalloonTipText = Status;
            NotifyTray.ShowBalloonTip(5000);
        }

        public static void ClickTray(object sender, MouseEventArgs e)
        {
            try
            {
                MainWindow.Delegate.Show();
                ShowWindow(MainWindow.Delegate.Handle, 0x09);
            }
            catch { }
        }

        public static void ExitFromApp(object sender, EventArgs e)
        {
            if (MainWindow.ConfirmExit()) MainWindow.CloseApp();
        }
    }
}
