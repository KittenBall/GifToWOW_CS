using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace GifToWOW
{
    public partial class App : UIForm, GifConverter.IGifConverterListener
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
            gifSelectDialog.Filter = "Gif文件|*.gif";
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
            FolderBrowserDialogEx optDirDialog = new FolderBrowserDialogEx();
            optDirDialog.Description = "选择输出文件夹";
            optDirDialog.DirectoryPath = optDirPath == null ? desktopPath : optDirPath;
            DialogResult dialogResult = optDirDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK) 
            {
                optDirPath = optDirDialog.DirectoryPath;
                OptDirPathLabel.Text = optDirPath;
            }
        }

        private void GifFrames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void App_SizeChanged(object sender, EventArgs e)
        {
            GifFrames.Height = (int)(this.Height * 0.65);
        }

        private void OnGifSelected()
        {
            GifFrames.Controls.Clear();
            gifConverter.SetGifPath(gifPath);
        }

        private void DisablePictureBoxAnimate(PictureBox pictureBox)
        {
            var animateMethod = typeof(PictureBox).GetMethod("Animate",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
            null, new Type[] { typeof(bool) }, null);
            animateMethod.Invoke(pictureBox, new object[] { false });
        }

        public void OnProcessStart()
        {
            
        }

        public void OnProcessEnd()
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
            Console.WriteLine(gifConverter.GetDuration());
        }

        public void OnConvertStart()
        {
            throw new NotImplementedException();
        }

        public void OnConvertEnd()
        {
            throw new NotImplementedException();
        }

        public void OnConvertError()
        {
            throw new NotImplementedException();
        }

        public void OnProcessError(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        public void OnConvertError(Exception ex)
        {
            
        }
    }

    public class GifConverter
    {

        private readonly IGifConverterListener listener;
        private string gifPath;
        private Image gifImage;
        private List<Image> gifFrames = new List<Image>();

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
                gifImage = null;
                gifFrames.Clear();
                if (gifPath == null || !File.Exists(gifPath))
                { 
                    listener.OnProcessError(new Exception("Gif不存在"));
                    return;
                }

                gifImage = Image.FromFile(gifPath);
                int frameCount = gifImage.GetFrameCount(FrameDimension.Time);
                for (int i = 0; i < frameCount; i++) {
                    gifImage.SelectActiveFrame(FrameDimension.Time, i);
                    gifFrames.Add(gifImage.Clone() as Image);
                }

                listener.OnProcessEnd();
            }
            catch (Exception ex)
            {
                listener.OnProcessError(ex);
            }
        }

        public List<Image> GetFrames()
        { 
            return gifFrames;
        }

        public int GetDuration()
        {
            PropertyItem item = gifImage.GetPropertyItem(0x5100); // FrameDelay in libgdiplus
                                                             // Time is in milliseconds
            return (item.Value[0] + item.Value[1] * 256) * 10;
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
}
