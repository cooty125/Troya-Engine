namespace Troya.Tools
{
    partial class WndMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMain));
            this.guiFontList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guiFontStyle = new System.Windows.Forms.ComboBox();
            this.guiFontSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guiFontPreview = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guiAntialias = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.guiInstallFont = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guiFontList
            // 
            this.guiFontList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.guiFontList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.guiFontList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.guiFontList.FormattingEnabled = true;
            this.guiFontList.Location = new System.Drawing.Point(12, 27);
            this.guiFontList.Name = "guiFontList";
            this.guiFontList.Size = new System.Drawing.Size(189, 206);
            this.guiFontList.TabIndex = 2;
            this.guiFontList.SelectedIndexChanged += new System.EventHandler(this.guiFontList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Font Family:";
            // 
            // guiFontStyle
            // 
            this.guiFontStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.guiFontStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.guiFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.guiFontStyle.FormattingEnabled = true;
            this.guiFontStyle.Items.AddRange(new object[] {
            "Regular",
            "Italic",
            "Bold",
            "Bold, Italic"});
            this.guiFontStyle.Location = new System.Drawing.Point(207, 27);
            this.guiFontStyle.Name = "guiFontStyle";
            this.guiFontStyle.Size = new System.Drawing.Size(70, 236);
            this.guiFontStyle.TabIndex = 4;
            this.guiFontStyle.Text = "Regular";
            this.guiFontStyle.SelectedIndexChanged += new System.EventHandler(this.guiFontStyle_SelectedIndexChanged);
            // 
            // guiFontSize
            // 
            this.guiFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.guiFontSize.FormattingEnabled = true;
            this.guiFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "23",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.guiFontSize.Location = new System.Drawing.Point(283, 27);
            this.guiFontSize.Name = "guiFontSize";
            this.guiFontSize.Size = new System.Drawing.Size(52, 236);
            this.guiFontSize.TabIndex = 6;
            this.guiFontSize.Text = "10";
            this.guiFontSize.SelectedIndexChanged += new System.EventHandler(this.guiFontSize_SelectedIndexChanged);
            this.guiFontSize.TextUpdate += new System.EventHandler(this.guiFontSize_TextUpdate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Style:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size:";
            // 
            // guiFontPreview
            // 
            this.guiFontPreview.AutoEllipsis = true;
            this.guiFontPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guiFontPreview.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiFontPreview.Location = new System.Drawing.Point(3, 19);
            this.guiFontPreview.Name = "guiFontPreview";
            this.guiFontPreview.Size = new System.Drawing.Size(304, 183);
            this.guiFontPreview.TabIndex = 13;
            this.guiFontPreview.Text = "This is just a text preview. The quick brown fox jumped over the LAZY camel.";
            this.guiFontPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guiFontPreview);
            this.groupBox1.Location = new System.Drawing.Point(346, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 205);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Font Preview";
            // 
            // guiAntialias
            // 
            this.guiAntialias.AutoSize = true;
            this.guiAntialias.Checked = true;
            this.guiAntialias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiAntialias.Location = new System.Drawing.Point(347, 227);
            this.guiAntialias.Name = "guiAntialias";
            this.guiAntialias.Size = new System.Drawing.Size(105, 19);
            this.guiAntialias.TabIndex = 15;
            this.guiAntialias.Text = "Antialise edges";
            this.guiAntialias.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(581, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(467, 227);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(109, 23);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // guiInstallFont
            // 
            this.guiInstallFont.Location = new System.Drawing.Point(10, 227);
            this.guiInstallFont.Name = "guiInstallFont";
            this.guiInstallFont.Size = new System.Drawing.Size(192, 23);
            this.guiInstallFont.TabIndex = 18;
            this.guiInstallFont.Text = "Install TTF Font";
            this.guiInstallFont.UseVisualStyleBackColor = true;
            this.guiInstallFont.Click += new System.EventHandler(this.guiInstallFont_Click);
            // 
            // WndMain
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(668, 261);
            this.Controls.Add(this.guiInstallFont);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guiAntialias);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guiFontSize);
            this.Controls.Add(this.guiFontStyle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guiFontList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WndMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Troya Engine - Font Maker";
            this.Load += new System.EventHandler(this.WndMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox guiFontList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox guiFontStyle;
        private System.Windows.Forms.ComboBox guiFontSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label guiFontPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox guiAntialias;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button guiInstallFont;
    }
}

