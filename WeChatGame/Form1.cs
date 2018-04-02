using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChatGame
{
    public partial class Form1 : Form
    {
        private bool isConnetion = false;
        private Thread showImgThread = null;
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtxtMsg.HideSelection = false;
            btnJump.Enabled = false;
            btnAuto.Enabled = false;
            btnLoad.Enabled = false;
            btnStopAuto.Enabled = false;

            System.Threading.Timer connTimer = new System.Threading.Timer(new TimerCallback(t => { ConnTimer_Tick(t); }));
            connTimer.Change(0, 1000);

            //System.Threading.Timer showImageTimer = new System.Threading.Timer(new TimerCallback(ShowImage_Tick), null, Timeout.Infinite, 3000);
            //showImageTimer.Change(0, 5000);
        }

        #region 计时器

        /// <summary>
        /// 检测是否有手机连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnTimer_Tick(object sender)
        {
            AddMsg("正在加载手机...");
            var model = ADBHelper.GetPhoneModel();
            if (model != "")
            {
                AddMsg(string.Format("加载手机成功：{0}！", model));
                lblPhoneModel.Invoke(new Action(() =>
                {
                    lblPhoneModel.Text = model;
                    btnLoad.Enabled = true;
                }));

                isConnetion = true;
                ((System.Threading.Timer)sender).Dispose();
            }
        }

        /// <summary>
        /// 显示截图，因为截图速度慢，所以会来不及加载就获取下一张了
        /// </summary>
        /// <param name="value"></param>
        private void ShowImage_Tick(object value)
        {
            if (isConnetion)
            {
                var filePath = ADBHelper.GetScreen();
                if (File.Exists(filePath))
                {
                    using (var fs = new FileStream(filePath, FileMode.Open))
                    {
                        var bitmap = new Bitmap(fs);

                        var g = Graphics.FromImage(bitmap);

                        g.DrawString(DateTime.Now.ToString(), new Font("宋体", 30f), Brushes.Red, 0, 0);
                        g.Dispose();

                        this.Invoke(new Action(()=> 
                        {
                            picImage.Image = bitmap;
                        }));
                        //bitmap.Dispose();
                    }
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// 自动跳
        /// </summary>
        private void AutoJump()
        {
            try
            {
                if (!isConnetion)
                {
                    AddMsg("未检测到手机...");
                    this.Invoke(new Action(()=> 
                    {
                        btnLoad.Enabled = true;
                        btnAuto.Enabled = true;
                        btnStopAuto.Enabled = false;
                    }));
                    return;
                }
                
                while (isConnetion)
                {
                    JumpOne();
                }
            }
            catch(Exception ex)
            {
                AddMsg(ex.Message);
            }
        }

        /// <summary>
        /// 跳一步
        /// </summary>
        private void JumpOne()
        {
            var sw = new Stopwatch();
            sw.Start();
            //截图并保存到电脑
            AddMsg("\r\n正在获取手机截图...");
            var filePath = ADBHelper.GetScreen();
            if (File.Exists(filePath))
            {
                AddMsg("手机截图获取成功，正在加载图片...");
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var bitmap = new Bitmap(fs);

                    var g = Graphics.FromImage(bitmap);

                    g.DrawString(DateTime.Now.ToString(), new Font("宋体", 30f), Brushes.Red, 0, 0);
                    g.Dispose();

                    this.Invoke(new Action(() =>
                    {
                        picImage.Image = bitmap;
                    }));
                    AddMsg("加载图片成功！");
                }
                //File.Delete(filePath);
                //AddMsg("删除图片成功！");
                File.Move(filePath, ADBHelper.SavePath + count.ToString() + ".png");
                ++count;

                sw.Stop();
                AddMsg(string.Format("获取耗时：{0}ms", sw.ElapsedMilliseconds));

                AddMsg("开始获取距离！");
                var img = new Bitmap(picImage.Image);
                var distance = GameHelper.GetDistance(img, SumTime, lblBox, lblPerson);
                this.Invoke(new Action(() =>
                {
                    picImage.Image = img;
                    lblDistance.Text = distance.ToString();
                }));
                AddMsg(string.Format("距离为：{0}", distance));

                var k = 0d;
                this.Invoke(new Action(() => { double.TryParse(txtJumpK.Text, out k); }));
                var jumpTime = (int)(distance * k);
                AddMsg(string.Format("发送跳跃指令！跳跃时间：{0}！", jumpTime));
                //ADBHelper.ClickScreen(300, 300, 301, 301, jumpTime);
                var random = new Random();
                var x1 = random.Next(300, 500);
                var y1 = random.Next(300, 500);
                var x2 = x1 + random.Next(0, 30);
                var y2 = y1 + random.Next(0, 30);
                ADBHelper.ClickScreen(x1, y1, x2, y2, jumpTime);

                //延时按压时间+跳跃时间+下一个盒子落地时间
                int jumpS = 0, dowsS = 0;
                this.Invoke(new Action(()=> 
                {
                    int.TryParse(txtJump.Text, out jumpS);
                    int.TryParse(txtDown.Text, out dowsS);
                }));
                var sleepTime = jumpTime + jumpS + dowsS;
                AddMsg(string.Format("发送跳跃指令成功，并延时：{0}！", sleepTime));
                Thread.Sleep(sleepTime);
                AddMsg("结束跳跃");
            }
            else
            {
                AddMsg("加载截图失败！");
            }
        }

        #endregion 计时器


        #region 事件

        /// <summary>
        /// 点击图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picImage_MouseClick(object sender, MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;

            var px = x / 0.4;
            var py = y / 0.4;

            label3.Text = (int)px + "," + (int)py;
        }

        #endregion 事件



        #region 按钮事件

        /// <summary>
        /// 打开本地图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog f = new OpenFileDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    double ratio = 0.4;//缩小到图片控件的系数

                    var bitmap = new Bitmap(f.FileName);
                    picImage.Image = bitmap;
                    picImage.Width = (int)(bitmap.Width * ratio);
                    picImage.Height = (int)(bitmap.Height * ratio);
                    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        /// <summary>
        /// 显示连接线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowLine_Click(object sender, EventArgs e)
        {
            if (picImage.Image != null)
            {
                var personColor = Color.FromArgb(50, 50, 80);
                var bitmap = new Bitmap(picImage.Image);
                var s1 = (int)(bitmap.Height * 0.3);//1920*0.3
                var s2 = (int)(bitmap.Height * 0.7);//1920*0.7

                var pe = GameHelper.GetLittlePersonBottom(bitmap, bitmap.Width, s1, s2, personColor, null, null);

                GameHelper.GetBoxCenterPoint(bitmap, bitmap.Width, s1, s2, pe, null, null);

                picImage.Image = bitmap;
            }
        }


        /// <summary>
        /// 跳一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJump_Click(object sender, EventArgs e)
        {
            if (picImage.Image == null)
                return;

            Task t = new Task(JumpOne);
            t.Start();
        }


        /// <summary>
        /// 加载手机截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            ADBHelper.SavePath = string.Format("D:\\{0}\\", DateTime.Now.ToString("yyyyMMddhhmmss"));
            count = 0;

            var filePath = ADBHelper.GetScreen();
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var bitmap = new Bitmap(fs);

                    var g = Graphics.FromImage(bitmap);

                    g.DrawString(DateTime.Now.ToString(), new Font("宋体", 30f), Brushes.Red, 0, 0);
                    g.Dispose();

                    lblResoPo.Text = bitmap.Width + "x" + bitmap.Height;
                    picImage.Width = (int)(bitmap.Width * 0.4);
                    picImage.Height = (int)(bitmap.Height * 0.4);
                    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    picImage.Image = bitmap;
                    //bitmap.Dispose();
                }
                File.Delete(filePath);

                btnAuto.Enabled = true;
                btnJump.Enabled = true;
            }
        }

        /// <summary>
        /// 自动获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuto_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            btnAuto.Enabled = false;
            btnJump.Enabled = false;
            btnStopAuto.Enabled = true;

            showImgThread = new Thread(AutoJump);
            showImgThread.IsBackground = true;
            showImgThread.Start();
        }

        /// <summary>
        /// 结束自动获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopAuto_Click(object sender, EventArgs e)
        {
            if (showImgThread != null)
            {
                showImgThread.Abort();
                rtxtMsg.AppendText("结束自动获取\r\n");

                btnLoad.Enabled = true;
                btnAuto.Enabled = true;
                btnJump.Enabled = true;
                btnStopAuto.Enabled = false;
            }
        }

        #endregion 按钮事件



        #region 其他方法

        /// <summary>
        /// 显示时间
        /// </summary>
        /// <param name="time"></param>
        /// <param name="label"></param>
        private void SumTime(string time, Label label)
        {
            if (label != null)
            {
                this.Invoke(new Action(() =>
                {
                    label.Text = time;
                }));
            }
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="msg"></param>
        private void AddMsg(string msg)
        {
            this.Invoke(new Action(()=> 
            {
                try
                {
                    rtxtMsg.AppendText(msg + "\r\n");
                }
                catch
                {
                }
            }));
        }


        #endregion 其他方法
    }
}
