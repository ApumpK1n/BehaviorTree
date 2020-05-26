namespace Behavior
{
    partial class Behavior
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Behavior));
            this.NodetreeView = new System.Windows.Forms.TreeView();
            this.IconImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // NodetreeView
            // 
            this.NodetreeView.ImageIndex = 0;
            this.NodetreeView.ImageList = this.IconImageList;
            this.NodetreeView.Location = new System.Drawing.Point(12, 166);
            this.NodetreeView.Name = "NodetreeView";
            this.NodetreeView.SelectedImageIndex = 0;
            this.NodetreeView.Size = new System.Drawing.Size(151, 258);
            this.NodetreeView.TabIndex = 0;
            this.NodetreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NodetreeView_AfterSelect);
            // 
            // IconImageList
            // 
            this.IconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImageList.ImageStream")));
            this.IconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImageList.Images.SetKeyName(0, "Folder-Open.png");
            this.IconImageList.Images.SetKeyName(1, "ICON__0029_17.png");
            this.IconImageList.Images.SetKeyName(2, "ICON__0017_29.png");
            this.IconImageList.Images.SetKeyName(3, "ICON__0020_26.png");
            this.IconImageList.Images.SetKeyName(4, "ICON__0021_25b.png");
            this.IconImageList.Images.SetKeyName(5, "action.png");
            // 
            // Behavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.NodetreeView);
            this.Name = "Behavior";
            this.Text = "Behavior";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView NodetreeView;
        private System.Windows.Forms.ImageList IconImageList;
    }
}

