using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwaitTaskWithException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var taskWithException = this.TaskWithException();

            DoSomethingLong(30);

            await taskWithException;
        }

        private void DoSomethingLong(int seconds)
        {
            // Thanks https://stackoverflow.com/a/5945547/580229

            // Could use DateTime.Now, but we don't care about time zones - just elapsed time
            // Also, UtcNow has slightly better performance
            var startTime = DateTime.UtcNow;

            while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(seconds))
            {
                // Execute your loop here...
            }
        }

        private async Task TaskWithException()
        {
            await Task.Run(() => this.DoSomethingLong(1));
            throw new Exception("Testing task with exception");
        }
    }
}