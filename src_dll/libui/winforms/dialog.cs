/* 
 * VixenDialog
 * =====================================================================
 * FileName: dialog.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System.Drawing;
using System.Windows.Forms;

namespace Troya.GUI.WinForms
{
    public class TroyaDialog : Form
    {
        Label guiLabelTitle;
        Panel guiPanelTitle;

        Point beginCursorLoc;
        Panel guiButtonCross;
        Timer timer;


        public TroyaDialog( ) {
            this.InitializeComponent( );
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            //this.Opacity = 0.9f;

            this.timer = new Timer( );
            this.timer.Interval = 10; // lower number = smoother move
            this.timer.Tick += this.timer_Tick;
        }

        private void SonoXDialog_Load( object sender, System.EventArgs e ) {
            this.BackColor = ColorTheme.DialogBackgroundColor;
            this.ForeColor = ColorTheme.FontColor;

            this.guiPanelTitle.BackColor = ColorTheme.ThemeColor;
            this.guiLabelTitle.ForeColor = ColorTheme.DialogTitleFontColor;
            this.guiLabelTitle.Text = this.Text;

            this.guiButtonCross.Visible = this.ControlBox;
        }
        protected override void OnPaint( PaintEventArgs e ) {
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( 0, this.guiPanelTitle.Height ), new Point( 0, this.Height ) );
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( 0, this.Height - 1 ), new Point( this.Width, this.Height - 1 ) );
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( this.Width - 1, this.guiPanelTitle.Height ), new Point( this.Width - 1, this.Height ) );
        }
        private void timer_Tick( object sender, System.EventArgs e ) {
            Point wndLoc = this.PointToClient( new Point( this.Location.X + Cursor.Position.X, this.Location.Y + Cursor.Position.Y ) );

            if ( Screen.PrimaryScreen.WorkingArea.Contains( wndLoc ) ) {
                this.Location = new Point( wndLoc.X - beginCursorLoc.X, wndLoc.Y - beginCursorLoc.Y );
                this.Invalidate( );
            }
        }

        private void guiPanelTitle_MouseDown( object sender, MouseEventArgs e ) {
            this.beginCursorLoc = e.Location;
            this.timer.Start( );
        }
        private void guiPanelTitle_MouseUp( object sender, MouseEventArgs e ) {
            this.timer.Stop( );
        }
        private void guiButtonCross_MouseEnter( object sender, System.EventArgs e ) {
            this.guiButtonCross.BackColor = Color.FromArgb( ColorTheme.ThemeColor.A, ColorTheme.ThemeColor.R / 2, ColorTheme.ThemeColor.G / 2, ColorTheme.ThemeColor.B / 2 );
        }
        private void guiButtonCross_MouseLeave( object sender, System.EventArgs e ) {
            this.guiButtonCross.BackColor = ColorTheme.ThemeColor;
        }
        private void guiButtonCross_Click( object sender, System.EventArgs e ) {
            this.Close( );
        }

        private void InitializeComponent( ) {
            this.guiPanelTitle = new System.Windows.Forms.Panel();
            this.guiButtonCross = new System.Windows.Forms.Panel();
            this.guiLabelTitle = new System.Windows.Forms.Label();
            this.guiPanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // guiPanelTitle
            // 
            this.guiPanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.guiPanelTitle.Controls.Add(this.guiButtonCross);
            this.guiPanelTitle.Controls.Add(this.guiLabelTitle);
            this.guiPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.guiPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.guiPanelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.guiPanelTitle.Name = "guiPanelTitle";
            this.guiPanelTitle.Size = new System.Drawing.Size(284, 24);
            this.guiPanelTitle.TabIndex = 0;
            this.guiPanelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guiPanelTitle_MouseDown);
            this.guiPanelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guiPanelTitle_MouseUp);
            // 
            // guiButtonCross
            // 
            this.guiButtonCross.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guiButtonCross.BackgroundImage = global::Troya.GUI.Properties.Resources.dlg_close;
            this.guiButtonCross.Location = new System.Drawing.Point(250, 0);
            this.guiButtonCross.Margin = new System.Windows.Forms.Padding(0);
            this.guiButtonCross.Name = "guiButtonCross";
            this.guiButtonCross.Size = new System.Drawing.Size(34, 24);
            this.guiButtonCross.TabIndex = 1;
            this.guiButtonCross.Visible = false;
            this.guiButtonCross.Click += new System.EventHandler(this.guiButtonCross_Click);
            this.guiButtonCross.MouseEnter += new System.EventHandler(this.guiButtonCross_MouseEnter);
            this.guiButtonCross.MouseLeave += new System.EventHandler(this.guiButtonCross_MouseLeave);
            // 
            // guiLabelTitle
            // 
            this.guiLabelTitle.AutoSize = true;
            this.guiLabelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.guiLabelTitle.Location = new System.Drawing.Point(4, 5);
            this.guiLabelTitle.Name = "guiLabelTitle";
            this.guiLabelTitle.Size = new System.Drawing.Size(52, 15);
            this.guiLabelTitle.TabIndex = 1;
            this.guiLabelTitle.Text = "<TITLE>";
            this.guiLabelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guiPanelTitle_MouseDown);
            this.guiLabelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guiPanelTitle_MouseUp);
            // 
            // VixenDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.guiPanelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TroyaDialog";
            this.Text = "<TITLE>";
            this.Load += new System.EventHandler(this.SonoXDialog_Load);
            this.guiPanelTitle.ResumeLayout(false);
            this.guiPanelTitle.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}