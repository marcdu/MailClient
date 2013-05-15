using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mime;
using System.Net.Mail;
using System.Net;
using System.IO;




namespace MIME_Reader
{
    public partial class MIMEReader : Form
    {
        private MailMessage m_mail = null;

        public MIMEReader()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void SendMail_Click(object sender, EventArgs e)
        {
            ConstructMailMessage();
            SendAction();
        }

        private void SendFakeMail_Click(object sender, EventArgs e)
        {
            ConstructMailMessage();
            SendAction();
        }

        private void SendMailFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    string message = sr.ReadToEnd();
                    this.richTextBoxBody.Text = message;
                }

            }
        }

        private bool SendAction()
        {
            try
            {
                SmtpClient client = new SmtpClient(this.textBoxServerAddress.Text, int.Parse(this.textBoxServerPort.Text));
                client.Credentials = CredentialCache.DefaultNetworkCredentials;
                client.Send(m_mail);

            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }

        private void ConstructMailMessage()
        {
            m_mail = new MailMessage("Test@gmail.com", this.textBoxUserAddress.Text);
            m_mail.Subject = this.textBoxSubject.Text;
            m_mail.Body = this.richTextBoxBody.Text;
            m_mail.CC.Add(this.textBoxCC.Text);
        
        }
        private void ParseMail(StreamReader sr)
        {

        }

        private void openMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    string message = sr.ReadToEnd();
                    this.richTextBoxBody.Text = message;
                }
               
            }
            ParseMail();

            // 
            // DyButton
            // 
            uint count = 3;
            int boxX = 10;
            int boxY = 16;

            while (count-- > 0)
            {
                System.Windows.Forms.Button DyButton = new System.Windows.Forms.Button();
                DyButton.Location = new System.Drawing.Point(boxX, boxY);
                DyButton.Name = "DyButton " + count.ToString();
                //this.DyButton.Size = new System.Drawing.Size(58, 23);
                DyButton.TabIndex = 0;
                DyButton.Text = "New added" + count.ToString();
                DyButton.UseVisualStyleBackColor = true;
                DyButton.AutoSize = true;
                DyButton.Tag = count;
                this.Attachments.Controls.Add(DyButton);

                boxX = boxX + DyButton.Size.Width + 10;
            }
        }
     
    }
}