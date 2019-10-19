namespace point_operation
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.open = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.stretch = new System.Windows.Forms.Button();
            this.equalization = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(49, 36);
            this.open.Margin = new System.Windows.Forms.Padding(4);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(100, 29);
            this.open.TabIndex = 1;
            this.open.Text = "打开图像";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(49, 187);
            this.close.Margin = new System.Windows.Forms.Padding(4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 29);
            this.close.TabIndex = 2;
            this.close.Text = "关闭";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // stretch
            // 
            this.stretch.Location = new System.Drawing.Point(49, 437);
            this.stretch.Margin = new System.Windows.Forms.Padding(4);
            this.stretch.Name = "stretch";
            this.stretch.Size = new System.Drawing.Size(100, 29);
            this.stretch.TabIndex = 4;
            this.stretch.Text = "灰度拉伸";
            this.stretch.UseVisualStyleBackColor = true;
            this.stretch.Click += new System.EventHandler(this.stretch_Click);
            // 
            // equalization
            // 
            this.equalization.Location = new System.Drawing.Point(49, 474);
            this.equalization.Margin = new System.Windows.Forms.Padding(4);
            this.equalization.Name = "equalization";
            this.equalization.Size = new System.Drawing.Size(100, 29);
            this.equalization.TabIndex = 5;
            this.equalization.Text = "直方图均衡";
            this.equalization.UseVisualStyleBackColor = true;
            this.equalization.Click += new System.EventHandler(this.equalization_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 400);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "拉普拉斯锐化";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 350);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "高斯模板去噪";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(49, 313);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "加噪声";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(49, 224);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "傅里叶变换";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(49, 261);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 29);
            this.button5.TabIndex = 10;
            this.button5.Text = "频率域过滤50-150";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.FFTfilter);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(49, 73);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 37);
            this.button6.TabIndex = 11;
            this.button6.Text = "黑白";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.changetoWBimg);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(49, 118);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 37);
            this.button7.TabIndex = 12;
            this.button7.Text = "fixWord";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.FixWorld);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 706);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.equalization);
            this.Controls.Add(this.stretch);
            this.Controls.Add(this.close);
            this.Controls.Add(this.open);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button close;

        private string curFileName = null;
        private System.Drawing.Bitmap curBitmap = null;
        private System.Windows.Forms.Button stretch;
        private System.Windows.Forms.Button equalization;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

