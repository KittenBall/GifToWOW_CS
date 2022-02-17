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
            this.GifFrames = new System.Windows.Forms.FlowLayoutPanel();
            this.GifInfo = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.SelectGifButton = new System.Windows.Forms.Button();
            this.SelectOptDirButton = new System.Windows.Forms.Button();
            this.OptDirPathLabel = new System.Windows.Forms.Label();
            this.ScaleTrackBar = new System.Windows.Forms.TrackBar();
            this.ScaleTrackBarLabel = new System.Windows.Forms.Label();
            this.ColumnTrackBarLabel = new System.Windows.Forms.Label();
            this.ColumnTrackBar = new System.Windows.Forms.TrackBar();
            this.PlaceAvgCheckBox = new System.Windows.Forms.CheckBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GifFrames
            // 
            this.GifFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GifFrames.AutoScroll = true;
            this.GifFrames.Location = new System.Drawing.Point(5, 1);
            this.GifFrames.Name = "GifFrames";
            this.GifFrames.Size = new System.Drawing.Size(794, 353);
            this.GifFrames.TabIndex = 3;
            // 
            // GifInfo
            // 
            this.GifInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GifInfo.AutoSize = true;
            this.GifInfo.Location = new System.Drawing.Point(3, 367);
            this.GifInfo.Name = "GifInfo";
            this.GifInfo.Size = new System.Drawing.Size(0, 12);
            this.GifInfo.TabIndex = 4;
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(12, 476);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 12);
            this.Status.TabIndex = 5;
            this.Status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SelectGifButton
            // 
            this.SelectGifButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectGifButton.Location = new System.Drawing.Point(713, 465);
            this.SelectGifButton.Name = "SelectGifButton";
            this.SelectGifButton.Size = new System.Drawing.Size(75, 23);
            this.SelectGifButton.TabIndex = 6;
            this.SelectGifButton.Text = "选择Gif";
            this.SelectGifButton.UseVisualStyleBackColor = true;
            this.SelectGifButton.Click += new System.EventHandler(this.SelectGifButton_Click);
            // 
            // SelectOptDirButton
            // 
            this.SelectOptDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectOptDirButton.Location = new System.Drawing.Point(541, 465);
            this.SelectOptDirButton.Name = "SelectOptDirButton";
            this.SelectOptDirButton.Size = new System.Drawing.Size(166, 23);
            this.SelectOptDirButton.TabIndex = 7;
            this.SelectOptDirButton.Text = "选择输出文件夹";
            this.SelectOptDirButton.UseVisualStyleBackColor = true;
            this.SelectOptDirButton.Click += new System.EventHandler(this.SelectOptDirButton_Click);
            // 
            // OptDirPathLabel
            // 
            this.OptDirPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OptDirPathLabel.AutoEllipsis = true;
            this.OptDirPathLabel.Location = new System.Drawing.Point(35, 470);
            this.OptDirPathLabel.Name = "OptDirPathLabel";
            this.OptDirPathLabel.Size = new System.Drawing.Size(500, 12);
            this.OptDirPathLabel.TabIndex = 8;
            this.OptDirPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScaleTrackBar
            // 
            this.ScaleTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleTrackBar.AutoSize = false;
            this.ScaleTrackBar.Location = new System.Drawing.Point(648, 434);
            this.ScaleTrackBar.Maximum = 100;
            this.ScaleTrackBar.Minimum = 1;
            this.ScaleTrackBar.Name = "ScaleTrackBar";
            this.ScaleTrackBar.Size = new System.Drawing.Size(140, 25);
            this.ScaleTrackBar.TabIndex = 9;
            this.ScaleTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ScaleTrackBar.Value = 60;
            this.ScaleTrackBar.ValueChanged += new System.EventHandler(this.ScaleTrackBar_ValueChanged);
            // 
            // ScaleTrackBarLabel
            // 
            this.ScaleTrackBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleTrackBarLabel.AutoSize = true;
            this.ScaleTrackBarLabel.Location = new System.Drawing.Point(657, 419);
            this.ScaleTrackBarLabel.Name = "ScaleTrackBarLabel";
            this.ScaleTrackBarLabel.Size = new System.Drawing.Size(83, 12);
            this.ScaleTrackBarLabel.TabIndex = 10;
            this.ScaleTrackBarLabel.Text = "缩放比例：60%";
            // 
            // ColumnTrackBarLabel
            // 
            this.ColumnTrackBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnTrackBarLabel.AutoSize = true;
            this.ColumnTrackBarLabel.Location = new System.Drawing.Point(511, 419);
            this.ColumnTrackBarLabel.Name = "ColumnTrackBarLabel";
            this.ColumnTrackBarLabel.Size = new System.Drawing.Size(113, 12);
            this.ColumnTrackBarLabel.TabIndex = 12;
            this.ColumnTrackBarLabel.Text = "列数（0：自动）：0";
            // 
            // ColumnTrackBar
            // 
            this.ColumnTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnTrackBar.AutoSize = false;
            this.ColumnTrackBar.Location = new System.Drawing.Point(502, 434);
            this.ColumnTrackBar.Maximum = 20;
            this.ColumnTrackBar.Name = "ColumnTrackBar";
            this.ColumnTrackBar.Size = new System.Drawing.Size(140, 25);
            this.ColumnTrackBar.TabIndex = 11;
            this.ColumnTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ColumnTrackBar.ValueChanged += new System.EventHandler(this.ColumnTrackBar_ValueChanged);
            // 
            // PlaceAvgCheckBox
            // 
            this.PlaceAvgCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaceAvgCheckBox.AutoSize = true;
            this.PlaceAvgCheckBox.Checked = true;
            this.PlaceAvgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlaceAvgCheckBox.Location = new System.Drawing.Point(406, 434);
            this.PlaceAvgCheckBox.Name = "PlaceAvgCheckBox";
            this.PlaceAvgCheckBox.Size = new System.Drawing.Size(72, 16);
            this.PlaceAvgCheckBox.TabIndex = 13;
            this.PlaceAvgCheckBox.Text = "均匀分布";
            this.PlaceAvgCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertButton.Location = new System.Drawing.Point(712, 379);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 14;
            this.ConvertButton.Text = "转换";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // App
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.PlaceAvgCheckBox);
            this.Controls.Add(this.ColumnTrackBarLabel);
            this.Controls.Add(this.ColumnTrackBar);
            this.Controls.Add(this.ScaleTrackBarLabel);
            this.Controls.Add(this.ScaleTrackBar);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.OptDirPathLabel);
            this.Controls.Add(this.SelectOptDirButton);
            this.Controls.Add(this.SelectGifButton);
            this.Controls.Add(this.GifInfo);
            this.Controls.Add(this.GifFrames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Gif转换 1.0";
            this.SizeChanged += new System.EventHandler(this.App_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ScaleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel GifFrames;
        private System.Windows.Forms.Label GifInfo;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button SelectGifButton;
        private System.Windows.Forms.Button SelectOptDirButton;
        private System.Windows.Forms.Label OptDirPathLabel;
        private System.Windows.Forms.TrackBar ScaleTrackBar;
        private System.Windows.Forms.Label ScaleTrackBarLabel;
        private System.Windows.Forms.Label ColumnTrackBarLabel;
        private System.Windows.Forms.TrackBar ColumnTrackBar;
        private System.Windows.Forms.CheckBox PlaceAvgCheckBox;
        private System.Windows.Forms.Button ConvertButton;
    }
}

