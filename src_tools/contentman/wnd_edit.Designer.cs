namespace Troya.Tools
{
    partial class WndEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndEdit));
            this.guiFileType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guiBuild = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guiProfile = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guiFileAsset = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guiFileType
            // 
            this.guiFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiFileType.FormattingEnabled = true;
            this.guiFileType.Items.AddRange(new object[] {
            "FONT",
            "MODEL",
            "STUDIOMODEL",
            "GAMEMODEL",
            "TEXTURE",
            "SHADER",
            "SOUND"});
            this.guiFileType.Location = new System.Drawing.Point(15, 69);
            this.guiFileType.Name = "guiFileType";
            this.guiFileType.Size = new System.Drawing.Size(180, 22);
            this.guiFileType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Content Type:";
            // 
            // guiBuild
            // 
            this.guiBuild.AutoSize = true;
            this.guiBuild.Checked = true;
            this.guiBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiBuild.Location = new System.Drawing.Point(15, 97);
            this.guiBuild.Name = "guiBuild";
            this.guiBuild.Size = new System.Drawing.Size(55, 18);
            this.guiBuild.TabIndex = 6;
            this.guiBuild.Text = "Build";
            this.guiBuild.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Profile:";
            // 
            // guiProfile
            // 
            this.guiProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiProfile.FormattingEnabled = true;
            this.guiProfile.Items.AddRange(new object[] {
            "HiDef",
            "Reach"});
            this.guiProfile.Location = new System.Drawing.Point(15, 135);
            this.guiProfile.Name = "guiProfile";
            this.guiProfile.Size = new System.Drawing.Size(180, 22);
            this.guiProfile.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(120, 174);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(39, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "File:";
            // 
            // guiFileAsset
            // 
            this.guiFileAsset.AutoSize = true;
            this.guiFileAsset.Location = new System.Drawing.Point(12, 26);
            this.guiFileAsset.Name = "guiFileAsset";
            this.guiFileAsset.Size = new System.Drawing.Size(73, 14);
            this.guiFileAsset.TabIndex = 14;
            this.guiFileAsset.Text = "<file_name>";
            // 
            // WndEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(207, 209);
            this.Controls.Add(this.guiFileAsset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guiProfile);
            this.Controls.Add(this.guiBuild);
            this.Controls.Add(this.guiFileType);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox guiFileType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox guiBuild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox guiProfile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label guiFileAsset;
    }
}