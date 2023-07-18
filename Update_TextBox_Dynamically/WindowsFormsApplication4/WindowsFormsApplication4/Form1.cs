using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        private ProcessHandler ph = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ph = new ProcessHandler();
        }

        public void UpdateStatus(string timeMessage)
        {
            textBox1.Text = timeMessage;
            Application.DoEvents();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ph.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Execute));
            t.Start();
        }

        private void Execute()
        {

            ph.ProgressChanged += ph_ProgressChanged;
            ph.RunTest();
        }

        void ph_ProgressChanged(object sender, EventArgs e)
        {
            UpdateProgressEventArgs arg = e as UpdateProgressEventArgs;

            if (this.textBox1.InvokeRequired)
            {
                this.textBox1.BeginInvoke((MethodInvoker)delegate()
                {
                    this.textBox1.Text = arg.Message;
                });
            }
            else
            {
                this.textBox1.Text = arg.Message;
            }
        }

    }
}
