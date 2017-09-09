using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;

namespace miniplayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);
            textBox1.Text = "http://testserver.kissr.com/";
            chrome = new ChromiumWebBrowser(textBox1.Text);
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AdressChanged;
            this.TopMost = true;
        }

        private void Chrome_AdressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                textBox1.Text = e.Address;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chrome.Load(textBox1.Text);
        }
    }
}
