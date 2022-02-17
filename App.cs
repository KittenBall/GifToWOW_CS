using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TGASharpLib;

namespace GifToWOW
{
    public partial class App : Form, GifConverter.IGifConverterListener
    {
        private string gifPath;
        private string optDirPath;
        private GifConverter gifConverter;
        private readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private List<PictureBox> pictureBoxes;

        public App()
        {
            gifConverter = new GifConverter(this);
            InitializeComponent();
            OptDirPathLabel.Text = desktopPath;
            pictureBoxes = new List<PictureBox>();
        }

        private void SelectGifButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog gifSelectDialog = new OpenFileDialog();
            gifSelectDialog.Filter = "Gif|*.gif";
            gifSelectDialog.Title = "选择Gif文件";
            gifSelectDialog.InitialDirectory = gifPath == null ? desktopPath : Path.GetDirectoryName(gifPath);
            if (gifSelectDialog.ShowDialog() == DialogResult.OK)
            {
                gifPath = gifSelectDialog.FileName;
                OnGifSelected();
            }
        }

        private void SelectOptDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog optDirDialog = new FolderBrowserDialog();
            optDirDialog.Description = "选择输出文件夹";
            optDirDialog.SelectedPath = optDirPath == null ? desktopPath : optDirPath;
            DialogResult dialogResult = optDirDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK) 
            {
                optDirPath = optDirDialog.SelectedPath;
                OptDirPathLabel.Text = optDirPath;
            }
        }

        private void App_SizeChanged(object sender, EventArgs e)
        {
            GifFrames.Height = (int)(this.Height * 0.65);
            GifFrames.PerformLayout();
            GifInfo.Location = new Point(4, GifFrames.Location.Y + GifFrames.Height + 10);
        }

        private void ScaleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ScaleTrackBarLabel.Text = "缩放比例：" + ScaleTrackBar.Value + "%";
        }


        private void ColumnTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ColumnTrackBarLabel.Text = "列数（0：自动）：" + ColumnTrackBar.Value;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            gifConverter.StartOutput(optDirPath == null ? desktopPath : optDirPath, ScaleTrackBar.Value, ColumnTrackBar.Value, PlaceAvgCheckBox.Checked);
        }

        private void OnGifSelected()
        {
            GifFrames.Controls.Clear();
            gifConverter.SetGifPath(gifPath);
        }

        private void ShowGifFrames()
        {
            var frames = gifConverter.GetFrames();
            var count = frames.Count;
            for (int i = 0; i < count; i++)
            {
                PictureBox picture = null;
                if (i < pictureBoxes.Count)
                {
                    picture = pictureBoxes[i];
                }
                else
                {
                    picture = new PictureBox();
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxes.Add(picture);
                }

                picture.Size = new Size((int)(GifFrames.Width / 5.5), (int)(GifFrames.Width / 5.5));

                picture.Image = new Bitmap(frames[i]);

                GifFrames.Controls.Add(picture);
            }
        }

        private void ShowGifInfos()
        {
            string info = "帧数量：" + gifConverter.GetFrames().Count + "\n"
                + "宽高：" + gifConverter.GetImageWidth() + "x" + gifConverter.GetImageHeight() + "\n"
                + "时长：" + gifConverter.GetDuration()/1000f + "秒";
            GifInfo.Text = info;
        }

        private void ShowInfo(string info) 
        {
            Status.Text = info;
            Status.ForeColor = Color.FromName("#666666");
        }

        private void ShowError(string error)
        {
            Status.Text = error;
            Status.ForeColor = Color.Red;
        }

        public void OnProcessStart()
        {
            ShowInfo("正在处理");
        }

        public void OnProcessEnd()
        {
            ShowGifFrames();
            ShowGifInfos();
            ShowInfo("处理完成");
        }

        public void OnConvertStart()
        {
            ShowInfo("开始转换");
        }

        public void OnConvertEnd()
        {
            ShowInfo("转换完成");
        }

        public void OnProcessError(Exception ex)
        {
            ShowError(ex.Message);
        }

        public void OnConvertError(Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    public class GifConverter
    {

        private readonly IGifConverterListener listener;
        private string gifPath;
        private Image gifImage;
        private List<Image> gifFrames = new List<Image>();
        private int duration;

        public GifConverter(IGifConverterListener listener)
        {
            this.listener = listener;
        }

        public void SetGifPath(string gifPath)
        {
            this.gifPath = gifPath;
            ProcessGif();
        }

        private  Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

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
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void ProcessGif()
        {
            listener.OnProcessStart();
            try
            {
                duration = 0;
                for (int i = 0; i < gifFrames.Count; i++)
                {
                    gifFrames[i].Dispose();
                }
                gifFrames.Clear();
                if (gifImage != null)
                { 
                    gifImage.Dispose();
                    gifImage = null;
                }
                if (gifPath == null || !File.Exists(gifPath))
                { 
                    listener.OnProcessError(new Exception("Gif不存在"));
                    return;
                }

                gifImage = Image.FromFile(gifPath);
                int frameCount = gifImage.GetFrameCount(FrameDimension.Time);
                for (int i = 0; i < frameCount; i++) {
                    gifImage.SelectActiveFrame(FrameDimension.Time, i);
                    Image image = gifImage.Clone() as Image;
                    gifFrames.Add(image);

                    PropertyItem item = image.GetPropertyItem(0x5100);
                    if (item != null)
                    {
                        byte[] time = new byte[4];
                        time[0] = item.Value[i * 4];
                        time[1] = item.Value[i * 4 + 1];
                        time[2] = item.Value[i * 4 + 2];
                        time[3] = item.Value[i * 4 + 3];
                        duration += BitConverter.ToInt32(time, 0) * 10;
                    }
                }

                listener.OnProcessEnd();
            }
            catch (Exception ex)
            {
                listener.OnProcessError(ex);
            }
        }

        public void StartOutput(string desDir, int scale, int cols, Boolean placeAvg)
        {
            if (gifPath == null || !File.Exists(gifPath))
            {
                listener.OnConvertError(new Exception("请选择Gif"));
                return;
            }

            if (gifFrames.Count <= 0)
            {
                listener.OnConvertError(new Exception("请选择帧数>0的Gif"));
                return;
            }

            if (desDir == null || !Directory.Exists(desDir))
            {
                listener.OnConvertError(new Exception("目标文件夹不存在"));
                return;
            }
            try
            {
                listener.OnConvertStart();
                List<Bitmap> bitmaps = new List<Bitmap>();
                int scaleWidth = (int)(scale / 100f * gifImage.Width);
                int scaleHeight = (int)(scale /100f * gifImage.Height);
                for (int i = 0; i < gifFrames.Count; i++) 
                {
                    bitmaps.Add(ResizeImage(gifFrames[i], scaleWidth, scaleHeight));
                }

                OutputImageInfo optImgInfo = CalcMostSuitableImageInfo(bitmaps, scaleWidth, scaleHeight, cols);
                Bitmap result = new Bitmap(optImgInfo.width, optImgInfo.height);
                using (Graphics g = Graphics.FromImage(result)) 
                {
                    for (int i = 0; i < optImgInfo.row; i++)
                    {
                        for (int j = i * optImgInfo.col; j < i * optImgInfo.col + optImgInfo.col; j++)
                        {
                            if (j < bitmaps.Count)
                            {
                                var bitmap = bitmaps[j];
                                int left, top;
                                if (placeAvg)
                                {
                                    left = (j % optImgInfo.col) * optImgInfo.cellWidth + (optImgInfo.cellWidth - optImgInfo.frameWidth) / 2;
                                    top = i * optImgInfo.cellHeight + (optImgInfo.cellHeight - optImgInfo.frameHeight) / 2;
                                }
                                else
                                {
                                    left = j % optImgInfo.col * optImgInfo.frameWidth;
                                    top = i * optImgInfo.frameHeight;
                                }
                                g.DrawImage(bitmap, new Point(left, top));
                            }
                        }
                    }
                }

                string fileName = Path.GetFileName(gifPath).Replace(".gif", "");
                //string pngFileName = fileName + ".png";
                //result.Save(desDir + "/" + pngFileName, ImageFormat.Png);

                //var pngFile = new TGA(desDir + "/" + pngFileName);
                //pngFile.Save(desDir + "/" + fileName + ".tga");
                ((TGA)result).Save(desDir + "/" + fileName + ".tga");

                listener.OnConvertEnd();
            }
            catch (Exception ex)
            {
                listener.OnConvertError(ex);
            }

        }

        private OutputImageInfo CalcMostSuitableImageInfo(List<Bitmap> bitmaps, int width, int height, int cols)
        {
            OutputImageInfo optImgInfo = new OutputImageInfo
            {
                frameWidth = width,
                frameHeight = height
            };

            if (cols > 0)
            {
                FillOptImgInfo(bitmaps, width, height, cols, optImgInfo);
            }
            else
            {
                cols = Math.Min(bitmaps.Count, (int)Math.Ceiling(bitmaps.Count / 2d));
                for (int i = cols; i > 0; i--)
                {
                    FillOptImgInfo(bitmaps, width, height, i, optImgInfo);
                }
            }
            return optImgInfo;
        }

        private void FillOptImgInfo(List<Bitmap> bitmaps, int width, int height, int cols, OutputImageInfo optImgInfo)
        {
            int row = (int)Math.Ceiling(bitmaps.Count / (double)cols);
            int realWidth = width * cols;
            int realHeight = height * row;
            double neededWidth = Math.Pow(2, Math.Ceiling(Math.Log(realWidth) / Math.Log(2)));
            double neededHeight = Math.Pow(2, Math.Ceiling(Math.Log(realHeight) / Math.Log(2)));
            double neededPixels = neededWidth * neededHeight;
            if (optImgInfo.getPixels() <= 0 || neededPixels < optImgInfo.getPixels())
            {
                optImgInfo.col = cols;
                optImgInfo.row = row;
                optImgInfo.width = (int)neededWidth;
                optImgInfo.height = (int)neededHeight;
                optImgInfo.cellWidth = (int)(neededWidth / cols);
                optImgInfo.cellHeight = (int)(neededHeight / Math.Floor(neededHeight / height));
            }
        }

        public List<Image> GetFrames()
        { 
            return gifFrames;
        }

        public int GetDuration()
        {
            return duration;
        }

        public int GetImageWidth()
        {
            return gifImage.Width;
        }

        public int GetImageHeight()
        {
            return gifImage.Height;
        }

        public interface IGifConverterListener 
        {
            void OnProcessStart();

            void OnProcessEnd();

            void OnProcessError(Exception ex);

            void OnConvertStart();

            void OnConvertEnd();

            void OnConvertError(Exception ex);
        }
    }

    public class OutputImageInfo
    {
        public int width;
        public int height;
        public int col;
        public int row;
        public int cellWidth;
        public int cellHeight;
        public int frameWidth;
        public int frameHeight;

        public int getPixels()
        {
            return width * height;
        }

    }
}
