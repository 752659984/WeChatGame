using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChatGame
{
    public class GameHelper
    {
        public static Color personColor = Color.FromArgb(50, 50, 80);

        /// <summary>
        /// 该方法是找出所有相似的点，然后取最左边的点和最右边的点的中间，即使小人的中心点
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="width"></param>
        /// <param name="sy"></param>
        /// <param name="ey"></param>
        /// <param name="personColor"></param>
        /// <returns></returns>
        public static PersonEntity GetLittlePersonBottom(Bitmap bitmap, int width, int sy, int ey, Color personColor, Action<string, Label> timeAction, Label label)
        {
            var lx = width;
            var ly = 0;
            var rx = 0;
            var ry = 0;
            var miny = bitmap.Height;
            var maxy = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            LockBitmap lockbmp = new LockBitmap(bitmap);
            lockbmp.LockBits();

            for (var y = sy; y < ey; ++y)
            {
                for (var x = 0; x < width; ++x)
                {
                    //var color = bitmap.GetPixel(x, y);
                    var color = lockbmp.GetPixel(x, y);

                    if (Math.Abs(color.R - personColor.R) <= 10 &&
                        Math.Abs(color.G - personColor.G) <= 10 &&
                        Math.Abs(color.B - personColor.B) <= 10)
                    {
                        //bitmap.SetPixel(x, y, Color.Red);
                        if (x <= lx)
                        {
                            lx = x;
                            ly = y;
                        }
                        if (x >= rx)
                        {
                            rx = x;
                            ry = y;
                        }

                        if (y < miny)
                        {
                            miny = y;
                        }
                        if (y > maxy)
                        {
                            maxy = y;
                        }
                    }
                }
            }

            lockbmp.UnlockBits();

            var px = (rx - lx) / 2 + lx;
            var py = ly;
            var g = Graphics.FromImage(bitmap);
            //最左边的点
            g.FillEllipse(Brushes.Red, new Rectangle(lx - 2, ly - 2, 5, 5));
            //真正需要的点
            g.FillEllipse(Brushes.Red, new Rectangle(px - 5, py - 5, 11, 11));
            g.Dispose();

            sw.Stop();
            timeAction?.Invoke(sw.ElapsedMilliseconds.ToString(), label);

            //return new Point(px, py);
            return new PersonEntity()
            {
                Center = new Point() { X = px, Y = py },
                LeftUp = new Point() { X = lx - 5, Y = miny - 5 },
                RightDown = new Point() { X = rx + 5, Y = maxy + 5 }
            };
        }

        /// <summary>
        /// 该方法是先找出盒子的顶点，然后找最左边颜色跟顶点相近的点，在取最右边的点，左右中心即是要的点
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="width"></param>
        /// <param name="sy"></param>
        /// <param name="ey"></param>
        /// <returns></returns>
        public static Point GetBoxCenterPoint(Bitmap bitmap, int width, int sy, int ey, PersonEntity pe, Action<string, Label> timeAction, Label label)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            LockBitmap lockbitmap = new LockBitmap(bitmap);
            lockbitmap.LockBits();

            //去背景色
            var background = lockbitmap.GetPixel(5, sy + 5);

            var A = new Point(-1, -1);//下一个盒子的顶点
            var B = new Point(width, -1);//下一个盒子的最左边的点
            var C = new Point(-1, -1);//下一个盒子的最右边的点
            var boxColor = Color.Empty;

            //遍历
            //找A点
            for (var y = sy; (y < ey) && (A.X == -1); ++y)
            {
                for (var x = 0; x < width; ++x)
                {
                    if (x >= pe.LeftUp.X && x <= pe.RightDown.X && y >= pe.LeftUp.Y && y <= pe.RightDown.Y)
                    {
                        continue;
                    }

                    var color = lockbitmap.GetPixel(x, y);

                    if (Math.Abs(color.R - background.R) > 12
                        || Math.Abs(color.G - background.G) > 12
                        || Math.Abs(color.B - background.B) > 12)
                    {
                        A.X = x;
                        //因为会有阴影，所以向下加几个像素
                        A.Y = y + 3; 
                        //记录盒子的颜色
                        boxColor = lockbitmap.GetPixel(A.X, A.Y);
                        //结束获取A
                        break;
                    }

                }
            }
            
            //找B点
            var bsx = A.X - 300;
            var bex = A.X + 300;
            bsx = bsx < 0 ? 0 : bsx;
            bex = bex > width ? width - 10 : bex;
            var count = 0;
            //有的靠很近，所以不用加太多
            //for (var y = A.Y + 50; (y < A.Y + 300) && count <= 30; ++y)
            for (var y = A.Y + 1; (y < A.Y + 300) && count <= 30; ++y)
            {
                for (var x = bsx; x < bex; ++x)
                {
                    var color = lockbitmap.GetPixel(x, y);
                    if (Math.Abs(color.R - boxColor.R) <= 3
                        && Math.Abs(color.G - boxColor.G) <= 3
                        && Math.Abs(color.B - boxColor.B) <= 3)
                    {
                        if (x < B.X)
                        {
                            B.X = x;
                            B.Y = y;
                        }
                        else if (x >= B.X)
                        {
                            ++count;
                        }
                        break;
                    }
                }
            }

            var centerPoint = new Point(A.X, B.Y);

            lockbitmap.UnlockBits();

            var g = Graphics.FromImage(bitmap);
            //取背景色的点
            g.FillEllipse(Brushes.Red, 5, sy + 5, 10, 10);
            //A点
            g.FillEllipse(Brushes.Red, new Rectangle(A.X - 5, A.Y - 5, 11, 11));
            //B点
            g.FillEllipse(Brushes.Red, new Rectangle(B.X - 5, B.Y - 5, 11, 11));
            //中心点
            g.FillEllipse(Brushes.Red, new Rectangle(centerPoint.X - 5, centerPoint.Y - 5, 11, 11));
            
            g.Dispose();

            sw.Stop();
            timeAction?.Invoke(sw.ElapsedMilliseconds.ToString(), label);

            return centerPoint;
        }

        /// <summary>
        /// 获取两点间的距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
        }

        /// <summary>
        /// 返回距离，像素
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static int GetDistance(Bitmap bitmap, Action<string, Label> timeAction, Label lblBox, Label lblPerson)
        {
            if (bitmap != null)
            {
                //初始化参数
                var startScanfNextY = (int)(bitmap.Height * 0.3);//1920*0.3
                var endScanfNextY = (int)(bitmap.Height * 0.7);//1920*0.7

                //画两条线
                var g = Graphics.FromImage(bitmap);
                g.DrawLine(new Pen(Color.Black, 1), 0f, startScanfNextY, bitmap.Width, startScanfNextY);
                g.DrawLine(new Pen(Color.Black, 1), 0f, endScanfNextY, bitmap.Width, endScanfNextY);

                var pe = GetLittlePersonBottom(bitmap, bitmap.Width, startScanfNextY + 1, endScanfNextY - 1, personColor, timeAction, lblPerson);

                var bPoint = GetBoxCenterPoint(bitmap, bitmap.Width, startScanfNextY + 1, endScanfNextY - 1, pe, timeAction, lblBox);

                g.DrawLine(new Pen(Color.Red, 1), pe.Center, bPoint);
                g.Dispose();

                var distance = GetDistance(bPoint, pe.Center);

                return ((int)distance);
            }

            return 0;
        }
    }
}
