using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace point_operation
{
    public partial class linearPOForm : Form
    {
        public linearPOForm()
        {
            InitializeComponent();
        }

        private void startLinear_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetScaling
        {
            get
            {
                return scaling.Text;
            }
        }

        public string GetOffset
        {
            get
            {
                return offset.Text;
            }
        }
    }
}