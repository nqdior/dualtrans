using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DualDeepL
{
    internal static class Program
    {
        static readonly string mutexName = "DualDeepL";

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, mutexName, out bool createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ApplicationConfiguration.Initialize();
                    Application.Run(new MainForm());
                }
                else
                {
                    // 既に実行されているアプリケーションのインスタンスを見つける
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            // 既存のアプリケーションウィンドウをアクティブにする
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
}