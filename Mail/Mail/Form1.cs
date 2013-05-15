using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            URLs.SelectedIndex = 0;
            webBrowser1.GoHome();
        }

        private void Turnto_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri(URLs.SelectedItem.ToString()));
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void URLs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}