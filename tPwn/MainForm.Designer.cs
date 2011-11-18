/*
 * User: Justin Vanderheide
 * Date: 10/23/2011
 * Time: 1:55 PM
 * 
 */
namespace tPwn
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblNext = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtX = new System.Windows.Forms.TextBox();
			this.txtY = new System.Windows.Forms.TextBox();
			this.btnMove = new System.Windows.Forms.Button();
			this.lblOffset = new System.Windows.Forms.Label();
			this.lblRotate = new System.Windows.Forms.Label();
			this.lblColor = new System.Windows.Forms.Label();
			this.tmrRun = new System.Windows.Forms.Timer(this.components);
			this.lblScore = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblNext
			// 
			this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNext.Location = new System.Drawing.Point(12, 38);
			this.lblNext.Name = "lblNext";
			this.lblNext.Size = new System.Drawing.Size(57, 50);
			this.lblNext.TabIndex = 0;
			this.lblNext.Text = "X";
			this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 12);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// txtX
			// 
			this.txtX.Location = new System.Drawing.Point(111, 15);
			this.txtX.Name = "txtX";
			this.txtX.Size = new System.Drawing.Size(42, 20);
			this.txtX.TabIndex = 2;
			// 
			// txtY
			// 
			this.txtY.Location = new System.Drawing.Point(159, 14);
			this.txtY.Name = "txtY";
			this.txtY.Size = new System.Drawing.Size(41, 20);
			this.txtY.TabIndex = 3;
			// 
			// btnMove
			// 
			this.btnMove.Location = new System.Drawing.Point(206, 12);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(37, 23);
			this.btnMove.TabIndex = 4;
			this.btnMove.Text = "Go";
			this.btnMove.UseVisualStyleBackColor = true;
			this.btnMove.Click += new System.EventHandler(this.BtnMoveClick);
			// 
			// lblOffset
			// 
			this.lblOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOffset.Location = new System.Drawing.Point(138, 37);
			this.lblOffset.Name = "lblOffset";
			this.lblOffset.Size = new System.Drawing.Size(57, 50);
			this.lblOffset.TabIndex = 5;
			this.lblOffset.Text = "X";
			this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRotate
			// 
			this.lblRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRotate.Location = new System.Drawing.Point(75, 38);
			this.lblRotate.Name = "lblRotate";
			this.lblRotate.Size = new System.Drawing.Size(57, 50);
			this.lblRotate.TabIndex = 6;
			this.lblRotate.Text = "X";
			this.lblRotate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblColor
			// 
			this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColor.Location = new System.Drawing.Point(12, 88);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(183, 50);
			this.lblColor.TabIndex = 7;
			this.lblColor.Text = "FFFFFF";
			this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tmrRun
			// 
			this.tmrRun.Interval = 1;
			this.tmrRun.Tick += new System.EventHandler(this.TmrRunTick);
			// 
			// lblScore
			// 
			this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScore.Location = new System.Drawing.Point(12, 138);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(183, 50);
			this.lblScore.TabIndex = 8;
			this.lblScore.Text = "0";
			this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(248, 200);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.lblColor);
			this.Controls.Add(this.lblRotate);
			this.Controls.Add(this.lblOffset);
			this.Controls.Add(this.btnMove);
			this.Controls.Add(this.txtY);
			this.Controls.Add(this.txtX);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lblNext);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "tPwn";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Timer tmrRun;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.Label lblRotate;
		private System.Windows.Forms.Label lblOffset;
		private System.Windows.Forms.Button btnMove;
		private System.Windows.Forms.TextBox txtY;
		private System.Windows.Forms.TextBox txtX;
		private System.Windows.Forms.Label lblNext;
	}
}
