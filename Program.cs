using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GifToWOWConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                InputImage gif = GetGif();
                float scale = GetScale();

                OutputImageInfo outputInfo = gif.GetOutputImageInfo(scale);
                
                if (outputInfo.width <= 0 || outputInfo.height <= 0)
                {
                    Console.WriteLine("生成的图片宽或高大于8192，请考虑调整帧数或缩放系数");

                }
                else
                {
                    Console.WriteLine("输出图片信息：");
                    Console.WriteLine("图片宽高：" + outputInfo.width + "*" + outputInfo.height);
                    Console.WriteLine("图片帧宽高：" + outputInfo.imageWidth + "*" + outputInfo.imageHeight);
                    Console.WriteLine(outputInfo.col + "列");
                    Console.WriteLine(outputInfo.row + "行");
                    Console.WriteLine();
                    Console.WriteLine("确认转换？ Y/N/Q");

                    switch (Console.ReadLine().ToLower())
                    {
                        case "y":
                            ConvertGif(gif, outputInfo);
                            break;
                        case "n":
                            break;
                        case "q":
                            Environment.Exit(0);
                            break;
                    }
                }
               
                gif.image.Dispose();
            }
        }

        private static InputImage GetGif()
        {
            Console.WriteLine("请输入Gif文件地址（将文件拖入框体即可）");
            String gifPath = Console.ReadLine().ToLower();

            System.Drawing.Image gif = null;
            try
            {
                gif = System.Drawing.Image.FromFile(gifPath);
                int gifWidth = gif.Width;
                int gifHeight = gif.Height;

                if (gifWidth <= 0 || gifHeight <= 0)
                {
                    throw new Exception("未获取到Gif宽高");
                }

                FrameDimension dimension = new FrameDimension(gif.FrameDimensionsList[0]);
                int frameCount = gif.GetFrameCount(dimension);
                if (frameCount <= 1)
                {
                    throw new Exception("Gif必须要会动！");
                }

                Console.WriteLine();
                Console.WriteLine("Gif地址：" + gifPath);
                Console.WriteLine("Gif宽度：" + gifWidth);
                Console.WriteLine("Gif高度：" + gifHeight);
                Console.WriteLine("Gif帧数：" + frameCount);
                Console.WriteLine();

                return new InputImage(gifPath, gif, frameCount);
            }
            catch (Exception ex)
            {
                if (gif != null)
                {
                    gif.Dispose();
                }

                Console.WriteLine(ex.Message);
                return GetGif();
            }
        }

        private static float GetScale()
        {
            Console.WriteLine("请输入图片缩放系数");
            try
            {
                float scale = float.Parse(Console.ReadLine());
                if (scale <= 0)
                {
                    throw new Exception("图片缩放系数必须大于0");
                }
                Console.WriteLine();

                return scale;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return GetScale();
            }
        }

        private static void ConvertGif(InputImage gif,OutputImageInfo optImgInfo)
        {
            Bitmap result = new Bitmap(optImgInfo.width, optImgInfo.height);

            int duration = 0;
            Console.WriteLine("正在转换");
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                for (int i = 0; i < optImgInfo.row; i++)
                {
                    for (int j = i * optImgInfo.col; j < i * optImgInfo.col + optImgInfo.col; j++)
                    {
                        if (j >= gif.frameCount)
                        {
                            continue;
                        }

                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("正在写入第" + (j + 1) + "帧");

                        gif.image.SelectActiveFrame(FrameDimension.Time, j);
                        PropertyItem item = gif.image.GetPropertyItem(0x5100);
                        if (item != null)
                        {
                            byte[] time = new byte[4];
                            time[0] = item.Value[i * 4];
                            time[1] = item.Value[i * 4 + 1];
                            time[2] = item.Value[i * 4 + 2];
                            time[3] = item.Value[i * 4 + 3];
                            duration += BitConverter.ToInt32(time, 0) * 10;
                        }

                        float left, top;
                        left = (j % optImgInfo.col) * optImgInfo.imageWidth;
                        top = i * optImgInfo.imageHeight;

                        if (optImgInfo.imageWidth != gif.image.Width || optImgInfo.imageHeight != gif.image.Height)
                        {
                            var destRect = new Rectangle(0, 0, (int)optImgInfo.imageWidth, (int)optImgInfo.imageHeight);
                            var destImage = new Bitmap((int)optImgInfo.imageWidth, (int)optImgInfo.imageHeight);

                            destImage.SetResolution(gif.image.HorizontalResolution, gif.image.VerticalResolution);

                            using (var graphics = Graphics.FromImage(destImage))
                            {
                                graphics.CompositingMode = CompositingMode.SourceCopy;
                                graphics.CompositingQuality = CompositingQuality.HighQuality;
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                using (var wrapMode = new ImageAttributes())
                                {
                                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                                    graphics.DrawImage(gif.image, destRect, 0, 0, gif.image.Width, gif.image.Height, GraphicsUnit.Pixel, wrapMode);
                                }
                            }

                            g.DrawImage(destImage, new PointF(left, top));

                            destImage.Dispose();
                        }
                        else
                        {
                            g.DrawImage(gif.image, new PointF(left, top));
                        }
                    }
                }
            }

            string outputPath = gif.inputPath.Replace(".gif", ".png");

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine("转换成功，正在保存文件");
            result.Save(outputPath, ImageFormat.Png);
            Console.WriteLine("文件保存成功，保存地址：" + outputPath);
            Console.WriteLine("Gif总时长：" + duration / (float)1000 + "秒");
            Console.WriteLine();

            result.Dispose();

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine();
        }

        class InputImage
        {
            public String inputPath;
            public System.Drawing.Image image;
            public int frameCount;

            public InputImage(String inputPath, System.Drawing.Image image, int frameCount)
            {
                this.inputPath = inputPath;
                this.image = image;
                this.frameCount = frameCount;
            }

            public OutputImageInfo GetOutputImageInfo(float scale) {
                int scaleWidth = (int)(scale * image.Width);
                int scaleHeight = (int)(scale * image.Height);
                OutputImageInfo optImgInfo = new OutputImageInfo
                {
                    imageWidth = scaleWidth,
                    imageHeight = scaleHeight
                };

                int neededSize = scaleWidth * scaleHeight * frameCount;
                int maxSize = 8192;
                int neededWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(scaleWidth) / Math.Log(2)));
                int emptyPixels = int.MaxValue;
                float delta = float.MaxValue;
                
                while(neededWidth <= maxSize)
                {
                    int cols = neededWidth / scaleWidth;
                    int rows = (int)Math.Ceiling(frameCount / (double)cols);
                    int neededHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log(rows * scaleHeight) / Math.Log(2)));
                    //尽可能提高空间利用率
                    int unusedPixels = neededWidth * neededHeight - neededSize;
                    //尽可能趋近于正方形
                    float d = Math.Abs(neededWidth/neededHeight - 1);

                    if (neededHeight <= maxSize && unusedPixels >= 0 && (optImgInfo.width <= 0 || optImgInfo.height <= 0 || unusedPixels < emptyPixels || d < delta))
                    {
                        emptyPixels = unusedPixels;
                        delta = d;

                        optImgInfo.col = cols;
                        optImgInfo.row = rows;
                        optImgInfo.width = neededWidth;
                        optImgInfo.height = neededHeight;
                    }

                    neededWidth = neededWidth * 2;
                };

                return optImgInfo;
            } 
        }
    }

        public class OutputImageInfo
        {
            public int width;
            public int height;
            public int col;
            public int row;
            public float imageWidth;
            public float imageHeight;

            public int GetPixels()
            {
                return width * height;
            }
    }
}
