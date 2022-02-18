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
            this.JpgFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.OptInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GifFrames
            // 
            resources.ApplyResources(this.GifFrames, "GifFrames");
            this.GifFrames.Name = "GifFrames";
            // 
            // GifInfo
            // 
            resources.ApplyResources(this.GifInfo, "GifInfo");
            this.GifInfo.Name = "GifInfo";
            // 
            // Status
            // 
            resources.ApplyResources(this.Status, "Status");
            this.Status.Name = "Status";
            // 
            // SelectGifButton
            // 
            resources.ApplyResources(this.SelectGifButton, "SelectGifButton");
            this.SelectGifButton.Name = "SelectGifButton";
            this.SelectGifButton.UseVisualStyleBackColor = true;
            this.SelectGifButton.Click += new System.EventHandler(this.SelectGifButton_Click);
            // 
            // SelectOptDirButton
            // 
            resources.ApplyResources(this.SelectOptDirButton, "SelectOptDirButton");
            this.SelectOptDirButton.Name = "SelectOptDirButton";
            this.SelectOptDirButton.UseVisualStyleBackColor = true;
            this.SelectOptDirButton.Click += new System.EventHandler(this.SelectOptDirButton_Click);
            // 
            // OptDirPathLabel
            // 
            resources.ApplyResources(this.OptDirPathLabel, "OptDirPathLabel");
            this.OptDirPathLabel.AutoEllipsis = true;
            this.OptDirPathLabel.Name = "OptDirPathLabel";
            // 
            // ScaleTrackBar
            // 
            resources.ApplyResources(this.ScaleTrackBar, "ScaleTrackBar");
            this.ScaleTrackBar.Maximum = 100;
            this.ScaleTrackBar.Minimum = 1;
            this.ScaleTrackBar.Name = "ScaleTrackBar";
            this.ScaleTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ScaleTrackBar.Value = 60;
            this.ScaleTrackBar.ValueChanged += new System.EventHandler(this.ScaleTrackBar_ValueChanged);
            // 
            // ScaleTrackBarLabel
            // 
            resources.ApplyResources(this.ScaleTrackBarLabel, "ScaleTrackBarLabel");
            this.ScaleTrackBarLabel.Name = "ScaleTrackBarLabel";
            // 
            // ColumnTrackBarLabel
            // 
            resources.ApplyResources(this.ColumnTrackBarLabel, "ColumnTrackBarLabel");
            this.ColumnTrackBarLabel.Name = "ColumnTrackBarLabel";
            // 
            // ColumnTrackBar
            // 
            resources.ApplyResources(this.ColumnTrackBar, "ColumnTrackBar");
            this.ColumnTrackBar.Maximum = 20;
            this.ColumnTrackBar.Name = "ColumnTrackBar";
            this.ColumnTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ColumnTrackBar.ValueChanged += new System.EventHandler(this.ColumnTrackBar_ValueChanged);
            // 
            // PlaceAvgCheckBox
            // 
            resources.ApplyResources(this.PlaceAvgCheckBox, "PlaceAvgCheckBox");
            this.PlaceAvgCheckBox.Checked = true;
            this.PlaceAvgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlaceAvgCheckBox.Name = "PlaceAvgCheckBox";
            this.PlaceAvgCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConvertButton
            // 
            resources.ApplyResources(this.ConvertButton, "ConvertButton");
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // JpgFormatCheckBox
            // 
            resources.ApplyResources(this.JpgFormatCheckBox, "JpgFormatCheckBox");
            this.JpgFormatCheckBox.Name = "JpgFormatCheckBox";
            this.JpgFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptInfo
            // 
            resources.ApplyResources(this.OptInfo, "OptInfo");
            this.OptInfo.Name = "OptInfo";
            // 
            // App
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.OptInfo);
            this.Controls.Add(this.JpgFormatCheckBox);
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
            this.Name = "App";
            this.Load += new System.EventHandler(this.App_Load);
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
        private System.Windows.Forms.CheckBox JpgFormatCheckBox;
        private System.Windows.Forms.Label OptInfo;
    }
}

