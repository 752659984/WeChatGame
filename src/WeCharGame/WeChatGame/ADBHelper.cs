using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatGame
{
    public class ADBHelper
    {
        public static string ProcessPath = @"D:\adb\adb.exe";
        public static string SavePath = "D:\\";

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string Implement(string cmd)
        {
            string result = "";
            using (Process p = new Process())
            {
                p.StartInfo.FileName = ProcessPath;
                p.StartInfo.Arguments = cmd;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;   //重定向标准输入   
                p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出   
                p.StartInfo.RedirectStandardError = true;   //重定向错误输出   
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                result = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }

            return result;
        }

        /// <summary>
        /// 截图
        /// </summary>
        /// <returns>phonePath</returns>
        public static string ScreenImage()
        {
            var filePath = "/sdcard/screenshot.png";

            //截图
            var cmd = string.Format("shell /system/bin/screencap -p {0}", filePath);
            Implement(cmd);

            return filePath;
        }

        /// <summary>
        /// 复制截图到电脑
        /// </summary>
        /// <returns></returns>
        public static void CopyScreenImage(string phoneFilePath, string toFilePath)
        {
            var cmd = string.Format("pull {0} {1}", phoneFilePath, toFilePath);
            Implement(cmd);
        }


        /// <summary>
        /// 获取截图
        /// </summary>
        /// <returns></returns>
        public static string GetScreen()
        {
            var filePath = SavePath + "screenshot.png";
            var phonePath = ScreenImage();
            CopyScreenImage(phonePath, filePath);
            return filePath;
        }


        /// <summary>
        /// 获取手机类型
        /// </summary>
        /// <returns></returns>
        public static string GetPhoneModel()
        {
            var cmd = "shell getprop ro.product.model";
            return Implement(cmd);
        }


        /// <summary>
        /// 点击指定坐标屏幕time毫秒
        /// </summary>
        /// <param name="x">起点x</param>
        /// <param name="y"></param>
        /// <param name="x2">终点x</param>
        /// <param name="y2"></param>
        /// <param name="time">点击时间（毫秒）</param>
        /// <returns></returns>
        public static string ClickScreen(int x, int y, int x2, int y2, int time)
        {
            var cmd = string.Format("shell input swipe {0} {1} {2} {3} {4}", x, y, x2, y2, time);
            return Implement(cmd);
        }
    }
}
