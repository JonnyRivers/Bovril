using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // async keyword here ensures this method is called in a separate thread
        private async void btnCallMethod_Click(object sender, EventArgs e)
        {
            this.Text = await DoWorkAsync();
        }

        // Return a Task that returns a String rather than a String.
        private async Task<String> DoWorkAsync()
        {
            // Create a task with Task.Run()
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work!";
            });
        }

        private async void btnMultiAwaits_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with first task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with second task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with third task!");
        }
    }
}
