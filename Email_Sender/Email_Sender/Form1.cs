using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Email_Sender
{
    
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string fromAddress = "your email";
            string toAddress =textBox1.Text;// which one you want to send email to
            string subject = "Your subject"; // subject email
            string body = textBox2.Text; // text message


            //If you use an email with two-step verification, this won't work
            string smtpServer = "smtp-mail.outlook.com";
            int smtpPort = 587; // Port for TLS/STARTTLS
            string smtpUsername = "your email";
            string smtpPassword = "your password"; // Use an app-specific password if 2FA is enabled

            MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body);
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true // email requires SSL
            };

            try
            {
                // Send the email
                smtpClient.Send(mail);
                MessageBox.Show("Yes Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SmtpException smtpEx)
            {
                // Handle SMTP-specific exceptions
                //MessageBox.Show($"SMTP Error: {smtpEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text= smtpEx.Message + " smtpEx Error";
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                textBox2.Text = ex.Message + " Ex Error";
                // MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
