using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AliDDNSNet.Utility
{
    public class CmdHelper
    {
        /// <summary>
        /// 运行cmd命令
        /// 不显示命令窗口
        /// </summary>
        /// <param name="command">指定应用程序的完整路径</param>
        /// <param name="cmdStr">执行命令行参数</param>
        public static string ExcuteCmd(string command)
        {
            var output = "";
            using (Process process = new Process())
            {
                command = command.Trim().TrimEnd('&') + "&exit";
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = true; // 隐藏窗口运行
                process.StartInfo.RedirectStandardError = true; // 重定向错误流
                process.StartInfo.RedirectStandardInput = true; // 重定向输入流
                process.StartInfo.RedirectStandardOutput = true; // 重定向输出流
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine(command); // 写入Cmd命令
                process.StandardInput.AutoFlush = true;
                output = process.StandardOutput.ReadToEnd(); //读取结果
                process.WaitForExit();
            }

            return output;
        }
    }
}