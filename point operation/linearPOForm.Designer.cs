namespace point_operation
{
    partial class linearPOForm
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
            this.startLinear = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scaling = new System.Windows.Forms.TextBox();
            this.offset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startLinear
            // 
            this.startLinear.Location = new System.Drawing.Point(26, 160);
            this.startLinear.Name = "startLinear";
            this.startLinear.Size = new System.Drawing.Size(75, 23);
            this.startLinear.TabIndex = 0;
            this.startLinear.Text = "确定";
            this.startLinear.UseVisualStyleBackColor = true;
            this.startLinear.Click += new System.EventHandler(this.startLinear_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(150, 160);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "退出";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "线性点运算：g(x,y)=Pf(x,y)+L";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "斜率（P）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "偏移量（L）：";
            // 
            // scaling
            // 
            this.scaling.Location = new System.Drawing.Point(101, 66);
            this.scaling.Name = "scaling";
            this.scaling.Size = new System.Drawing.Size(100, 21);
            this.scaling.TabIndex = 5;
            this.scaling.Text = "1";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(101, 109);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(100, 21);
            this.offset.TabIndex = 6;
            this.offset.Text = "0";
            // 
            // linearPOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 205);
            this.ControlBox = false;
            this.Controls.Add(this.offset);
            this.Controls.Add(this.scaling);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.startLinear);
            this.Name = "linearPOForm";
            this.Text = "线性点运算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startLinear;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scaling;
        private System.Windows.Forms.TextBox offset;
    }
}