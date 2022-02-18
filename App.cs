using GifToWOW.Properties;
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
        private static readonly string VERSION = " 1.2";
        private string gifPath;
        private string optDirPath;
        private GifConverter gifConverter;
        private readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private List<PictureBox> pictureBoxes;

        public App()
        {
            gifConverter = new GifConverter(this);
            InitializeComponent();
            App_SizeChanged(null, null);
            this.Text += VERSION;
            OptDirPathLabel.Text = desktopPath;
            pictureBoxes = new List<PictureBox>();
        }

        private void SelectGifButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog gifSelectDialog = new OpenFileDialog();
            gifSelectDialog.Filter = "Gif|*.gif";
            gifSelectDialog.Title = Resources.SelectGif;
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
            optDirDialog.Description = Resources.SelectOptDir;
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
            OptInfo.Location = new Point(150, GifFrames.Location.Y + GifFrames.Height + 10);
        }

        private void ScaleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ScaleTrackBarLabel.Text =  Resources.Zoom + ScaleTrackBar.Value + "%";
        }


        private void ColumnTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ColumnTrackBarLabel.Text = Resources.Column + ColumnTrackBar.Value;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            gifConverter.StartOutput(optDirPath == null ? desktopPath : optDirPath, ScaleTrackBar.Value, ColumnTrackBar.Value, PlaceAvgCheckBox.Checked, JpgFormatCheckBox.Checked);
        }

        private void OnGifSelected()
        {
            OptInfo.Text = null;
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
                    picture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    Label label = new Label
                    {
                        Text = (i + 1).ToString(),
                        ForeColor = Color.Blue,
                        BackColor = Color.Transparent,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        Location = new Point(4, 4),
                    };
                    picture.Controls.Add(label);

                    pictureBoxes.Add(picture);
                }

                picture.Size = new Size((int)(GifFrames.Width / 5.5), (int)(GifFrames.Width / 5.5));
                picture.Image = new Bitmap(frames[i]);
                GifFrames.Controls.Add(picture);
            }
        }

        private void ShowGifInfos()
        {
            string info = Resources.FrameCount + gifConverter.GetFrames().Count + "\n" + Resources.ImageSize + gifConverter.GetImageWidth() + "x" + gifConverter.GetImageHeight() + "\n" + Resources.Duration + gifConverter.GetDuration() / 1000f + Resources.Second + "\n" + Resources.FrameRate + gifConverter.GetFrameRate() + "";
            GifInfo.Text = info;
        }
        private void ShowOutputInfo(OutputImageInfo optInfo)
        {
            string info = Resources.Output + "\n"
                + Resources.ImageSize + optInfo.width + "x" + optInfo.height + "\n";
            if (optInfo.placeAvg)
            {
                info += Resources.ColumnCount + optInfo.col + "\n"
                + Resources.RowCount + optInfo.row + "\n";
            }

            info +=  Resources.ColumnWidth + optInfo.GetColumnWidth() + "\n"
                + Resources.RowHeight + optInfo.GetRowHeight();

            OptInfo.Text = info;
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
            ShowInfo(Resources.ProcessStart);
        }

        public void OnProcessEnd()
        {
            ShowGifFrames();
            ShowGifInfos();
            ShowInfo(Resources.ProcessEnd);
        }

        public void OnConvertStart()
        {
            ShowInfo(Resources.ConvertStart);
        }

        public void OnConvertEnd(OutputImageInfo optInfo)
        {
            ShowOutputInfo(optInfo);
            ShowInfo(Resources.ConvertEnd);
        }

        public void OnProcessError(Exception ex)
        {
            ShowError(ex.Message);
        }

        public void OnConvertError(Exception ex)
        {
            ShowError(ex.Message);
        }

        private void App_Load(object sender, EventArgs e)
        {

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
                    listener.OnProcessError(new Exception(Resources.GifNotExists));
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

        public void StartOutput(string desDir, int scale, int cols, bool placeAvg, bool jpgFormat)
        {
            if (gifPath == null || !File.Exists(gifPath))
            {
                listener.OnConvertError(new Exception(Resources.GifNotExists));
                return;
            }

            if (gifFrames.Count <= 1)
            {
                listener.OnConvertError(new Exception(Resources.GifMustAnimate));
                return;
            }

            if (desDir == null || !Directory.Exists(desDir))
            {
                listener.OnConvertError(new Exception(Resources.DesDirNotExists));
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
                optImgInfo.placeAvg = placeAvg;
                Bitmap result = new Bitmap(optImgInfo.width, optImgInfo.height);
                using (Graphics g = Graphics.FromImage(result)) 
                {
                    if (jpgFormat)
                    {
                        g.Clear(Color.White);
                    }

                    for (int i = 0; i < optImgInfo.row; i++)
                    {
                        for (int j = i * optImgInfo.col; j < i * optImgInfo.col + optImgInfo.col; j++)
                        {
                            if (j < bitmaps.Count)
                            {
                                var bitmap = bitmaps[j];
                                float left, top;
                                if (placeAvg)
                                {
                                    left = (j % optImgInfo.col) * optImgInfo.cellWidth + (optImgInfo.cellWidth - optImgInfo.imageWidth) / 2;
                                    top = i * optImgInfo.cellHeight + (optImgInfo.cellHeight - optImgInfo.imageHeight) / 2;
                                }
                                else
                                {
                                    left = j % optImgInfo.col * optImgInfo.imageWidth;
                                    top = i * optImgInfo.imageHeight;
                                }
                                g.DrawImage(bitmap, new PointF(left, top));
                            }
                        }
                    }
                }

                string fileName = Path.GetFileName(gifPath).Replace(".gif", "");
                if (jpgFormat)
                {
                    result.Save(desDir + "/" + fileName + ".jpg", ImageFormat.Jpeg);
                }
                else
                {
                    ((TGA)result).Save(desDir + "/" + fileName + ".tga");
                }

                listener.OnConvertEnd(optImgInfo);
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
                imageWidth = width,
                imageHeight = height
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
            int neededWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(realWidth) / Math.Log(2)));
            int neededHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log(realHeight) / Math.Log(2)));
            int neededPixels = neededWidth * neededHeight;
            if (optImgInfo.GetPixels() <= 0 || neededPixels < optImgInfo.GetPixels())
            {
                optImgInfo.col = cols;
                optImgInfo.row = row;
                optImgInfo.width = neededWidth;
                optImgInfo.height = neededHeight;
                optImgInfo.cellWidth = neededWidth / (float)cols;
                optImgInfo.cellHeight = (float)(neededHeight / Math.Floor(neededHeight /(float) height));
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

        public float GetFrameRate()
        {
            if (gifFrames.Count > 0)
            {
                return 1 / (duration / 1000f / gifFrames.Count);
            }
            else
            {
                return 1;
            }
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

            void OnConvertEnd(OutputImageInfo optInfo);

            void OnConvertError(Exception ex);
        }
    }

    public class OutputImageInfo
    {
        public int width;
        public int height;
        public int col;
        public int row;
        public float cellWidth;
        public float cellHeight;
        public float imageWidth;
        public float imageHeight;
        public bool placeAvg;

        public int GetPixels()
        {
            return width * height;
        }

        public float GetColumnWidth()
        {
            return placeAvg ? cellWidth : imageWidth;
        }

        public float GetRowHeight()
        { 
            return placeAvg ? cellHeight : imageHeight;
        }

    }
}
