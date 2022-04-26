using System;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace YunDictionary
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ShortcutToDesktop(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Youn사전", @"http://vsop.kr/App/YunDictionary/YunDictionary.application");
            
            Application.Run(new frmMain());
        }

        //private static void ShortcutToDesktop(string strDir, string urlName, string eLink)
        //{
        //    using (StreamWriter writer = new StreamWriter(strDir + @"\" + urlName + ".url", false, Encoding.Default))
        //    {
        //        writer.WriteLine(@"[InternetShortcut]");
        //        writer.WriteLine(@"URL=" + eLink);
        //        writer.WriteLine(@"IDList=");
        //        writer.WriteLine(@"IconFile=" + Application.ExecutablePath);

        //        writer.WriteLine(@"HotKey=0");
        //        writer.WriteLine(@"IconIndex=0");
        //        writer.WriteLine(@"[{000214A0-0000-0000-C000-000000000046}]");
        //        writer.WriteLine(@"Prop3=19,2");
        //        writer.WriteLine(@"[InternetShortcut.A]");
        //        writer.WriteLine(@"IconFile=" + Application.ExecutablePath);
        //        writer.Flush();
        //    }
        //}
    }
}
