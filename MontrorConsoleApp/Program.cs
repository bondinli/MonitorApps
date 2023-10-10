using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontrorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RunCmd();
        }

        static public void RunCmd()
        {
            Process process = new Process();
            //C:\\Users\\Administrator\\Desktop\\ffmpeg\\bin\\ffmpeg.exe
            //string sCommand = "SHUTDOWN -s";//DOS 关机命令

            //C:\\Users\\Administrator\\
            //"ffmpeg -i C:\\Users\\Administrator\\Desktop\\ffmpeg\\test.avi -to 00:30 c:\\ttt.avi >c:\\log.txt";//DOS 关机命令
            string sCommand = "D:\\donetCore\\Study\\MontrorConsoleApp\\WindowsFormsApp1\\bin\\Debug\\auto.bat";//DOS 关机命令
            process.StartInfo.FileName = sCommand;//确定程序名 

            process.StartInfo.UseShellExecute = false;//Shell的使用 
            process.StartInfo.RedirectStandardInput = true;//重定向输入 
            process.StartInfo.RedirectStandardOutput = true;//重定向输出 
            process.StartInfo.RedirectStandardError = true;//重定向输出错误   
            process.StartInfo.CreateNoWindow = true;//设置置不显示示窗口 
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;//设置置不显示示窗口 
            process.Start();//00
            process.WaitForExit();


            //process.StandardInput.WriteLine("exit");//要得加上Exit要不然下一行程式  
            //string result = process.StandardOutput.ReadToEnd(); //输出出流取得命令行结果果

            //Response.Write(result);
        }
    }
}
