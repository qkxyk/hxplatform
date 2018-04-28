using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HXCloud.Common
{
    public class ValidateCode
    {
        public static ValidateCode Default = new ValidateCode();
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public string Letters { get; set; }
        public int CodeLength { get; set; }
        private Random r = new Random();
        public ValidateCode()
        {
            ImageWidth = 200;
            ImageHeight = 60;
            CodeLength = 6;
            Letters = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ1234567890";
        }
        public string GetValidationCode()
        {
            //合法随机显示字符列表
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            //将随机生成的字符串绘制到图片上
            for (int i = 0; i < CodeLength; i++)
            {
                s.Append(Letters.Substring(r.Next(0, Letters.Length - 1), 1));
            }
            return s.ToString();
        }
        public byte[] GetValidationImage(string codeString)
        {
            //设置输出流图片格式
            var b = new System.Drawing.Bitmap(ImageWidth, ImageHeight);
            var g = System.Drawing.Graphics.FromImage(b);
            int ColorR = r.Next(0, 255);
            int ColorG = r.Next(0, 255);
            int ColorB = r.Next(0, 255);

            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(ColorR, ColorG, ColorB)), 0, 0, 200, 60);
            var font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSerif, 48, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            //合法随机显示字符列表

            //将随机生成的字符串绘制到图片上
            for (int i = 0; i < codeString.Length; i++)
            {
                int sR = r.Next(0, 255);
                int sG = r.Next(0, 255);
                int sB = r.Next(0, 255);
                while (Math.Abs(sR - ColorR) < 35) sR = r.Next(0, 255);
                while (Math.Abs(sG - ColorG) < 35) sG = r.Next(0, 255);
                while (Math.Abs(sB - ColorB) < 35) sB = r.Next(0, 255);
                g.DrawString(codeString[i].ToString(), font, new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(sR, sG, sB)), i * (200 / codeString.Length - 2), r.Next(0, 15));
            }

            //生成干扰线条
            var pen = new System.Drawing.Pen(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))), 2);
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(pen, new System.Drawing.Point(r.Next(0, 199), r.Next(0, 59)), new System.Drawing.Point(r.Next(0, 199), r.Next(0, 59)));
            }

            var stream = new System.IO.MemoryStream();
            b.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            b.Dispose();
            //输出图片流
            return stream.ToArray();
        }
    }

}
