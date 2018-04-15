namespace Troya.Tools
{
    partial class WndAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndAdd));
            this.guiFileAsset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guiFileType = new System.Windows.Forms.ComboBox();
            this.guiBuild = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.guiProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guiFileAsset
            // 
            this.guiFileAsset.Location = new System.Drawing.Point(13, 26);
            this.guiFileAsset.Name = "guiFileAsset";
            this.guiFileAsset.ReadOnly = true;
            this.guiFileAsset.Size = new System.Drawing.Size(375, 22);
            this.guiFileAsset.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Asset:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Content Type:";
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
            this.guiFileType.Location = new System.Drawing.Point(13, 70);
            this.guiFileType.Name = "guiFileType";
            this.guiFileType.Size = new System.Drawing.Size(375, 22);
            this.guiFileType.TabIndex = 3;
            // 
            // guiBuild
            // 
            this.guiBuild.AutoSize = true;
            this.guiBuild.Checked = true;
            this.guiBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiBuild.Location = new System.Drawing.Point(13, 108);
            this.guiBuild.Name = "guiBuild";
            this.guiBuild.Size = new System.Drawing.Size(55, 18);
            this.guiBuild.TabIndex = 4;
            this.guiBuild.Text = "Build";
            this.guiBuild.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Add";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(313, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guiProfile
            // 
            this.guiProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiProfile.FormattingEnabled = true;
            this.guiProfile.Items.AddRange(new object[] {
            "HiDef",
            "Reach"});
            this.guiProfile.Location = new System.Drawing.Point(13, 155);
            this.guiProfile.Name = "guiProfile";
            this.guiProfile.Size = new System.Drawing.Size(157, 22);
            this.guiProfile.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Profile:";
            // 
            // WndAdd
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 205);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guiProfile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.guiBuild);
            this.Controls.Add(this.guiFileType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guiFileAsset);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Add New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox guiFileAsset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox guiFileType;
        private System.Windows.Forms.CheckBox guiBuild;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox guiProfile;
        private System.Windows.Forms.Label label3;
    }
}