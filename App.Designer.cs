namespace GifToWOW
{
    partial class App
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.SelectGifButton = new Sunny.UI.UIButton();
            this.SelectOptDirButton = new Sunny.UI.UIButton();
            this.OptDirPathLabel = new Sunny.UI.UILabel();
            this.GifFrames = new System.Windows.Forms.FlowLayoutPanel();
            this.GifInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectGifButton
            // 
            this.SelectGifButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectGifButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectGifButton.FillColor = System.Drawing.Color.White;
            this.SelectGifButton.FillColor2 = System.Drawing.Color.White;
            this.SelectGifButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.SelectGifButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.SelectGifButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.SelectGifButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectGifButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(98)))), ((int)(((byte)(102)))));
            this.SelectGifButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.SelectGifButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.SelectGifButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.SelectGifButton.Location = new System.Drawing.Point(688, 452);
            this.SelectGifButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.SelectGifButton.Name = "SelectGifButton";
            this.SelectGifButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(219)))), ((int)(((byte)(227)))));
            this.SelectGifButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.SelectGifButton.Size = new System.Drawing.Size(100, 35);
            this.SelectGifButton.Style = Sunny.UI.UIStyle.Custom;
            this.SelectGifButton.TabIndex = 0;
            this.SelectGifButton.Text = "选择Gif";
            this.SelectGifButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectGifButton.Click += new System.EventHandler(this.SelectGifButton_Click);
            // 
            // SelectOptDirButton
            // 
            this.SelectOptDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectOptDirButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectOptDirButton.FillColor = System.Drawing.Color.White;
            this.SelectOptDirButton.FillColor2 = System.Drawing.Color.White;
            this.SelectOptDirButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.SelectOptDirButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.SelectOptDirButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.SelectOptDirButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectOptDirButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(98)))), ((int)(((byte)(102)))));
            this.SelectOptDirButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.SelectOptDirButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.SelectOptDirButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.SelectOptDirButton.Location = new System.Drawing.Point(541, 452);
            this.SelectOptDirButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.SelectOptDirButton.Name = "SelectOptDirButton";
            this.SelectOptDirButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(219)))), ((int)(((byte)(227)))));
            this.SelectOptDirButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.SelectOptDirButton.Size = new System.Drawing.Size(141, 35);
            this.SelectOptDirButton.Style = Sunny.UI.UIStyle.Custom;
            this.SelectOptDirButton.TabIndex = 1;
            this.SelectOptDirButton.Text = "选择输出文件夹";
            this.SelectOptDirButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectOptDirButton.Click += new System.EventHandler(this.SelectOptDirButton_Click);
            // 
            // OptDirPathLabel
            // 
            this.OptDirPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OptDirPathLabel.AutoEllipsis = true;
            this.OptDirPathLabel.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptDirPathLabel.Location = new System.Drawing.Point(18, 459);
            this.OptDirPathLabel.Name = "OptDirPathLabel";
            this.OptDirPathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OptDirPathLabel.Size = new System.Drawing.Size(517, 28);
            this.OptDirPathLabel.Style = Sunny.UI.UIStyle.Custom;
            this.OptDirPathLabel.TabIndex = 2;
            this.OptDirPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GifFrames
            // 
            this.GifFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GifFrames.AutoScroll = true;
            this.GifFrames.Location = new System.Drawing.Point(3, 38);
            this.GifFrames.Name = "GifFrames";
            this.GifFrames.Size = new System.Drawing.Size(794, 353);
            this.GifFrames.TabIndex = 3;
            // 
            // GifInfo
            // 
            this.GifInfo.AutoSize = true;
            this.GifInfo.Location = new System.Drawing.Point(3, 407);
            this.GifInfo.Name = "GifInfo";
            this.GifInfo.Size = new System.Drawing.Size(55, 21);
            this.GifInfo.TabIndex = 4;
            this.GifInfo.Text = "label1";
            // 
            // App
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ControlBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(98)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.GifInfo);
            this.Controls.Add(this.GifFrames);
            this.Controls.Add(this.OptDirPathLabel);
            this.Controls.Add(this.SelectOptDirButton);
            this.Controls.Add(this.SelectGifButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(219)))), ((int)(((byte)(227)))));
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowRect = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "GifConverter";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(219)))), ((int)(((byte)(227)))));
            this.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(98)))), ((int)(((byte)(102)))));
            this.SizeChanged += new System.EventHandler(this.App_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton SelectGifButton;
        private Sunny.UI.UIButton SelectOptDirButton;
        private Sunny.UI.UILabel OptDirPathLabel;
        private System.Windows.Forms.FlowLayoutPanel GifFrames;
        private System.Windows.Forms.Label GifInfo;
    }
}

