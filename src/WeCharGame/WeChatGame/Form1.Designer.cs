namespace WeChatGame
{
    partial class Form1
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnJump = new System.Windows.Forms.Button();
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblBox = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPhoneModel = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.rtxtMsg = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblResoPo = new System.Windows.Forms.Label();
            this.btnStopAuto = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJumpK = new System.Windows.Forms.TextBox();
            this.txtJump = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnShowLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(13, 13);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(13, 54);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(396, 623);
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseClick);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(120, 12);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 23);
            this.btnJump.TabIndex = 2;
            this.btnJump.Text = "Jump";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(633, 95);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(11, 12);
            this.lblPerson.TabIndex = 3;
            this.lblPerson.Text = "0";
            // 
            // lblBox
            // 
            this.lblBox.AutoSize = true;
            this.lblBox.Location = new System.Drawing.Point(633, 144);
            this.lblBox.Name = "lblBox";
            this.lblBox.Size = new System.Drawing.Size(11, 12);
            this.lblBox.TabIndex = 4;
            this.lblBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "0,0";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(633, 182);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(11, 12);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "寻找小人时间(ms)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "寻找盒子中心点时间(ms)：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "点击的图片位置：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "两点间距离(px)：";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(228, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "当前连接手机：";
            // 
            // lblPhoneModel
            // 
            this.lblPhoneModel.AutoSize = true;
            this.lblPhoneModel.Location = new System.Drawing.Point(635, 223);
            this.lblPhoneModel.Name = "lblPhoneModel";
            this.lblPhoneModel.Size = new System.Drawing.Size(0, 12);
            this.lblPhoneModel.TabIndex = 13;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(334, 10);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 14;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // rtxtMsg
            // 
            this.rtxtMsg.Location = new System.Drawing.Point(472, 401);
            this.rtxtMsg.Name = "rtxtMsg";
            this.rtxtMsg.Size = new System.Drawing.Size(230, 421);
            this.rtxtMsg.TabIndex = 15;
            this.rtxtMsg.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "状态：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(566, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "分辨率：";
            // 
            // lblResoPo
            // 
            this.lblResoPo.AutoSize = true;
            this.lblResoPo.Location = new System.Drawing.Point(635, 257);
            this.lblResoPo.Name = "lblResoPo";
            this.lblResoPo.Size = new System.Drawing.Size(23, 12);
            this.lblResoPo.TabIndex = 18;
            this.lblResoPo.Text = "0x0";
            // 
            // btnStopAuto
            // 
            this.btnStopAuto.Location = new System.Drawing.Point(443, 9);
            this.btnStopAuto.Name = "btnStopAuto";
            this.btnStopAuto.Size = new System.Drawing.Size(75, 23);
            this.btnStopAuto.TabIndex = 19;
            this.btnStopAuto.Text = "StopAuto";
            this.btnStopAuto.UseVisualStyleBackColor = true;
            this.btnStopAuto.Click += new System.EventHandler(this.btnStopAuto_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(530, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "跳跃时间系数：";
            // 
            // txtJumpK
            // 
            this.txtJumpK.Location = new System.Drawing.Point(635, 298);
            this.txtJumpK.Name = "txtJumpK";
            this.txtJumpK.Size = new System.Drawing.Size(67, 21);
            this.txtJumpK.TabIndex = 21;
            this.txtJumpK.Text = "1.45";
            // 
            // txtJump
            // 
            this.txtJump.Location = new System.Drawing.Point(635, 325);
            this.txtJump.Name = "txtJump";
            this.txtJump.Size = new System.Drawing.Size(67, 21);
            this.txtJump.TabIndex = 23;
            this.txtJump.Text = "800";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(530, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "跳跃时间延时：";
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(635, 352);
            this.txtDown.Name = "txtDown";
            this.txtDown.Size = new System.Drawing.Size(67, 21);
            this.txtDown.TabIndex = 25;
            this.txtDown.Text = "1000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(530, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "盒子落地延时：";
            // 
            // btnShowLine
            // 
            this.btnShowLine.Location = new System.Drawing.Point(549, 9);
            this.btnShowLine.Name = "btnShowLine";
            this.btnShowLine.Size = new System.Drawing.Size(75, 23);
            this.btnShowLine.TabIndex = 26;
            this.btnShowLine.Text = "ShowLine";
            this.btnShowLine.UseVisualStyleBackColor = true;
            this.btnShowLine.Click += new System.EventHandler(this.btnShowLine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 845);
            this.Controls.Add(this.btnShowLine);
            this.Controls.Add(this.txtDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtJump);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtJumpK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnStopAuto);
            this.Controls.Add(this.lblResoPo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtxtMsg);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.lblPhoneModel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBox);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.Label lblBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPhoneModel;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.RichTextBox rtxtMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblResoPo;
        private System.Windows.Forms.Button btnStopAuto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtJumpK;
        private System.Windows.Forms.TextBox txtJump;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnShowLine;
    }
}

