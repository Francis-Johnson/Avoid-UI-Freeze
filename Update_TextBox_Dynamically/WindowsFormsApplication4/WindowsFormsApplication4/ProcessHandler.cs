using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4
{

    public class UpdateProgressEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class ProcessHandler
    {
        //private Form1 mainForm = null;
        private int counter = 0;

        public event EventHandler ProgressChanged;

        private System.Timers.Timer timer = null;

        public ProcessHandler()
        {
            //this.mainForm = from;
        }

        public void RunTest()
        {
            timer = new System.Timers.Timer(3000);
            //timer.AutoReset = true;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter++;
            //mainForm.UpdateStatus(counter.ToString());

            UpdateProgressEventArgs arg = new UpdateProgressEventArgs() { Message = counter.ToString() };

            ProgressChanged(this, arg);
        }

        internal void Stop()
        {
            if (timer != null)
            {
                timer.Elapsed -= timer_Elapsed;
                timer.Stop();
            }
        }
    }
}
