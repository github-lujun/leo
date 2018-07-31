using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leo.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var r = await GetHelloAsync();
            var r = GetHelloAsync();
            r.Wait();
            this.textBox1.Text = r.Result;
        }

        private string GetHello()
        {
            System.Threading.Thread.Sleep(5000);
            return "Hello";
        }

        private async Task<string> GetHelloAsync()
        {
            var t = await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return "Hello";
            });
            return t;
        }
    }
}
